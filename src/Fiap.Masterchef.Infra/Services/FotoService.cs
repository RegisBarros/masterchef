using Fiap.Masterchef.Core.Services;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Fiap.Masterchef.Infra.Services
{
    public class FotoService : IFotoService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FotoService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string ObterUrl(string foto)
        {
            return ObterDiretorioLocal(foto);
        }

        public void Salvar(string foto, byte[] binary)
        {
            var diretorio = ObterDiretorioLocal(foto);

            SalvarArquivo(diretorio, foto, binary);
        }

        private string ObterDiretorioLocal(string arquivo)
        {
            return Path.Combine(_hostingEnvironment.WebRootPath, "images", arquivo);
        }

        private void SalvarArquivo(string diretorio, string arquivo, byte[] binary)
        {
            var local = Path.Combine(_hostingEnvironment.WebRootPath, "images");

            if (!Directory.Exists(local))
                Directory.CreateDirectory(local);

            File.WriteAllBytes(diretorio, binary);
        }
    }
}
