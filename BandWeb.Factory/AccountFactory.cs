using System;
using System.Collections.Generic;
using System.Text;
using BandWeb.DAL.Contexts;
using BandWeb.DAL.Repositories;
using BandWeb.Logic.Interfaces;
using BandWeb.Logic.Logics;
using Microsoft.Extensions.Configuration;


namespace BandWeb.Factory
{
    public class AccountFactory
    {
        private readonly IConfiguration _iconfiguration;

        public AccountFactory(IConfiguration configuration)
        {
            _iconfiguration = configuration;
        }
        public static IAccountLogic CreateSqlLogic(IConfiguration configuration)
        {
            return new AccountLogic(new AccountRepository(new AccountSqlContext(configuration)));
        }
    }
}
