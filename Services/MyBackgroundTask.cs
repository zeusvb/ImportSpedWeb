namespace ImportSpedWeb.Services
{
    public class MyBackgroundTask : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Aqui vai a lógica da sua tarefa
                Console.WriteLine("Tarefa de segundo plano executando...");
                //ativar leitura de arquivo sped
                // Aguarda 5 segundos antes de repetir
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Serviço de segundo plano parando...");
            return base.StopAsync(cancellationToken);
        }
    }
}
