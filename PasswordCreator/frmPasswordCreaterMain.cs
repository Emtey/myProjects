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
    public partial class frmPasswordCreaterMain : Form
    {
        public frmPasswordCreaterMain()
        {
            InitializeComponent();
        }

        private void btnCreatePassword_Click(object sender, EventArgs e)
        {
            frmCreatePassword myForm = new frmCreatePassword();
            myForm.Show();
        }
    }
}
