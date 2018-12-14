using System;
using System.Collections.Generic;
using System.Text;
using BandWeb.DAL.Interfaces;
using BandWeb.Models;

namespace BandWeb.DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IAccountRepository _iaccountRepository;
        public AccountRepository(IAccountRepository iaccountRepository)
        {
            _iaccountRepository = iaccountRepository;
        }
        public void CreateUser(User user)
        {
            _iaccountRepository.CreateUser(user);
        }
    }
}
