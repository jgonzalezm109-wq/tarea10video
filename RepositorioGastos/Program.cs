using System;
using System.Collections.Generic;

namespace RepositorioGastos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GastoRepositorio repo = new GastoRepositorio();
            string opcion;

            do
            {
                opcion = LeerOpcionMenu();

                switch (opcion)
                {
                    case "1":
                        RegistrarGasto(repo);
                        break;
                    case "2":
                        ListarGastos(repo);
                        break;
                    case "3":
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != "3");
        }

        private static string LeerOpcionMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=== REGISTRO DE GASTOS ===");
            Console.WriteLine("1. Registrar gasto");
            Console.WriteLine("2. Listar gastos");
            Console.WriteLine("3. Salir");
            Console.Write("Elige una opción: ");
            return Console.ReadLine();
        }

        private static void RegistrarGasto(GastoRepositorio repo)
        {
            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine().Trim();

            Console.Write("Monto: ");
            bool montoOk = decimal.TryParse(Console.ReadLine(), out decimal monto);

            Console.Write("Categoría: ");
            string categoria = Console.ReadLine().Trim();

           
            if (!montoOk || monto <= 0 || string.IsNullOrWhiteSpace(descripcion) || string.IsNullOrWhiteSpace(categoria))
            {
                Console.WriteLine("Datos inválidos.");
                return;
            }

            Gasto nuevoGasto = new Gasto
            {
                Descripcion = descripcion,
                Monto = monto,
                Categoria = categoria
            };

            repo.Insertar(nuevoGasto);
            Console.WriteLine("Gasto registrado.");
        }

        private static void ListarGastos(GastoRepositorio repo)
        {
            List<Gasto> lista = repo.ListarTodos();

            if (lista.Count == 0)
            {
                Console.WriteLine("No hay gastos registrados.");
                return;
            }

            decimal totalGeneral = 0;

            foreach (Gasto g in lista)
            {
                Console.WriteLine(g);
                totalGeneral += g.Monto;
            }

            Console.WriteLine($"TOTAL GASTADO: Q {totalGeneral:N2}");
        }
    }
}