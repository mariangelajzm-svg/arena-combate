using System;
using System.Collections.Generic;

namespace AVATAR
{
    public class Personaje
    {
        private string nombre;
        private string elemento;
        private int hp;
        private int atk;
        private int def;
        private int energia;
        

        public Personaje(string nombre, string elemento, int hp, int atk, int def, int energia)
        {
            this.nombre = nombre;
            this.elemento = elemento;
            this.hp = hp;
            this.atk = atk;
            this.def = def;
            this.energia = energia;
            
        }

        // ENCAPSULAMIENTO
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Elemento { get { return elemento; } set { elemento = value; } }
        public int Hp { get { return hp; } set { hp = value; } }
        public int Atk { get { return atk; } set { atk = value; } }
        public int Def { get { return def; } set { def = value; } }
        public int Energia { get { return energia; } set { energia = value; } }
        

        // Método virtual para el polimorfismo
        public virtual void Atacar()
        {
            Console.WriteLine(nombre + "realiza un ataque básico.");
        }
    }
}