using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.Service.Commons
{
    public class IdentitySingelton
    {
        public int UserId { get; private set; }

        private static IdentitySingelton _identitySingelton;
        private IdentitySingelton()
        {
        }
        public static void BuildInstance(int userId)
        {
            if (_identitySingelton is null)
            {
                _identitySingelton = new IdentitySingelton();
                _identitySingelton.UserId = userId;
            }
            else throw new Exception("Is not null Instance");
        }
        public static IdentitySingelton GetInstance()
        {
            return _identitySingelton;
        }
    }
}
