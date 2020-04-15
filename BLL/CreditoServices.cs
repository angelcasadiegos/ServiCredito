using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using DAL;

namespace BLL
{
    public class CreditoServices
    {
        private CreditoRepository creditoRepository;
        public CreditoServices()
        {
            creditoRepository = new CreditoRepository();
        }
        public string Guardar(Credito credito)
        {
            try
            {
                if (creditoRepository.Buscar(credito.NumerodeCredito) == null)
                {
                    creditoRepository.Guardar(credito);
                    return $"Los datos del Credito {credito.NumerodeCredito} han sido guardados correctamente";
                }
                return $"No es posible registrar el credito de numero {credito.NumerodeCredito}, porque ya se encuentra registrado";
            }
            catch (Exception E)
            {
                return "Error de lectura o escritura de archivos" + E.Message;
            }
        }
        public string Eliminar(string numerodeCredito)
        {
            try
            {
                Credito credito = creditoRepository.Buscar(numerodeCredito);
                if (credito != null)
                {
                    creditoRepository.Eliminar(numerodeCredito);
                    Console.WriteLine($"Los datos del credito {numerodeCredito} han sido eliminados correctamente");
                    return null;
                }
                Console.WriteLine($"No es posible eliminar el credito {numerodeCredito}, porque no se encuentra registrado");
                return null;
            }
            catch (Exception E)
            {
                Console.WriteLine("Error de lectura o escritura de archivos" + E.Message);
                return null;
            }
        }
        public void Modificar(Credito credito)
        {
            try
            {
                creditoRepository.Modificar(credito);
            }
            catch (Exception E)
            {
                Console.WriteLine("Error de lectura o escritura de archivos" + E.Message);
            }
        }
        public List<Credito> Consultar()
        {
            try
            {
                List<Credito> credito = creditoRepository.Consultar();
                if (credito == null)
                {
                    Console.WriteLine("No existen creditos registrados");
                }
                return credito;
            }
            catch (Exception E)
            {
                Console.WriteLine("Error de lectura o escritura de archivos" + E.Message);
                return null;
            }
        }
        public void ImprimirDatos(Credito credito)
        {
            Console.WriteLine("Numero De credito", "Tipo de cradito", "identificacion ", "Prestamo", "Valor a Pagar");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine(credito.NumerodeCredito, credito.TipodeCredito, credito.Identificacion, credito.CapitalInicial, credito.TasadeInteres);
        }
        public Credito Buscar(string numeroCredito)
        {
            try
            {
                Credito credito = creditoRepository.Buscar(numeroCredito);
                if (credito == null)
                {
                    Console.WriteLine($"el credito numero {numeroCredito} no se encuentra registrado");
                }
                return credito;
            }
            catch (Exception E)
            {
                Console.WriteLine("Error de lectura o escritura de archivos" + E.Message);
                return null;
            }
        }
    }
}
