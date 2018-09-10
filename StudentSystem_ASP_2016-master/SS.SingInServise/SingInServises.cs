using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SS.SingInServise
{
    public class SingInServises
       : BaseServise<SingIn>
    {

        public SingInServises()
            : base()
        {
            
        }
        public SingInServises(UnitOfWork unit)
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
        

        public void ChangePassword(int id, string password)
        {
            var user = GetByID(id);
            user.Password = EncriptServise.EncryptData(password);
            Save(user);
        }

        public SingIn ResetPassword(List<SingIn> users, string email)
        {
            string decriptedEmail;
            for (int i = 0; i < users.Count; i++)
            {
                decriptedEmail = EncriptServise.DencryptData(users[i].Email);
                if (email == decriptedEmail)
                {
                    return users[i];
                }
            }
            return null;
        }

        public void RememberMe(string username, string password)
        {

            string filePath = @"C:\StudentSystem\login.txt";
            try
            {
                StreamWriter writer = new StreamWriter(filePath);
                using (writer)
                {
                    writer.WriteLine(EncriptServise.EncryptData(username));
                    writer.WriteLine(EncriptServise.EncryptData(password));
                }
            }
            catch (Exception)
            {
                string folderPath = @"C:\StudentSystem\";
                bool folder = Directory.Exists(folderPath);
                if (!folder)
                {
                    Directory.CreateDirectory(folderPath);
                }
                RememberMe(username, password);
            }
        }

        public List<string> AutoLogin()
        {
            List<string> loginInfo = new List<string>();
            string filePath = @"C:\StudentSystem\login.txt";
            try
            {
                StreamReader reader = new StreamReader(filePath);
                int lineNumber = 0;
                string line = reader.ReadLine();

                using (reader)
                {
                    while (line != null)
                    {
                        lineNumber++;
                        loginInfo.Add(EncriptServise.DencryptData(line));
                        line = reader.ReadLine();
                    }

                }
            }
            catch (Exception)
            {
                
            }
            return loginInfo;
        }
    }
}
