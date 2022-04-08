using System.Collections.Generic;
using CuadradosApp.Modelos;

namespace CuadradosApp.Datos
{
    public class RepositorioDeCuadrados
    {
        public List<Cuadrado> listaCuadrados { get; set; } = new List<Cuadrado>();

        public RepositorioDeCuadrados()
        {
            //listaCuadrados = new List<Cuadrado>();
            LeerCuadrados();
        }

        private void LeerCuadrados()
        {
            var c1 = new Cuadrado(5);
            var c2 = new Cuadrado(7);
            var c3 = new Cuadrado(10);
            listaCuadrados.Add(c1);
            listaCuadrados.Add(c2);
            listaCuadrados.Add(c3);

        }

        public void Agregar(Cuadrado cuadrado)
        {
            listaCuadrados.Add(cuadrado);
        }

        public void Editar(Cuadrado cuadrado)
        {

        }

        public void Borrar(Cuadrado cuadrado)
        {
            listaCuadrados.Remove(cuadrado);
        }

        public int GetCantidad()
        {
            return listaCuadrados.Count;
        }

        public List<Cuadrado> GetLista()
        {
            return listaCuadrados;
        }
    }
}
