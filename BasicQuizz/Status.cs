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
    public partial class Status : Form
    {
        public static int points = 0;
        Button[] button = new Button[20];
        Color CorrectColor = Color.MediumSeaGreen;
        Color ButtonColor;
        int i = 0;
        public Status()
        {
            InitializeComponent();
            this.Visible = false;

            #region Array dos buttons
            while (i < 20)
            {
                foreach (Control bt in Controls)
                {
                    if (bt is Button)
                    {
                        if (bt.Name == ("b" + (i + 1)))
                        {  
                            button[i] = (Button)bt;            
                        }                    
                    }               
                }
                i++;
            }
            #endregion
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

        
        private void Status_Load(object sender, EventArgs e)
        {
            //timer1.Enabled = true;
            //temp = true;
            //ButtonColor = button[points - 1].BackColor;
        }

        int Temporizador = 0;
        bool temp = true;
        int OutroTemp = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Temporizador += 600;
                button[points - 1].BackColor = button[points - 1].BackColor == CorrectColor && temp == true ? ButtonColor : CorrectColor;
                if (Temporizador >= 2100 * 4)
                {
                    Temporizador = 0;
                    temp = false;
                }

                if (!temp)
                {
                    OutroTemp++;
                    button[points - 1].BackColor = CorrectColor;
                    if (OutroTemp == 20)
                    {
                        timer1.Enabled = false;
                        this.Visible = false;
                        OutroTemp = 0;
                    }
                }
            }
            catch { }
             

        }

        private void Status_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible){
                timer1.Enabled = true;
                temp = true;
                ButtonColor = button[points - 1].BackColor;
            }
        }
        

       

        
    }
}
