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
    public partial class Form1 : Form
    {
        CaixaMensagem caixaMensagem = new CaixaMensagem();
        Status status = new Status();
        WinnerScreen winnerScreen = new WinnerScreen();

        Random random = new Random();
        int Pergunta, Resposta, Alternativa, Temporizador = 0, ButtonEscolhido;
        Button[] button;
        String[] Inf = new String[] { "A: ", "B: ", "C: ", "D: " };

        //Cores
        public Color NormalColor = Color.DeepSkyBlue;
        public Color GoodColor = Color.MediumSeaGreen;
        public Color BadColor = Color.Crimson;
        public Color ButtonColor = Color.SteelBlue;
        public Color AlternativeColor = Color.Orange;

        int ColorButtonEfect = 20; bool state = true;
        MenuPrincipal menuPrincipal = new MenuPrincipal();

        //Propriets for clock
        public bool IsContraRelogio = false; int ContraRelogioTime = 0; int ContraRelogioSegundos = 200;
        public Form1(MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            button = new Button[] { button1, button2, button3, button4 };
            this.menuPrincipal = menuPrincipal;
            
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

        void EscolherPergunta() {
            //Escolhe a pergunta consoante o nivel
            Pergunta = random.Next(0, Document.NivelPergunta(Document.Nivel, Document.perguntas.Length));
            Resposta = random.Next(0, 4);
            Alternativa = random.Next(0,3);

            label1.Text = Document.perguntas[Pergunta];
            button[Resposta].Text = Inf[Resposta] + Document.respostas[Pergunta];

            for (int i = 0; i < 4; i++ )
            {
                if(Alternativa > 2){
                    Alternativa = 0;
                }
                if(i != Resposta){
                    button[i].Text = Inf[i] + Document.alternativas[Pergunta, Alternativa];
                    Alternativa++;
                }
            }

            //isto só executa caso o jogo for em modo de contra-relógio
            if(IsContraRelogio){
                //reiniciando o tempo e voltando a ligar o timer
                ContraRelogioSegundos = 200;
                timer2.Enabled = true;
            }
        }

        void Responder(int r) {
            //desligando o timer 2
            timer2.Enabled = false;

            if (timer1.Enabled)
            {
                button[r].BackColor = button[r].BackColor == ButtonColor ? AlternativeColor : ButtonColor;
                return;
            }

            if (r == Resposta)
            {
                button[r].BackColor = GoodColor;
                MudarCor(GoodColor);

                caixaMensagem.Mostrar(this, "Resposta certa!", "Certo");

                MudarCor(NormalColor);
                button[r].BackColor = ButtonColor;

                Document.Pontos++;
                lbpontos.Text = "Pontos: " + Document.Pontos;
                Document.AvancaNivel(Document.Pontos);
                TelaContagem(Document.Pontos);
                EscolherPergunta();
                
            }
            else {
                button[r].BackColor = BadColor;
                MudarCor(BadColor);

                caixaMensagem.Mostrar(this, "Resposta errada!", "Errado");
                button[r].BackColor = ButtonColor;

                Document.ResetJogo();
                menuPrincipal.Visible = true;
                this.Close();
            }
        }

        void MudarCor(Color cor) {
            this.panel1.BackColor = cor;
            this.panel2.BackColor = cor;
            this.panel3.BackColor = cor;
            this.panel4.BackColor = cor;
            caixaMensagem.BackColor = cor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {         
            EscolherPergunta();
            status.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            caixaMensagem.btnYes.Visible = true;
            caixaMensagem.btnNo.Visible = true;
            caixaMensagem.btnOk.Visible = true; caixaMensagem.btnOk.Text = "Desistir";
            DialogResult SimNao = caixaMensagem.Mostrar(this, "Tem a certeza?", "Responder");
            if(SimNao == System.Windows.Forms.DialogResult.Yes){
                timer1.Enabled = true;
                ButtonEscolhido = 0;
                button[ButtonEscolhido].BackColor = AlternativeColor;
            }
            else if (SimNao == System.Windows.Forms.DialogResult.OK) {
                menuPrincipal.Visible = true;
                this.Close();          
            }
            caixaMensagem.btnYes.Visible = false;
            caixaMensagem.btnNo.Visible = false;
            caixaMensagem.btnOk.Visible = true; caixaMensagem.btnOk.Text = "OK";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            caixaMensagem.btnYes.Visible = true;
            caixaMensagem.btnNo.Visible = true;
            caixaMensagem.btnOk.Visible = true; caixaMensagem.btnOk.Text = "Desistir";
            DialogResult SimNao = caixaMensagem.Mostrar(this, "Tem a certeza?", "Responder");
            if (SimNao == System.Windows.Forms.DialogResult.Yes)
            {
                timer1.Enabled = true;
                ButtonEscolhido = 1;
                button[ButtonEscolhido].BackColor = AlternativeColor;
            }
            else if (SimNao == System.Windows.Forms.DialogResult.OK)
            {
                menuPrincipal.Visible = true;
                this.Close();
            }
            caixaMensagem.btnYes.Visible = false;
            caixaMensagem.btnNo.Visible = false;
            caixaMensagem.btnOk.Visible = true; caixaMensagem.btnOk.Text = "OK";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            caixaMensagem.btnYes.Visible = true;
            caixaMensagem.btnNo.Visible = true;
            caixaMensagem.btnOk.Visible = true; caixaMensagem.btnOk.Text = "Desistir";
            DialogResult SimNao = caixaMensagem.Mostrar(this, "Tem a certeza?", "Responder");
            if (SimNao == System.Windows.Forms.DialogResult.Yes)
            {
                timer1.Enabled = true;
                ButtonEscolhido = 2;
                button[ButtonEscolhido].BackColor = AlternativeColor;
            }
            else if (SimNao == System.Windows.Forms.DialogResult.OK)
            {
                menuPrincipal.Visible = true;
                this.Close();
            }
            caixaMensagem.btnYes.Visible = false;
            caixaMensagem.btnNo.Visible = false;
            caixaMensagem.btnOk.Visible = true; caixaMensagem.btnOk.Text = "OK";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            caixaMensagem.btnYes.Visible = true;
            caixaMensagem.btnNo.Visible = true;
            caixaMensagem.btnOk.Visible = true; caixaMensagem.btnOk.Text = "Desistir";
            DialogResult SimNao = caixaMensagem.Mostrar(this, "Tem a certeza?", "Responder");
            if (SimNao == System.Windows.Forms.DialogResult.Yes)
            {
                timer1.Enabled = true;
                ButtonEscolhido = 3;
                button[ButtonEscolhido].BackColor = AlternativeColor;
            }
            else if (SimNao == System.Windows.Forms.DialogResult.OK)
            {
                menuPrincipal.Visible = true;
                this.Close();
            }
            caixaMensagem.btnYes.Visible = false;
            caixaMensagem.btnNo.Visible = false;
            caixaMensagem.btnOk.Visible = true; caixaMensagem.btnOk.Text = "OK";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Temporizador += 600;
            if (Temporizador >= 2100)
            {
                timer1.Enabled = false;
                Temporizador = 0;
                
            }

            Responder(ButtonEscolhido);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            if(ColorButtonEfect == 20){
                state = true;
            }else if(ColorButtonEfect == 220){
                state = false;
            }

            if (state)
            {
                ColorButtonEfect++;
            }
            else {
                ColorButtonEfect--;
            }

            button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(ColorButtonEfect)))), ((int)(((byte)(60)))));

            if (IsContraRelogio == true)
            {
                ContraRelogioTime++;
                if (ContraRelogioTime == 10)
                {
                    ContraRelogioSegundos--;
                    ContraRelogioTime = 0;
                    button5.Text = "Tempo Restante: " + ContraRelogioSegundos;
                    timer2.Enabled = ContraRelogioSegundos == 0 ? false : true;
                }

            }
    
            if(!timer2.Enabled){
                if(caixaMensagem.Aberto){
                    caixaMensagem.Close();
                    caixaMensagem = null;
                    caixaMensagem = new CaixaMensagem();
                }
                MudarCor(AlternativeColor);
                caixaMensagem.Mostrar(this, "Esgotou-se o tempo!", "Timeout");
                menuPrincipal.Visible = true;
                this.Close();
            }
        }

        void TelaContagem(int points) {
            Status.points = points;
            status.Visible = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            status.Close();
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Document.ResetJogo();
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            status.Location = this.Location;
            menuPrincipal.Location = this.Location;
            //winnerScreen.Location = this.Location();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            caixaMensagem.btnYes.Visible = true;
            caixaMensagem.btnNo.Visible = true;
            caixaMensagem.btnOk.Visible = false;
            DialogResult SimNao = caixaMensagem.Mostrar(this, "Tem a certeza que deseja desistir?", "Desistir");
            if (SimNao == System.Windows.Forms.DialogResult.Yes)
            {
                menuPrincipal.Visible = true;
                this.Close();
            }
            caixaMensagem.btnYes.Visible = false;
            caixaMensagem.btnNo.Visible = false;
            caixaMensagem.btnOk.Visible = true; caixaMensagem.btnOk.Text = "OK";
        }

    }
}
