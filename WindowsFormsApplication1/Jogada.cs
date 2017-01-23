using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
   
    public class Jogada
    {
        int numeroJogada;
        int jogador;
        public enum Player {x=1, bolinha=2}
        
        public int NumeroJogada
        {
            get
            {
                return numeroJogada;
            }

            set
            {
                numeroJogada = value;
            }
        }

        public int Jogador
        {
            get
            {
                return jogador;
            }

            set
            {
                jogador = value;
            }
        }

        public Jogada(int numJogada)
        {
            this.NumeroJogada = numJogada;
            
        }

        public Jogada(int numeroJogada, int jogador)
        {
            this.NumeroJogada = numeroJogada;
            this.Jogador = jogador;
        }
    }
}
