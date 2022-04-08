using System;
using CuadradosApp.Datos;
using CuadradosApp.Modelos;
namespace CuadradosApp.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var repositorio = new RepositorioDeCuadrados();
            var c = new Cuadrado();

            if (c.Validar())
            {
                repositorio.Agregar(c);
                Console.WriteLine($"Tiene {repositorio.GetCantidad()} elementos");
                Console.WriteLine(c.Lado);

                var cuadrado2 = new Cuadrado();
                repositorio.Agregar(cuadrado2);
                cuadrado2.Lado = 10;
                Console.WriteLine($"El lado del cuadrado es {cuadrado2.Lado}");

                Console.ReadLine();
                Console.Clear();
                var lista = repositorio.GetLista();
                foreach (var cuadrado in lista)
                {
                    Console.WriteLine(cuadrado.Lado);
                } 
            }
            else
            {
                Console.WriteLine("Error: Lado mal ingresado");
            }

            Console.ReadLine();
        }
    }
}
