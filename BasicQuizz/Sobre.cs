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
    public partial class Sobre : Form
    {
        //Variavel para alternar as cores do fundo
        byte[] rgbColor = new byte[] { 0, 191, 255 };
        int caso = 0;
        public MenuPrincipal menuPrincipal;


        public Sobre()
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            menuPrincipal.Location = this.Location;
            menuPrincipal.Show();
            this.Close();
        }

      
    }
}
