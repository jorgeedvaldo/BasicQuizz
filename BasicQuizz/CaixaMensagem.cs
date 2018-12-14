using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicQuizz
{
    public partial class CaixaMensagem : Form
    {
        public DialogResult Status;
        public bool Aberto = false;
        public CaixaMensagem()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Status = DialogResult.Yes;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Status = DialogResult.No;
            this.Close();
        }

        public DialogResult Mostrar(Control ff, string Message, string Title = "") 
        {
            this.lbMessage.Text = Message;
            this.lbTitle.Text = Title;
            this.Width = ff.Width;
            this.Height = Convert.ToInt32(30*ff.Height/100);
            Aberto = true;
            this.ShowDialog();
            return Status;           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Status = DialogResult.OK;
            this.Close();
        }

        private void CaixaMensagem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Aberto = false;
        }
    }
}
