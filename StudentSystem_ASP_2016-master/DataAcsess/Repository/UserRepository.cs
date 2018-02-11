using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Repository
{
    public class UserRepository: GenericRepository<SingIn>
    {
        public SingIn GetbyUsernameAndPassword(string name, string pass)
        {
            return set.FirstOrDefault(
                i => i.Username == name && i.Password == pass);
        }
    }
}
