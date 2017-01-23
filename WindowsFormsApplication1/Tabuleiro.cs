using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Tabuleiro
    {
        public Byte[] casa = new Byte[10];
        public List<object[]> sequencias;
        
        public Tabuleiro()
        {
            ResetaSequencias();
            
        }
        public byte FechouSequencia()
        {
            //Parei aqui
            for(int i=0;i<sequencias.Count;i++)
            {
               if(sequencias[i].LongCount(x=>x.ToString()=="o")==3)
               {
                    return 0;
               }
               else if(sequencias[i].LongCount(x => x.ToString() =="x") == 3)
                {
                    return 1;

                }

            }
            return 3;

        }
        public bool Jogar(Jogada jogada)
        {
            if (jogada.NumeroJogada == -1) return false;
            if(casa[Byte.Parse(jogada.NumeroJogada.ToString())]>0)
            {
                return false;

            }
            else
            {
                casa[byte.Parse(jogada.NumeroJogada.ToString())] = byte.Parse(jogada.Jogador.ToString());
                for (int i=0;i<sequencias.Count;i++)
                {
                    for(int it=0;it<3;it++)
                    {
                        if(sequencias[i][it].ToString()==jogada.NumeroJogada.ToString())
                        {
                            sequencias[i][it] = (jogada.Jogador==1 ? "x" : "o");

                        }
                        
                    }
                    
                }



            }
            
            
            return true;
        }
        public Byte[] GetJogadasDisponíveis()
        {
            List<byte> listaJogadas = new List<byte>();
            for(int i=0;i<casa.Length;i++)
            {
                if (casa[i] > 0)
                    listaJogadas.Add(casa[i]);

            }
            return listaJogadas.ToArray();

        }
        public void Reset()
        {
            casa = new Byte[10];
            ResetaSequencias();            
        }
        protected void ResetaSequencias()
        {
            sequencias = new List<object[]>();
            sequencias.Add(new object[] { 1, 2, 3 });
            sequencias.Add(new object[] { 4, 5, 6 });
            sequencias.Add(new object[] { 7, 8, 9 });
            sequencias.Add(new object[] { 1, 4, 7 });
            sequencias.Add(new object[] { 2, 5, 8 });
            sequencias.Add(new object[] { 3, 6, 9 });
            sequencias.Add(new object[] { 1, 5, 9 });
            sequencias.Add(new object[] { 3, 5, 7 });

        }





    }
}
