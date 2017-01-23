﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Computador
    {
        public string _jogador;
        public string _adversario;
        public bool VersusPc;
        public bool Started;
        public Computador(int jogador)
        {
            _jogador = (jogador==1 ? "x" : "o");
            _adversario = (jogador != 1 ? "x" : "o");

        }

        public int Jogar(int jogada,List<object[]> sequencias, byte[] casas)
        {
            int player = _jogador == "x" ? 1 : 2;

            if (!this.Started)
            {
                Byte[] bytes = { 1, 3, 5, 7, 9 };
                Random _randon = new Random();
                while(true)
                {
                    int _jog = (int)_randon.Next(9);
                    if (bytes.Contains((byte)_jog)) return _jog;
                }               
                
            }
            if ((sequencias[2][1].ToString() == _adversario &&
                sequencias[5][1].ToString() == _adversario &&
                Char.IsNumber(Convert.ToChar(sequencias[2][2].ToString()))) ||
                (sequencias[5][1].ToString() == _adversario &&
                 sequencias[3][2].ToString() == _adversario &&
                 Char.IsNumber(Convert.ToChar(sequencias[2][2].ToString()))) ||
                  (sequencias[5][1].ToString() == _adversario &&
                 sequencias[0][2].ToString() == _adversario &&
                 Char.IsNumber(Convert.ToChar(sequencias[2][2].ToString())))
                 )



                return 9;

            //Verifica a possibilidade de vitória ou derrota imediata, 
            //efetuando ou evitando, respectivamente
            int[] cantos = new int[4] { 1, 3, 7, 9 };
            bool continuaAnalise = false;
            if (casas[5] == 0)

            {
                for (int i = 0; i < sequencias.Count; i++)
                {
                    if (sequencias[i].LongCount(x => x.ToString() == _adversario.ToString()) == 2)
                    {
                        continuaAnalise = true;
                        break;

                    }
                        
                    else { continue; }

                }
                if (!continuaAnalise) return 5;
            }
                

            for (int i = 0; i < sequencias.Count; i++)
            {
                //Efetua vitória
                if (sequencias[i].LongCount(x => x.ToString() == _jogador.ToString()) == 2
                    && sequencias[i].LongCount(x => Char.IsNumber(Convert.ToChar(x.ToString())))==1)
                {
                    //Parei aqui
                    return int.Parse(sequencias[i].First(x => x.ToString() != "o" && x.ToString() != "x").ToString());
                }
            }
            for (int i = 0; i < sequencias.Count; i++)
            { 
                //Evita derrota
                if (sequencias[i].LongCount(x => x.ToString() == _adversario.ToString())==2 &&
                    sequencias[i].LongCount(x => x.ToString() == _jogador.ToString()) == 0)
                {
                    if(sequencias[i].LongCount(x=>x.ToString()!=_adversario && x.ToString()!=_jogador)>0)
                        return int.Parse(sequencias[i].First(x => x.ToString() != "o" && x.ToString() != "x").ToString());
                }
               
                
            }
            //Avalia a possibilidade de duplo ataque, por parte do adversário

            //Tenta jogar impar(a melhor escolha)
            for (int i = 0; i < sequencias.Count; i++)
            {

                for (int it = 0; it < sequencias[i].ToList().Count; it++)
                {
                    if (sequencias[i][it].ToString() != "x" && sequencias[i][it].ToString() != "o" &&
                        (int.Parse(sequencias[i][it].ToString()) % 2 > 0)/* &&
                        sequencias[6].LongCount(x => Char.IsNumber(Convert.ToChar(x.ToString()))) > 0 &&
                        sequencias[7].LongCount(x => Char.IsNumber(Convert.ToChar(x.ToString()))) > 0*/)
                    {
                        return int.Parse(sequencias[i][it].ToString());

                    }

                }

            }
            //Se não der

            for (int i = 0; i < sequencias.Count; i++)
            {

                for (int it = 0; it < sequencias[i].ToList().Count; it++)
                {
                    if (sequencias[i][it].ToString() != "x" && sequencias[i][it].ToString() != "o")
                    {
                        return int.Parse(sequencias[i][it].ToString());

                    }

                }

            }

            return -1;

        }
        protected int JogarImpar(List<object[]> sequencias)
        {
            //Tenta jogar impar(a melhor escolha)
            for (int i = 0; i < sequencias.Count; i++)
            {

                for (int it = 0; it < sequencias[i].ToList().Count; it++)
                {
                    if (sequencias[i][it].ToString() != "x" && sequencias[i][it].ToString() != "o" &&
                        (int.Parse(sequencias[i][it].ToString()) % 2 > 0) &&
                        sequencias[6].LongCount(x => Char.IsNumber(Convert.ToChar(x.ToString()))) > 0 &&
                        sequencias[7].LongCount(x => Char.IsNumber(Convert.ToChar(x.ToString()))) > 0)
                    {
                        return int.Parse(sequencias[i][it].ToString());

                    }

                }

            }

            return -1;


        }
        



    }
}
