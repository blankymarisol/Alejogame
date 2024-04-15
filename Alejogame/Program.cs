using Alejogame.Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejogame
{
    internal class Program
    {

        //declaramos jugadores
        static Jugador player1;
        static Jugador player2;
        static int numJuego = 0;
        static string flagR = "N";
        static int pos1, pos2;

        //declaramos el tablero
        static  Tablero tablero1 = new Tablero();

        //declaramos la tabla de ganadores
        static string[,] tablaPuntuacion = new string[5, 2];

        static void Main(string[] args)
        {
            //inicializamo la tabla de puntuacion vacia
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j <2; j++)
                {
                    tablaPuntuacion[i, j] = " ";
                }
            }

            int des = 0;
            while (des != 4)
            {
                Console.Clear();
                Console.WriteLine("Bienvenido al Alejogame :) ");
                Console.WriteLine(" 1) Jugar (RECUERDA QUE NO PUEDES JUGAR SIN ANTES REGISTRARTE)\n" +
                                  " 2) Registro\n" +
                                  " 3) Ver tabla de puntuacion\n" +
                                  " 4) Salir");
                try
                {
                    des = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Ingresa una opcion correcta");
                    Console.WriteLine("Mensaje de la excepcion: " + ex);
                    Console.ReadLine();
                }

                if (des == 1)
                {
                    if (flagR == "N")
                    {
                        Console.WriteLine("REGISTRATE PRIMERO BABOS@!!!");
                        Console.ReadLine();
                    }
                    else
                    {
                        int sig = 0;
                        while (sig != 2)
                        {
                            SeleccionTurno();
                            Console.Clear();
                            if (player1.Winner == true)
                            {
                                Console.WriteLine("El ganador es: {0}", player1.Nombre);
                                Console.ReadLine();
                                player1.Winner = false;
                            }
                            else if (player2.Winner == true)
                            {
                                Console.WriteLine("El ganador es: {0}", player2.Nombre);
                                Console.ReadLine();
                                player2.Winner = false;
                            }
                            Console.WriteLine("Nos tiramos otra partida? o tienes miedo JAJA\n" +
                                              "1) YES en ingles\n" +
                                              "2) Nel\n");
                            try
                            {
                                sig = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine("Ingresa una opcion correcta");
                                Console.WriteLine("Mensaje de la excepcion: " + ex);
                                Console.ReadLine();
                            }
                            tablero1.ResetTablero();
                        }
                    }
                }
                else if (des == 2)
                {
                    Registro();
                    flagR = "S";
                }
                else if (des == 3)
                {
                    TablaGanadores();
                    Console.ReadLine();
                }
                else if (des == 4)
                {
                    Goodbye();
                    Console.ReadLine();
                }
            }
            static void Registro()
            {
                Console.WriteLine("Ingrese el nombre del jugador 1");
                string jugador1 = Console.ReadLine();
                Console.WriteLine("Ingrese el nombre del jugador 2");
                string jugador2 = Console.ReadLine();

                player1 = new Jugador(jugador1);
                player2 = new Jugador(jugador2);
            }

            static void SeleccionTurno()
            {
                Console.Clear();
                Console.WriteLine("El turno del primer jugador se realizara de manera aleatoria SUERTE!");
                Console.WriteLine("Presona enter para continuar porfis");
                Console.ReadLine();
                Random num = new Random();
                int turno = num.Next(1, 3);
                if (turno == 1)
                {
                    Console.WriteLine("Comienza {0}", player1.Nombre);
                    Console.ReadLine();
                    Jugar(ref player1, ref player2);
                }
                else if (turno == 2)
                {
                    Console.WriteLine("Comienza {0}", player2.Nombre);
                    Console.ReadLine();
                    Jugar(ref player2, ref player1);
                }
            }

            static void Jugar(ref Jugador gamer1, ref Jugador gamer2)
            {
                bool AcabarJuego = false;
                int contador = 0;
                do
                {
                    //turno del primer jugador
                    Console.Clear();
                    tablero1.GenerarTableroDef();
                    Console.WriteLine("Selecciona la posicion en la que desea tirar {0} ", gamer1.Nombre);
                    try
                    {
                        pos1 = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Ingresa un numero de casilla");
                        Console.WriteLine("Mensaje de la excepcion: " + ex);
                        Console.ReadLine();
                        pos1 = 0;
                    }
                    tablero1.TirarTableroX(pos1);
                    Console.Clear();
                    tablero1.GenerarTableroDef();

                    if (tablero1.Revision() == true)
                    {
                        gamer1.Winner = true;
                        tablaPuntuacion[numJuego, 0] = gamer1.Nombre;
                        tablaPuntuacion[numJuego, 1] = gamer2.Nombre;
                        numJuego++;
                        break;
                    }
                    contador++;

                    if (contador == 9)
                    {
                        Console.WriteLine("Empate");
                        Console.ReadLine();
                        tablaPuntuacion[numJuego, 0] = "EMPATE";
                        tablaPuntuacion[numJuego, 1] = "EMPATE";
                        numJuego++;
                        break;
                    }

                    //turno del segundo jugador
                    Console.Clear();
                    tablero1.GenerarTableroDef();
                    Console.WriteLine("Selecciona la posicion en la que desea tirar {0} ", gamer2.Nombre);
                    try
                    {
                        pos2 = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Ingresa un numero de casilla");
                        Console.WriteLine("Mensaje de la excepcion: " + ex);
                        Console.ReadLine();
                        pos2 = 0;
                    }
                    tablero1.TirarTableroO(pos2);
                    Console.Clear();
                    tablero1.GenerarTableroDef();

                    if (tablero1.Revision() == true)
                    {
                        gamer2.Winner = true;
                        tablaPuntuacion[numJuego, 1] = gamer2.Nombre;
                        tablaPuntuacion[numJuego, 0] = gamer1.Nombre;
                        numJuego++;
                        break;
                    }
                    contador++;

                    if (contador == 9)
                    {
                        Console.WriteLine("Empate");
                        Console.ReadLine();
                        tablaPuntuacion[numJuego, 0] = "EMPATE";
                        tablaPuntuacion[numJuego, 1] = "EMPATE";
                        numJuego++;
                        break;
                    }
                }
                while (AcabarJuego != true);
            }

            static void TablaGanadores()
            {
                Console.WriteLine("|JUEGO||GANADOR||PERDEDOR|\n" +
                                  "|  1  ||{0}    ||{1}     |\n" +
                                  "|  2  ||{2}    ||{3}     |\n" +
                                  "|  3  ||{4}    ||{5}     |\n" +
                                  "|  4  ||{6}    ||{7}     |\n" +
                                  "|  5  ||{8}    ||{9}     |\n",
                                  tablaPuntuacion[0, 0], tablaPuntuacion[0, 1],
                                  tablaPuntuacion[1, 0], tablaPuntuacion[1, 1],
                                  tablaPuntuacion[2, 0], tablaPuntuacion[2, 1],
                                  tablaPuntuacion[3, 0], tablaPuntuacion[3, 1],
                                  tablaPuntuacion[4, 0], tablaPuntuacion[4, 1]);
            }

            static void Goodbye()
            {
                Console.Clear();
                Console.WriteLine("Gracias por jugar, tqm <3");
            }

        }

    }
}