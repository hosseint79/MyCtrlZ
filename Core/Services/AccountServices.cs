using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class AccountServices : IAccount
    {
        Context _Context;
        public AccountServices(Context contex)
        {
            _Context = contex;
        }
        public bool ExistEmail(string email)
        {
            return _Context.Users.Any(e => e.Email == email);
        }

        public User Login(string email, string pass)
        {
            return _Context.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == email && u.PassWord == pass);
        }

        public void Register(User user)
        {
            _Context.Users.Add(user);
            _Context.SaveChanges();
        }
    }
}
