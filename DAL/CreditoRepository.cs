using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using System.IO;

namespace DAL
{
    public class CreditoRepository
    {
        private string ruta = @"C:\Users\Angel Casadiegos\source\repos\Parcial\ServiCredito";
        private List<Credito> ListadosCreditos;

        public List<Credito> LiquidacionCredito { get; private set; }


        public CreditoRepository()
        {
            LiquidacionCredito = new List<Credito>();
        }
        public void Guardar(Credito credito)

        {
            FileStream fileStream = new FileStream(ruta, FileMode.Append);
            StreamWriter stream = new StreamWriter(fileStream);
            stream.WriteLine(credito.ToString());
            stream.Close();
            fileStream.Close();

        }

        public List<Credito> Consultar()
        {
            ListadosCreditos.Clear();
            FileStream filestream = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(filestream);
            string linea = string.Empty;

            while ((linea = reader.ReadLine()) != null)
            {

                Credito credito = MapearCreditos(linea);
                ListadosCreditos.Add(credito);
            }
            filestream.Close();
            reader.Close();
            return ListadosCreditos;



        }

        public Credito MapearCreditos(string linea)
        {
            string[] datos = linea.Split(';');
            if (datos[1] == "compuesto")
            {
                Credito creditoCompuesto = new CreditoCompuesto(0);

                creditoCompuesto.NumerodeCredito = (datos[0]);
                creditoCompuesto.Periodo = int.Parse(datos[1]);
                creditoCompuesto.TasadeInteres = int.Parse(datos[2]);
                creditoCompuesto.CapitalInicial = int.Parse(datos[3]);
                creditoCompuesto.CapitalFinal = int.Parse(datos[4]);
                return creditoCompuesto;
            }

            else
            {
                Credito creditoSimple = new CreditoSimple(0);
                creditoSimple.NumerodeCredito = (datos[0]);
                creditoSimple.Periodo = int.Parse(datos[1]);
                creditoSimple.TasadeInteres = int.Parse(datos[2]);
                creditoSimple.CapitalInicial = int.Parse(datos[3]);
                creditoSimple.CapitalFinal = int.Parse(datos[4]);
                return creditoSimple;

            }

        }
        public void Eliminar(string NumeroCredito)
        {
            ListadosCreditos.Clear();
            ListadosCreditos = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in ListadosCreditos)
            {
                if (item.NumerodeCredito != NumeroCredito)
                {
                    Guardar(item);
                }
            }

        }

        public Credito Buscar(string NumeroCredito)
        {
            ListadosCreditos.Clear();
            ListadosCreditos = Consultar();

            foreach (var item in ListadosCreditos)
            {
                if (item.NumerodeCredito.Equals(NumeroCredito))
                {
                    return item;
                }
            }
            return null;
        }

        public void Modificar(Credito credito)
        {
            ListadosCreditos.Clear();
            ListadosCreditos = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in ListadosCreditos)
            {
                if (item.NumerodeCredito != credito.NumerodeCredito)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(credito);
                }
            }

        }
    }
}
