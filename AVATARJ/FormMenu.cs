using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace AVATAR
{

	public class FormMenu: Form
	{
	
	private Button btnIniciarCombate;
	private Label lblTitulo;
	
	
	public FormMenu()
	{
	
	
	this.Text = "AVATAR - Menú Principal";
	this.Width = 450;
	this.Height = 300;
	this.StartPosition = FormStartPosition.CenterScreen;
	
	
	
	// Título
	
	lblTitulo = new Label();
    lblTitulo.Text = "ARENA ELEMENTAL: AVATAR";
    lblTitulo.Font = new Font("Arial", 14, FontStyle.Bold);
    lblTitulo.AutoSize = true;
    lblTitulo.Left = 85;
    lblTitulo.Top = 50;
    this.Controls.Add(lblTitulo);

     // Botón de inicio
     btnIniciarCombate = new Button();
     btnIniciarCombate.Text = "Iniciar Arena de Combate";
     btnIniciarCombate.Font = new Font("Arial", 10, FontStyle.Bold);
     btnIniciarCombate.Width = 220;
     btnIniciarCombate.Height = 50;
     btnIniciarCombate.Left = 110;
     btnIniciarCombate.Top = 130;
     btnIniciarCombate.Click += new EventHandler(btnIniciarCombate_Click);
     this.Controls.Add(btnIniciarCombate);
	
	
     }
	
	private void btnIniciarCombate_Click(object sender, EventArgs e)
		
	{
	
	// Equipos de prueba usando tus clases elementales
      List<Personaje> equipo1 = new List<Personaje>
     {
         new personajeAire("Aang", "Aire", 120, 20, 15, 100),
         new personajeAgua("Katara", "Agua", 100, 15, 12, 120)
       };

      List<Personaje> equipo2 = new List<Personaje>
       {
        new personajeTierra("Toph", "Tierra", 160, 12, 30, 80),
        new personajeFuego("Zuko", "Fuego", 90, 32, 10, 90)
        };

       MainForm arenaCombate = new MainForm();
       arenaCombate.InicializarEquipos(equipo1, equipo2);
       arenaCombate.Show();
       this.Hide();
	
	
}
	
	
}

  }
