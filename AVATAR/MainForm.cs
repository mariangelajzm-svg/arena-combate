using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace AVATAR
{
    public partial class MainForm : Form
    {
        // Declaración de listas globales para el proyecto
        public List<Personaje> ListaGeneral = new List<Personaje>();
        public List<personajeAire> ListaAire = new List<personajeAire>();
        public List<personajeAgua> ListaAgua = new List<personajeAgua>();
        public List<personajeTierra> ListaTierra = new List<personajeTierra>();
        public List<personajeFuego> ListaFuego = new List<personajeFuego>();

        public MainForm()
        {
            InitializeComponent();

            // Instanciación de personajes
            personajeAire Aang = new personajeAire("Aang", "Aire", 120, 20, 15, 100);
            personajeAgua Katara = new personajeAgua("Katara", "Agua", 100, 15, 12, 120);
            personajeTierra Toph = new personajeTierra("Toph", "Tierra", 160, 12, 30, 80);
            personajeFuego Zuko = new personajeFuego("Zuko", "Fuego", 90, 32, 10, 90);

            // Registro en listas correspondientes
            ListaAire.Add(Aang);
            ListaAgua.Add(Katara);
            ListaTierra.Add(Toph);
            ListaFuego.Add(Zuko);

            ListaGeneral.Add(Aang);
            ListaGeneral.Add(Katara);
            ListaGeneral.Add(Toph);
            ListaGeneral.Add(Zuko);
        }
    }
}


	      	                                    	
	
	

	

	                                     	


