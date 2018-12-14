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
    public partial class MenuPrincipal : Form
    {
        //Variavel para alternar as cores do fundo
        byte[] rgbColor = new byte[] { 0, 191, 255 };
        int caso = 0;
        CaixaMensagem caixaMensagem = new CaixaMensagem();


        public MenuPrincipal()
        {
            InitializeComponent();
            
        }

        #region Metodos e variaveis para mover e fechar o Form
        //Variáveis locais para mover o formulário    
        Point newpoint = new Point();
        int mouseX, mouseY;
        private void Objecto_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = Control.MousePosition.X - this.Location.X;
            mouseY = Control.MousePosition.Y - this.Location.Y;

        }

        private void Objecto_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                newpoint = Control.MousePosition;
                newpoint.X -= mouseX;
                newpoint.Y -= mouseY;
                this.Location = newpoint;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((rgbColor[1] >= 67 || rgbColor[2] >= 89) && caso == 0)
            {
                if (rgbColor[1] != 67)
                { 
                    rgbColor[1]--; 
                }
                if (rgbColor[2] != 89)
                {
                    rgbColor[2]--;
                }
                if (rgbColor[1] == 67 && rgbColor[2] == 89)
                {
                    caso = 1;
                }

                panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(rgbColor[0])))), ((int)(((byte)(rgbColor[1])))), ((int)(((byte)(rgbColor[2])))));
                panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(rgbColor[0])))), ((int)(((byte)(rgbColor[1])))), ((int)(((byte)(rgbColor[2])))));
                panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(rgbColor[0])))), ((int)(((byte)(rgbColor[1])))), ((int)(((byte)(rgbColor[2])))));
                panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(rgbColor[0])))), ((int)(((byte)(rgbColor[1])))), ((int)(((byte)(rgbColor[2])))));

            } 
            if ((rgbColor[1] <= 191 || rgbColor[2] <= 255) && caso == 1)
            {
                if (rgbColor[1] != 191)
                {
                    rgbColor[1]++;
                }
                if (rgbColor[2] != 255)
                {
                    rgbColor[2]++;
                }
                if (rgbColor[1] == 191 && rgbColor[2] == 255)
                {
                    caso = 0;
                }

                panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(rgbColor[0])))), ((int)(((byte)(rgbColor[1])))), ((int)(((byte)(rgbColor[2])))));
                panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(rgbColor[0])))), ((int)(((byte)(rgbColor[1])))), ((int)(((byte)(rgbColor[2])))));
                panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(rgbColor[0])))), ((int)(((byte)(rgbColor[1])))), ((int)(((byte)(rgbColor[2])))));
                panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(rgbColor[0])))), ((int)(((byte)(rgbColor[1])))), ((int)(((byte)(rgbColor[2])))));

            }

            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 Jogo = new Form1(this);
            Jogo.Location = this.Location;
            Jogo.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            caixaMensagem.btnOk.Visible = false;
            caixaMensagem.btnYes.Visible = true;
            caixaMensagem.btnNo.Visible = true;
            DialogResult Sn = caixaMensagem.Mostrar(this, "Tem a certeza que deseja terminar a aplicação?", "Terminar a aplicação");
            if(Sn == System.Windows.Forms.DialogResult.Yes){
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 Jogo = new Form1(this);
            Jogo.Location = this.Location;
            Jogo.button5.Visible = true;
            Jogo.button6.Visible = false;
            Jogo.IsContraRelogio = true;
            Jogo.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sobre sobre = new Sobre();
            sobre.menuPrincipal = this;
            sobre.Location = this.Location;
            sobre.Show();
            this.Hide();
        }
    }
}
