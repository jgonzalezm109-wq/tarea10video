using System.Collections.Generic;

namespace RepositorioGastos
{
    public class GastoRepositorio
    {
        
        private static List<Gasto> listaGastos = new List<Gasto>();
        private static int siguienteId = 1;

        public void Insertar(Gasto g)
        {
            g.Id = siguienteId++;
            listaGastos.Add(g);
        }

        public List<Gasto> ListarTodos()
        {
            return listaGastos;
        }
    }
}