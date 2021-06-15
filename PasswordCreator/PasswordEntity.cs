using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCreator
{
    [Serializable]  //so we can save the data here
    class PasswordEntity
    {
        private string name;
        private string password;

        public PasswordEntity (string name, string password)
        {
            this.name = name;
            this.password = password;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value;  }
        }
    }
}
