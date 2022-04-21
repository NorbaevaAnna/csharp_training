﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : TestBase
    {
        private string name;
        private string lastname;
        private string title = "";
        private string company = "";
        private string address = "";
        private string email = "";
        private string mobile = "";


        public ContactData(string name, string lastname)
        {
            this.name = name;
            this.lastname = lastname;
        }
        
        public string Name { get { return name; } set { name = value; } }
        public string Lastname { get { return lastname; } set { lastname = value; } }
        public string Company { get { return company; } set { company = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Mobile { get { return mobile; } set { mobile = value; } }
    }
}