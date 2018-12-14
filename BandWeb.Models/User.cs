﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BandWeb.Models
    {
        public class User
        {
            public int id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string streetname { get; set; }
            public int housenumber { get; set; }
            public string city { get; set; }

            public User(string Name, string Email, string Password, string Streetname, int Housenumber, string City)
            {
                name = Name;
                email = Email;
                password = Password;
                streetname = Streetname;
                housenumber = Housenumber;
                city = City;
            }
            public User()
            {

            }
        }
    }

