using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuadradosApp.Modelos
{
    public class Cuadrado
    {
        //Propiedades
       public int Lado { get; set; }

       //Constructores
       //Constructor por defecto
       public Cuadrado()
       {
           
       }
       public Cuadrado(int medidaLado)
       {
           Lado = medidaLado;
       }

       public bool Validar()
       {
           return Lado > 0;
       }

       public double GetSuperficie() => Math.Pow(Lado, 2);
       public double GetPerimetro() => Lado * 4;
    }
}
