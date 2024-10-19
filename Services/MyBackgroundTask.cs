using ImportSpedWeb.Data;
using ImportSpedWeb.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using System.Reflection;
using System.ServiceModel.Channels;


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


                ImportArquivo Lr = new ImportArquivo();

                //if (!Lr.LerArquivo())
                //{
                //    await Task.Delay(TimeSpan.FromSeconds(150), stoppingToken);
                //}
                //else
                //{
                    await Task.Delay(TimeSpan.FromSeconds(50), stoppingToken);
              //  }
                        
                    
                



                //ativar leitura de arquivo sped
                // Aguarda 5 segundos antes de repetir
              //  await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Serviço de segundo plano parando...");
            return base.StopAsync(cancellationToken);
        }
    }

    public  class ImportArquivo
    {
      
        NpgsqlConnection _cnn;

        public ImportArquivo()
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();

            string connectionString = configuration.GetConnectionString("ImportConnection");
          

            _cnn = new NpgsqlConnection(connectionString);
        }
      
        public   bool LerArquivo(FileData fileData)
        {
            _cnn.Open();
            string tb = "Select * from arquivossped where status = 0 limit  1";

            NpgsqlCommand cmd = new NpgsqlCommand(tb,_cnn);
            cmd.CommandType = CommandType.Text;

            string Cod ="";
            FileData Arq = new FileData();

            using (var dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                  
                    if (dr.Read())
                    {
                        Arq.filepath = (string)dr["filepath"];
                        Arq.contenttype = (string)dr["contenttype"];
                        Arq.filename = (string)dr["filename"];
                        Arq.data = (byte[])dr["data"];
                        Arq.idfiles = (int)(long)dr["idfiles"];
                    }
                else
                    {
                        return false;
                    }
                }
                
                cmd.Dispose();

                    string applicationPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

                    var uploadPath = Path.Combine( applicationPath, "Downloads");

                    if (!Directory.Exists(uploadPath))
                        Directory.CreateDirectory(uploadPath);

                    var filePath = Path.Combine(uploadPath, Arq.filename.ToString());

                    FileInfo Fl = new FileInfo(filePath);
                    if (Fl.Exists)
                    {
                        Fl.Delete();
                    }

                    using (var ArqTxt = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                        ArqTxt.Write(Arq.data,0, Arq.data.Length);

                    lerSped(filePath);

                    //string sql = "update arquivossped set status =1 where idfiles = " + Arq.idfiles;

                    //NpgsqlCommand cmdd = new NpgsqlCommand(sql,_cnn);

                    //cmdd.ExecuteNonQuery();

                    return true;
                
            }


            return false;


        }
        private async void lerSped(string ArqSped)
        {

            System.IO.Stream stream = System.IO.File.OpenRead(ArqSped);

            EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Escrituracao escrituracao = new();
            //escrituracao.Encoding = System.Text.Encoding.Default; //opcional  
            await escrituracao.LeArquivo(stream);

            string nna = "";

           
        }



    }
}
