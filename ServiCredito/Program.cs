using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using BLL;

namespace ConsoleApp1
{
    static void Main(string[] args)
    {
        MenuPrincipal();
    }

    public static void MenuPrincipal()
    {
        int opcion = 6;
        do
        {
            Console.Clear();
            Console.WriteLine("                  Menú Principal                  ");
            Console.WriteLine("1. Registrar Credito");
            Console.WriteLine("2. Eliminar Credito");
            Console.WriteLine("3. Buscar Credito");
            Console.WriteLine("4. Modificar credito");
            Console.WriteLine("5. Ver listado de creditos");
            Console.WriteLine("0. Salir de la aplicacion\n");
            Console.WriteLine("Digite su opcion: ");
            opcion = Validacion("Error, debe ingresar una de las opciones anteriores", 0, 5);
            Opcion(opcion);
        } while (opcion != 0);
    }
    public static void Opcion(int opcion)
    {
        switch (opcion)
        {
            case 1:

                break;
            case 2:

                break;
            case 3:
                ;
                break;
            case 4:

                break;
            case 5:

                break;
            case 0:
                break;
        }
    }

}
      

}
