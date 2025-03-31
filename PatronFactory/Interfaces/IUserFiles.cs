using PatronFactory.Model;

namespace PatronFactory.Interfaces
{
    public interface IUserFiles
    {
        Byte[] GenerarArchivo(List<User> usuarios);
        string ContentType();
        string Format();

    }
}
