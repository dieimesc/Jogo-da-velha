using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmMain : Form
    {
        Tabuleiro tabuleiro = new Tabuleiro();
        bool versusPc = true;
        Computador pc = new Computador(2);
        public frmMain()
        {
            InitializeComponent();
            

        }
        protected bool MarcarJogada(int jogada)
        {
            foreach (Control control in this.Controls)
            {
                if(control.GetType()==typeof(Button)  && control.Tag.ToString()==jogada.ToString())
                {
                    Bitmap imagem = new Bitmap
                        ( "img\\" + (rdPlayer1.Checked ? "x.png" : "o.png"));
                    
                    ((Button)control).BackgroundImage = imagem;
                    
                    
                }


            }

            return true;
        }
        protected void VerificaJogada(int jogada)
        {
            Jogada jog = new Jogada(jogada, 
                (rdPlayer1.Checked 
                 ? int.Parse(rdPlayer1.Tag.ToString())
                 : int.Parse(rdPlayer2.Tag.ToString())));
            if(tabuleiro.Jogar(jog))
            {
                if (MarcarJogada(jog.NumeroJogada))
                {
                    if (!versusPc)
                    { 
                        if (jog.Jogador == 1)
                        {
                            rdPlayer2.Checked = true;
                            rdPlayer1.Checked = false;

                        }
                        else
                        {
                            rdPlayer2.Checked = false;
                            rdPlayer1.Checked = true;

                        }
                    }

                }
                System.Media.SystemSounds.Asterisk.Play();

            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
                return;

            }
            VerificaVitoria();
            if(versusPc)
            {
                pc.Started = true;
                int jogadaPc=pc.Jogar(jog.NumeroJogada, tabuleiro.sequencias,tabuleiro.casa);
                jog.Jogador = 2;
                jog.NumeroJogada = jogadaPc;
                if(!tabuleiro.Jogar(jog)) Finaliza();
                foreach(Control c in this.Controls)
                {
                    if(c.GetType()==typeof(Button) && c.Tag.ToString()==jogadaPc.ToString())
                    {
                        Bitmap imagem = new Bitmap
                        ("img\\" + (pc._jogador=="x" ? "x.png" : "o.png"));

                        ((Button)c).BackgroundImage = imagem;

                    }

                }


            }
            VerificaVitoria();

        }
        protected void Finaliza()
        {
            MessageBox.Show("Fim de jogo - Empate");
            NovoJogo();


        }
        protected void VerificaVitoria()
        {
            if (tabuleiro.FechouSequencia() == 0)
            {
                MessageBox.Show("Vitória da Bolinha");
                NovoJogo();

            }
            if (tabuleiro.FechouSequencia() == 1)
            {
                MessageBox.Show("Vitória do X");
                NovoJogo();

            }
            if(tabuleiro.GetJogadasDisponíveis().Length==0)
            {
                //MessageBox.Show("Fim de jogo - Empate");
                NovoJogo();
                return;

            }

            

        }
        protected void NovoJogo()
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(Button) && control.Tag.ToString().Length>0)
                {
                    Bitmap imagem = null;

                    ((Button)control).BackgroundImage = imagem;


                }


            }
            pc.Started = false;
            tabuleiro.Reset();

        }
       

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            VerificaJogada(int.Parse(((Button)sender).Tag.ToString()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerificaJogada(int.Parse(((Button)sender).Tag.ToString()));
        }

        private void jogadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            versusPc = true;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            versusPc = false;
        }

        private void frmMain_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void frmMain_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            VerificaJogada(int.Parse(((Button)sender).Tag.ToString()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerificaJogada(int.Parse(((Button)sender).Tag.ToString()));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            VerificaJogada(int.Parse(((Button)sender).Tag.ToString()));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VerificaJogada(int.Parse(((Button)sender).Tag.ToString()));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            VerificaJogada(int.Parse(((Button)sender).Tag.ToString()));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            VerificaJogada(int.Parse(((Button)sender).Tag.ToString()));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            VerificaJogada(int.Parse(((Button)sender).Tag.ToString()));
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Jogada jog = new Jogada(3);
            versusPc = true;
            pc.VersusPc = true;
            int jogadaPc = pc.Jogar(jog.NumeroJogada, tabuleiro.sequencias, tabuleiro.casa);
            pc.Started = true;
            jog.Jogador = 2;
            jog.NumeroJogada = jogadaPc;
            if (!tabuleiro.Jogar(jog)) Finaliza();
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(Button) && c.Tag.ToString() == jogadaPc.ToString())
                {
                    Bitmap imagem = new Bitmap
                    ("img\\" + (pc._jogador == "x" ? "x.png" : "o.png"));

                    ((Button)c).BackgroundImage = imagem;

                }

            }
        }
    }
}
