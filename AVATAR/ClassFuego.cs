using System;

namespace AVATAR
{
    public class personajeFuego : Personaje
    {
        public personajeFuego(string nombre, string elemento, float vida, float ataque, float defensa, int energia, int empatia, bool habilidadActiva, int cargaHabilidad)
            : base(nombre, elemento, vida, ataque, defensa, energia, empatia, habilidadActiva, cargaHabilidad)
        {
        }

        public override void Atacar()
        {
            Console.WriteLine(Nombre + " ejecuta un ataque feroz de fuego.");
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
}