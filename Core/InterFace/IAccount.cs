using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IAccount
    {
        public User Login(string email , string pass);
        public void Register(User user);
        public bool ExistEmail(string email);
    }
}
