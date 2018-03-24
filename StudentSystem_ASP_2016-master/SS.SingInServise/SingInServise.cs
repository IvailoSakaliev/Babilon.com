using DataAcsess.Models;
using DataAcsess.UnitOfWork;
using SS.GenericServise;

namespace SS.SingInServise
{
    public class SingInServise
       : BaseServise<SingIn>
    {
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
    }
}
