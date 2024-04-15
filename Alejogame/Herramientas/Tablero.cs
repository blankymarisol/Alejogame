using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejogame.Herramientas
{
    internal class Tablero
    {
        private static string[,] tableroG = { { "1", "2", "3" },
                                              { "4", "5", "6" },
                                              { "7", "8", "9" }};
        private static string equis = "x";
        private static string circulo = "o";

        public  Tablero()
        {
            //Constructor vacio 
        }

        public void GenerarTableroDef()
        {
            Console.WriteLine("\n  {0}  ||  {1}  ||  {2}" +
                              "\n=====  =====  =====" +
                              "\n  {3}  ||  {4}  ||  {5}" +
                              "\n=====  =====  =====" +
                              "\n  {6}  ||  {7}  ||  {8}", tableroG[0, 0], tableroG[0, 1],
                              tableroG[0, 2], tableroG[1, 0], tableroG[1, 1], tableroG[1, 2],
                              tableroG[2, 0], tableroG[2, 1], tableroG[2, 2]);
        }
        

        public void TirarTableroX(int pos)
        {
            if (pos == 0)
            {
                return;
            }
            switch (pos)
            {
                case 1:
                    tableroG[0, 0] = equis;
                    break;
                case 2:
                    tableroG[0, 1] = equis;
                    break;
                case 3:
                    tableroG[0, 2] = equis;
                    break;
                case 4:
                    tableroG[1, 0] = equis;
                    break;
                case 5:
                    tableroG[1, 1] = equis;
                    break;
                case 6:
                    tableroG[1, 2] = equis;
                    break;
                case 7:
                    tableroG[2, 0] = equis;
                    break;
                case 8:
                    tableroG[2, 1] = equis;
                    break;
                case 9:
                    tableroG[2, 2] = equis;
                    break;
            }
        }

        public void TirarTableroO(int pos2)
        {
            if (pos2 == 0)
            {
                return;
            }
            switch (pos2)
            {
                case 1:
                    tableroG[0, 0] = circulo;
                    break;
                case 2:
                    tableroG[0, 1] = circulo;
                    break;
                case 3:
                    tableroG[0, 2] = circulo;
                    break;
                case 4:
                    tableroG[1, 0] = circulo;
                    break;
                case 5:
                    tableroG[1, 1] = circulo;
                    break;
                case 6:
                    tableroG[1, 2] = circulo;
                    break;
                case 7:
                    tableroG[2, 0] = circulo;
                    break;
                case 8:
                    tableroG[2, 1] = circulo;
                    break;
                case 9:
                    tableroG[2, 2] = circulo;
                    break;
            }
        }

        public bool Revision()
        {
            //linea horizontal
            for (int i = 0; i < 3; i++)
            {
                if (tableroG[0, i] == tableroG[1, i] && tableroG[1, i] == tableroG[2, i])
                {
                    return true;
                }
            }

            //linea vertical 
            for (int i = 0; i < 3; i++)
            {
                if (tableroG[i, 0] == tableroG[i, 1] && tableroG[i, 1] == tableroG[i, 2])
                {
                    return true;
                }
            }

            //linea diagonal
            if (tableroG[0, 0] == tableroG[1, 1] && tableroG[1, 1] == tableroG[2, 2])
            {
                return true;
            }

            if (tableroG[2, 0] == tableroG[1, 1] && tableroG[1, 1] == tableroG[0, 2]){
                return true;
            }

            //Sin linea
            return false;
        }
        public void ResetTablero()
        {
            tableroG[0, 0] = "1";
            tableroG[0, 1] = "2";
            tableroG[0, 2] = "3";
            tableroG[1, 0] = "4";
            tableroG[1, 1] = "5";
            tableroG[1, 2] = "6";
            tableroG[2, 0] = "7";
            tableroG[2, 1] = "8";
            tableroG[2, 2] = "9";
        }
    }
}
