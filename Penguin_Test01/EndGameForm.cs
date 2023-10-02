using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Penguin_Test01.Classes.Entities; 

namespace Penguin_Test01
{
    public partial class EndGameForm : Form
    {
        public EndGameForm(string message)
        {
            InitializeComponent();
            this.labelTitle.Text = message;             
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            GameManager.StartGame();
            this.Close(); 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
