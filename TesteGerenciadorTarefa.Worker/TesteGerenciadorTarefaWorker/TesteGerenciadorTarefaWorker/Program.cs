using TesteGerenciadorTarefaWorker;

IHost host = Host.CreateDefaultBuilder(args)

    .ConfigureServices(services =>
    {
        services.AddHostedService<GerenciadorTarefaWorker>();
    })
    .Build();

host.Run();
