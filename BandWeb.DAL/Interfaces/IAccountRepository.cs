using System;
using System.Collections.Generic;
using System.Text;
using BandWeb.Models;

namespace BandWeb.DAL.Interfaces
{
    public interface IAccountRepository
    {
        void CreateUser(User user);
    }
}
