using System.Text;
using System.Threading.Channels;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace TesteGerenciadorTarefaWorker
{
    public class GerenciadorTarefaWorker : BackgroundService 
    {
        private readonly ILogger<GerenciadorTarefaWorker> _logger;

        public GerenciadorTarefaWorker(ILogger<GerenciadorTarefaWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            try
            {
                var mensagensFila = new List<TarefaModel>();

                while (mensagensFila == null || mensagensFila.Count <= 0)
                {
                    if (mensagensFila != null)
                    {
                        mensagensFila = GerenciadorTarefaConsumer();

                        if (mensagensFila.Count <= 0)
                        {
                            mensagensFila = null;
                            _logger.LogInformation($"Não existe item  na fila");
                        }
                        else
                        {
                            foreach (var item in mensagensFila)
                            {
                                _logger.LogInformation($"Mensagem consumida com sucesso Tarefa - {item.Descricao}");

                                Console.WriteLine($"Mensagem consumida com sucesso Tarefa: {item.Descricao} - id: {item.Id}");
                                await Task.Delay(1000, stoppingToken);
                            }
                        }
                    }                 

                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {

                _logger.LogInformation($"Erro ao consumir mensagem {ex}");
            }

        }

        private List<TarefaModel> GerenciadorTarefaConsumer()
        {
            var tarefasModel = new List<TarefaModel>();

            try
            {

                var factory = new ConnectionFactory
                {
                    HostName = "localhost"
                };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {

                    var tarefaModel = new TarefaModel();

                    channel.QueueDeclare(queue: "gerenciador-tarefa-routingKey",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);


                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body.ToArray());

                        tarefaModel = JsonConvert.DeserializeObject<TarefaModel>(message);

                        if (tarefaModel?.Id != 0 && tarefaModel != null)
                        {
                            tarefasModel.Add(tarefaModel);
                        }                        

                        channel.BasicAck(ea.DeliveryTag, false);
                    };

                    channel.BasicConsume(queue: "gerenciador-tarefa-routingKey",
                                         autoAck: true,
                                         consumer: consumer);

                    Console.WriteLine("Press Any Key to Continue..");
                    Console.ReadLine();

                    return tarefasModel;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Erro ao consumir mensagem {ex}  ");

                return tarefasModel;
            }
        }
    }
}