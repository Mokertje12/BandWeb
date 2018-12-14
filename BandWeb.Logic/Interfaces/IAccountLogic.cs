using System;
using System.Collections.Generic;
using System.Text;
using BandWeb.Models;

namespace BandWeb.Logic.Interfaces
{
    public interface IAccountLogic
    {
        void CreateUser(User user);
    }
}