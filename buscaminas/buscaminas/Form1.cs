using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buscaminas
{





    public partial class Form1 : Form
    {
        int[] mapa = new int[190];
        int[,] espacio = new int[19, 10];
        int[] casillas_vacias = new int[]
                                    {1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                     11, 12, 13, 14, 15, 16, 17, 18,
                                     19, 20, 21, 22, 23, 24, 25, 26,
                                     27, 28, 29, 30, 31, 32, 33, 34,
                                     35, 36, 37, 38, 39, 40, 41, 42,
                                     43, 44, 45, 46, 47, 48, 49, 50,
                                     51, 52, 53, 54, 55, 56, 57, 58,
                                     59, 60, 61, 62, 63, 64, 65, 66,
                                     67, 68, 69, 70, 71, 72, 73, 74,
                                     75, 76, 77, 78, 79, 80, 81, 82,
                                     83, 84, 85, 86, 87, 88, 89, 90,
                                     91, 92, 93, 94, 95, 96, 97, 98, 99,111, 112, 113, 114, 115, 116, 117,
                                     131, 132, 133, 134, 135,151,152,153,171};
        int[] casillas_minas = new int[30];
        public void cargar()
        {
            Random r = new Random();
            for( int i=1;i<espacio.GetLength(1);i++)
            {
                for (int j = 1; j < espacio.GetLength(1); j++)
                {
                    espacio[i, j] = 0;
                }
                }
            for(int i=1; i<mapa.Length;i++)
            {
                List<int> lista = null;
                lista = recuperarCoordenadas(1);
                espacio[lista[1], lista[0]] = 0;
                mapa[i] = 0;
                Button boton = (Button)this.Controls.Find("button" + i, false)[0];
                boton.Text = "" + i;
                if (casillas_vacias.Contains(i)==true)
                {
                    boton.ForeColor = Color.RoyalBlue;
                    boton.BackColor = Color.RoyalBlue;
                }
                else
                {
                    boton.ForeColor = Color.OrangeRed;
                    boton.BackColor = Color.OrangeRed;
                }
            }
            int indice = 0;
            while (indice<30)
            {
                int contador_minas = 0;
                int mina = r.Next(1,191);
                bool es_vacia = casillas_vacias.Contains(mina);
                if (es_vacia==false)
                {
                    bool es_mina = casillas_minas.Contains(mina);
                    if(es_mina==false)
                    {
                        List<int> lista = recuperarCoordenadas(mina);
                        int y = lista[0];
                        int x = lista[1];
                        espacio[x, y] = 9;
                        mapa[mina] = 9;
                        casillas_minas[indice] = mina;

                        for (int j=0; j<espacio.GetLength(1);j++)
                        {
                            for(int i=0;i<espacio.GetLength(0);i++)
                            {
                                if(espacio[i,j]==9)
                                {
                                    contador_minas++;
                                }
                            }
                        }
                    }
                }
            }
        }
     
         public List<int> recuperarCoordenadas(int num)
        {
            int pos = 0;
            List<int> resultado = new List<int>();
            {
                for(int i=0;i< espacio.GetLength(1);i++)
                {
                    for(int j=0; j<espacio.GetLength(0);j++)
                    { 
                    if(pos==num-1)
                    {
                        resultado.Add(i);
                        resultado.Add(j);
                    }
                    else
                    {
                        pos++;
                    }
                }
            }
            return resultado;
          }
            }         
        public void DescubrirArea(int x,int y,int i)
        {
            Button boton = (Button)this.Controls.Find("button" + i, false)[0];
            if(boton.ForeColor==Color.OrangeRed )
            {
                boton.BackColor = Color.DarkGray;
                boton.ForeColor = Color.Black;
                boton.Text = "" + espacio[x, y];
                if (espacio[x, y]== 0);
                {
                    for(int f2=Math.Max(0,x-1);f2<Math.Min(19,x+2);f2++)
                    {
                        for(int c2=Math.Max(0,y+1);c2<Math.Min(10,y+2);c2++)
                        {
                            int nboton = recuperarNboton(f2, c2);
                            DescubrirArea(f2, c2, nboton);
                        }
                    }
                }
            }
        }
        private int recuperarNboton(int x, int y)
        {
            int pos = 0;
            int[,] eaux = new int[19, 10];
            for(int i=0;i<eaux.GetLength(1);i++)
            {
                for (int j = 0; j < eaux.GetLength(1); j++)
                {
                    eaux[i, j] = 0;
                }
               }
            eaux[x, y] = 1;
            for(int j=0;j<eaux.GetLength(1);j++)
            {
                for (int i = 0; i < eaux.GetLength(0); i++)
                {
                    if(eaux[i,j]==1)
                    {
                        j = 100;
                        i = 100;

                    }
                    else
                    {
                        pos = pos + 1;
                    }
                    if(i==19)
                    {
                        i++;
                    }
                }
                if (j == 10)
                {
                    j++;
                }
            }
            return pos;
        }

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }

       
    }
}
