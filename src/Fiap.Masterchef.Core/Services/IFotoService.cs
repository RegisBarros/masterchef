namespace Fiap.Masterchef.Core.Services
{
    public interface IFotoService
    {
        string ObterUrl(string foto);

        void Salvar(string foto, byte[] binary);
    }
}
