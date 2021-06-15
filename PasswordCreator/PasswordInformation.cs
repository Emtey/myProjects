using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;

namespace PasswordCreator
{
    class PasswordInformation
    {
        private static PasswordInformation passwordInformation;

        private Dictionary<string, PasswordEntity> passwordDictionary;
        private BinaryFormatter formatter;

        private const string DATE_FILENAME = "PasswordInformation.dat";

        public static PasswordInformation Instance()
        {
            if (passwordInformation == null)
            {
                passwordInformation = new PasswordInformation();
            }
            return passwordInformation;
        }

        private PasswordInformation()
        {
            //create dictionary to store password entities in at run time
            this.passwordDictionary = new Dictionary<string, PasswordEntity>();
            this.formatter = new BinaryFormatter();
        }

        public void AddPassword(string name, string password)
        {
            //check to see if we already have a password entity
            //if its already there, then remove it to allow for the new entry
            if (this.passwordDictionary.ContainsKey(name))
            {
                this.passwordDictionary.Remove(name);
            }

            //add the new password entity
            this.passwordDictionary.Add(name, new PasswordEntity(name, password));
            this.Save();
            MessageBox.Show("Password added.");
        }

        /// <summary>
        /// Save the password entity to a file
        /// </summary>
        public void Save()
        {
            try
            {
                //create filestream that will write data to a file
                FileStream writerFileStream = new FileStream(DATE_FILENAME, FileMode.Create, FileAccess.Write);
                this.formatter.Serialize(writerFileStream, this.passwordDictionary);

                //close the filestream
                writerFileStream.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to save Password Information!");
            }
        }

        /// <summary>
        /// Load the password entity from a file
        /// </summary>
        public void Load()
        {
            if (File.Exists(DATE_FILENAME))
            {
                try
                {
                    //opens the file to read from
                    FileStream readerFileStream = new FileStream(DATE_FILENAME, FileMode.Open, FileAccess.Read);
                    //reconstruct password Entities from the file
                    this.passwordDictionary = (Dictionary<string, PasswordEntity>)
                        this.formatter.Deserialize(readerFileStream);

                    //close the file stream
                    readerFileStream.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Cannot read Password Information file!");
                }

            }
        }
        public List<PasswordEntity> Print()
        {
            List<PasswordEntity> myList = new List<PasswordEntity>();

            if (this.passwordDictionary.Count > 0)
            {
                foreach (PasswordEntity pe in this.passwordDictionary.Values)
                {
                    myList.Add(pe);
                }
                return myList;
            }
            else
            {
                string errMsg = "Nothing on File!";
                string errMsg2 = " ";
                PasswordEntity myPe = new PasswordEntity(errMsg, errMsg2);
              
                //myList.Add("Nothing on File");
                return myList;
            }
               
        }
    }
}
