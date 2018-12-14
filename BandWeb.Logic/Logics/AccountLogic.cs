using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.IO;
using BandWeb.DAL.Interfaces;
using BandWeb.Models;
using BandWeb.Logic.Interfaces;

namespace BandWeb.Logic.Logics
{
    public class AccountLogic : IAccountLogic
    {
        private readonly IAccountRepository _accountrepo;
        public AccountLogic(IAccountRepository accountRepo)
        {
            _accountrepo = accountRepo;
        }
        public void CreateUser(User user)
        {
            _accountrepo.CreateUser(user);
        }
    }
}
