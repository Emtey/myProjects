using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordCreator
{
    public partial class frmDisplayPassword : Form
    {
        PasswordInformation pi = PasswordInformation.Instance();
        public frmDisplayPassword()
        {
            InitializeComponent();

            LstViewPassword.View = View.Details;
            LstViewPassword.FullRowSelect = true;
            //LstViewPassword.AutoResizeColumn = true;

            //Add column headers
            LstViewPassword.Columns.Add("Name", 100);
            LstViewPassword.Columns.Add("Password", 150);        
          
            pi.Load();
            List<PasswordEntity> myList = new List<PasswordEntity>();
            myList = pi.Print();

           foreach (PasswordEntity passwordEntity in myList)
           {
                //add items to the list view
                ListViewItem itm;
                string[] arr =  new string[2];
                arr[0] = passwordEntity.Name;
                arr[1] = passwordEntity.Password;
                itm = new ListViewItem(arr);
                LstViewPassword.Items.Add(itm);              

           }

        }

    }
}
