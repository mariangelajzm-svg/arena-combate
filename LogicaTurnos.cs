using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AVATAR
{
    public partial class MainForm : Form
    {
        private int turnoActual = 1;
        private int jugadorActivo = 1;
        private int energiaJugador1 = 2;
        private int energiaJugador2 = 2;
        private int tiempoRestanteTurno = 30;
        
        
       // Relevo de personajes
        private Queue<Personaje> colaRelevosJ1 = new Queue<Personaje>();
        private Queue<Personaje> colaRelevosJ2 = new Queue<Personaje>();
        
        // Historial de efectos
        private Stack<string> pilaHistorialEfectos = new Stack<string>();

        public MainForm()
        {
            InitializeComponent();
        }

        public void InicializarEquipos(List<Personaje> equipoJ1, List<Personaje> equipoJ2)
        {
            colaRelevosJ1.Clear();
            colaRelevosJ2.Clear();

            foreach (var p in equipoJ1)
            {
                colaRelevosJ1.Enqueue(p);
            }

            foreach (var p in equipoJ2)
            {
                colaRelevosJ2.Enqueue(p);
            }
            
            RegistrarEfecto("Partida iniciada: Equipos cargados en las colas.");
            ActualizarInterfazCombate();
        }   

        public void PasarTurno()
        {
            if (jugadorActivo == 1)
            {
                jugadorActivo = 2;
                energiaJugador2 += 1;
                RegistrarEfecto("Fin turno J1. Inicia turno J2 (Energía J2 +1).");
            } 
            else 
            {
                jugadorActivo = 1;
                energiaJugador1 += 1;
                turnoActual++;
                RegistrarEfecto("Fin turno J2. Inicia Ronda " + turnoActual + " (Energía J1 +1).");
            }

            ReiniciarTemporizador();
            ActualizarInterfazCombate();
        }

        private void ReiniciarTemporizador()
        {
            tiempoRestanteTurno = 30;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tiempoRestanteTurno--;

            if (tiempoRestanteTurno <= 0)
            {
                PasarTurno();
                MessageBox.Show("¡El tiempo del turno se ha agotado! Cambio de turno automático.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        public bool ejecutarAtaque(int costoEnergia)
        {
            if (jugadorActivo == 1)
            {
                if (energiaJugador1 >= costoEnergia)
                {
                    energiaJugador1 -= costoEnergia;
                    RegistrarEfecto("Jugador 1 atacó consumiendo " + costoEnergia + " de energía.");
                    ActualizarInterfazCombate(); 
                    return true;
                }
            }
            else 
            {
                if (energiaJugador2 >= costoEnergia)
                {
                    energiaJugador2 -= costoEnergia;
                    RegistrarEfecto("Jugador 2 atacó consumiendo " + costoEnergia + " de energía.");
                    ActualizarInterfazCombate(); 
                    return true;
                }
            }

            MessageBox.Show("¡Energía insuficiente para realizar esta acción!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        
        private void ActualizarInterfazCombate()
        {
            lblTurno.Text = "Turno: " + turnoActual + " | Jugador Activo: J" + jugadorActivo;

            lblEnergiaJ1.Text = "Energía J1: " + energiaJugador1;
            lblEnergiaJ2.Text = "Energía J2: " + energiaJugador2;

            lblTiempo.Text = "Tiempo: " + tiempoRestanteTurno + "s";

            if (colaRelevosJ1.Count > 0)
            {
                Personaje p1 = colaRelevosJ1.Peek();
                lblPersonajeJ1.Text = p1.Nombre + " (HP: " + p1.Vida + ")";
            }

            if (colaRelevosJ2.Count > 0)
            {
                Personaje p2 = colaRelevosJ2.Peek();
                lblPersonajeJ2.Text = p2.Nombre + " (HP: " + p2.Vida + ")";
            }
        }

        public void RealizarRelevoJugador1()
        {
            if (colaRelevosJ1.Count > 1)
            {
                Personaje actual = colaRelevosJ1.Dequeue();
                colaRelevosJ1.Enqueue(actual);
                
                Personaje nuevo = colaRelevosJ1.Peek();
                MessageBox.Show("¡Relevo realizado! Entra en combate: " + nuevo.Nombre);
                RegistrarEfecto("J1 realizó relevo: ahora combate " + nuevo.Nombre);
                
                ActualizarInterfazCombate(); 
            }
        }
        
        public void RealizarRelevoJugador2()
        {
            if (colaRelevosJ2.Count > 1)
            {
                Personaje actual = colaRelevosJ2.Dequeue();
                colaRelevosJ2.Enqueue(actual);
                
                Personaje nuevo = colaRelevosJ2.Peek();
                MessageBox.Show("¡Relevo realizado! Entra en combate: " + nuevo.Nombre);
                RegistrarEfecto("J2 realizó relevo: ahora combate " + nuevo.Nombre);
                
                ActualizarInterfazCombate();
            }
        }

        
        // MÉTODOS DE LA PILA (STACK) PARA EL HISTORIAL
        
        public void RegistrarEfecto(string descripcion)
        {
            pilaHistorialEfectos.Push(descripcion); 
        }

        public void VerUltimoEfecto()
        {
            if (pilaHistorialEfectos.Count > 0)
            {
                MessageBox.Show("Último evento en la Pila:\n" + pilaHistorialEfectos.Peek(), "Historial (Stack)");
            }
            else
            {
                MessageBox.Show("El historial está vacío.", "Aviso");
            }
        }

        public void DeshacerUltimoEfecto()
        {
            if (pilaHistorialEfectos.Count > 0)
            {
                string efectoRemovido = pilaHistorialEfectos.Pop(); 
                MessageBox.Show("Se ha deshecho la acción:\n" + efectoRemovido, "Pila (Pop)");
            }
            else
            {
                MessageBox.Show("No hay acciones recientes que deshacer.", "Aviso");
            }
        }
    }
}