using System;
using System.Windows.Forms;

namespace AVATAR
{
public class MotorEscenariosYCalculo
{

// configuración de escenario y compatibilidad elemental

public double ObtenerMultiplicadorEscenario(string elementoPersonaje, string elementoEscenario)
{

if (elementoPersonaje == elementoEscenario)
return 1.25;

if((elementoPersonaje == "Fuego" && elementoEscenario == "Agua") ||  (elementoPersonaje == "Agua" && elementoEscenario == "Tierra"))
return 0.80;

return 1.0;

}

// Cálculo de daño y mitigación

public double CalcularDanioFinal(double ataqueAtacante, double defensaObjetivo, string elementoAtacante, string elementoEscenario)
{

double multiplicador = ObtenerMultiplicadorEscenario(elementoAtacante, elementoEscenario);
double danioBruto = (ataqueAtacante * multiplicador) - (defensaObjetivo * 0.5);
return Math.Round(Math.Max(danioBruto, 5.0), 2);
}

// Evento TERREMOTO


public double EjecutarTerremoto(double defensaBase, double factorDisturbio)
{
double danioTerremoto;

if (Math.Abs(factorDisturbio - 1.0) < 0.001)
{

danioTerremoto = defensaBase * 2.0 * 1.5;
}
else
{

danioTerremoto = defensaBase * ((Math.Pow(factorDisturbio, 2) - 1) / (factorDisturbio - 1));

 }

return Math.Round(danioTerremoto, 2);

 }

// Mecánica de Empatía (Inversión del efecto terremoto)

public string ProcesarEmpatiaTerremoto(string nombrePersonaje, double valorEmpatia, ref double hpPersonaje )

{

double umbral = 50.0;

if (valorEmpatia >= umbral)

{

double curacion = 20.0;   //Empatía alta
hpPersonaje += curacion;

return "¡Empatía activada! El terremoto sanó a " + nombrePersonaje + " (+" + curacion + " HP).";

}

else

{

double danio = EjecutarTerremoto(10.0, 1.0);

hpPersonaje = Math.Max(0, hpPersonaje - danio);

return "¡Terremoto! " + nombrePersonaje + " recibió daño estructural (-" + danio + " HP).";

}
}

}

} 
