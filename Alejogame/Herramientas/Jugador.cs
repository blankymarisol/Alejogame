using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejogame.Herramientas
{
    internal class Jugador
    {
        string nombre;
        int racha = -1;
        bool winner = false;
        int empates = 0;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Racha { get => racha; set => racha = value; }
        public bool Winner { get => winner; set => winner = value; }
        public int Empates { get => empates; set => empates = value; }

        public Jugador(string nombreJ)
        {
            nombre = nombreJ;
            racha = 0;
        }
    }
    
}
