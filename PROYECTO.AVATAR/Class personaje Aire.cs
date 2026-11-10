using System;

namespace AVATAR
{
    public class personajeAire : Personaje 
    {
        // Constructor 
        
        public personajeAire(string nombre, string elemento, float vida, float ataque, float defensa, int energia) 
            : base(nombre, elemento, vida, ataque, defensa, energia)
        {
        }

        // Método heredado.
        
        public override void Atacar()
        {
            Console.WriteLine(Nombre + " ejecuta un ataque rápido de aire.");
        }

        // Tu método para la habilidad especial
        public void HabilidadEspecial()
        {
            int costohabilidad = 2;

            if (Energia >= costohabilidad)
            {
                Energia = Energia - costohabilidad;
                
                Console.WriteLine(Nombre + " usó su habilidad especial de aire.");
            }
            else
            {
                Console.WriteLine("No tienes suficiente energía para la habilidad especial.");
            }
        }
    }
}
