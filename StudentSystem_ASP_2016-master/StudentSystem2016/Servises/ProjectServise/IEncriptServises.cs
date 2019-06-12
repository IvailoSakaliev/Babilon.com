namespace StudentSystem2016.Servises.ProjectServise
{
    public interface IEncriptServises
    {
        string DencryptData(string toDencrypted);
        string EncryptData(string toEncrypted);
    }
}