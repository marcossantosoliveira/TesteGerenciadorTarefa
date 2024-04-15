

using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;
using TesteGerenciadorTarefas.Domain.Interfaces.Mensageria;

namespace TesteGerenciadorTarefas.Infra.Mensageria
{
    public class MensageriaService : IMensageriaService
    {
        private const string _exchange = "tarefa-service";

        public MensageriaService()
        {             

        }

        public void Publicar(object objeto, string routinKey)
        {

            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            using (var connection = connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

                var payload = JsonConvert.SerializeObject(objeto);
                var byteArray = Encoding.UTF8.GetBytes(payload);


                channel.QueueDeclare(
                    queue: routinKey,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                channel.BasicPublish("", routinKey, null, byteArray);

            }         
        }
    }
}
