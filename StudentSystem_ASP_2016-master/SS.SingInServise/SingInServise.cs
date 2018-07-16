using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;
using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace SS.SingInServise
{
    public class SingInServise
       : BaseServise<SingIn>
    {
        private string hash = "f0xle@rn";

        public SingInServise()
            : base()
        {

        }
        public SingInServise(UnitOfWork unit)
            : base(unit)
        {

        }
        public void ConfirmedRegistration(int ? id)
        {
            SingIn user = GetByID(id);
            user.isRegisted = true;
            Save(user);
        }
        public static bool IsConfirmRegistartion(SingIn user)
        {
            if (user.isRegisted)
            {
                return user.isRegisted;
            }
            return user.isRegisted;
        }
        public string EncryptData(string toEncrypted)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(toEncrypted);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(this.hash));
                using (TripleDESCryptoServiceProvider tripeDescryptProvider = new TripleDESCryptoServiceProvider() {Key=keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7})
                {
                    ICryptoTransform transform = tripeDescryptProvider.CreateEncryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(result, 0, result.Length);
                }
            }
        }
        public string DencryptData(string toDencrypted)
        {
            byte[] data = Convert.FromBase64String(toDencrypted);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(this.hash));
                using (TripleDESCryptoServiceProvider tripeDescryptProvider = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripeDescryptProvider.CreateDecryptor();
                    byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(result);
                }
            }
        }
    }
}
