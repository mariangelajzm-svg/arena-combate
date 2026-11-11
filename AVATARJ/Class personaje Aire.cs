using System;

namespace AVATAR
{
    public class personajeAire : Personaje
    {
        public personajeAire(string nombre, string elemento, float vida, float ataque, float defensa, int energia, int empatia, bool habilidadActiva, int cargaHabilidad)
            : base(nombre, elemento, vida, ataque, defensa, energia, empatia, habilidadActiva, cargaHabilidad)
        {
        }

        public override void Atacar()
        {
            Console.WriteLine(Nombre + " ejecuta un ataque rápido de aire.");
        }

        public void HabilidadEspecial()
        {
            int costoHabilidad = 2;

            if (Energia >= costoHabilidad)
            {
                Energia -= costoHabilidad;
                HabilidadActiva = true;
            }
        }
    }