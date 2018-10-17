﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLTicTacToe
{
    public class Profile
    {
        private string _username;
        private string _password;


        public Profile()
        {
            _username = "Default";
            _password = "Irresponsible";
        }

        public Profile(string Username, string Password)
        {
            _username = Username;
            _password = Password;
        }

        public string Username
        {
            get
            {
                return _username;
            }
        }

        private bool validPassword()
        {
            Console.WriteLine("Please enter your password");
            do
            {
                string inputPassword = Console.ReadLine();
                if (inputPassword == _password)
                {
                    return true;
                }
                else if (inputPassword == "cancel")
                {
                    Console.WriteLine("Operation Cancelled");
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter the correct password, or enter 'cancel' to cancel the operation.");
                }
            }
            while (true);
        }

        public void changeUsername(string Username)
        {
            if (validPassword())
            {
                _username = Username;
            }
            else
            {
                return;
            }
        }
    }
}
