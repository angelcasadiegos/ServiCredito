using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public abstract class Credito
    {


        public string NumerodeCredito { get; set; }

        public string Identificacion { get; set; }
        public double Periodo { get; set; }
        public double TasadeInteres { get; set; }
        public double CapitalInicial { get; set; }
        public double CapitalFinal { get; set; }
        public string TipodeCredito { get; set; }

        public abstract void CalcularCapital();

        public Credito(string numerodeCredito, string identificacion, double periodo, double tasadeInteres, double capitalinicial, double capitalFinal, string tipodeCredito)
        {
            NumerodeCredito = numerodeCredito;
            Identificacion = identificacion;
            Periodo = periodo;
            TasadeInteres = tasadeInteres;
            CapitalInicial = capitalinicial;
            CapitalFinal = capitalFinal;
            TipodeCredito = tipodeCredito;

        }

        public Credito()
        {

        }

        public override string ToString()
        {
            return $"{NumerodeCredito};{Identificacion};{TipodeCredito};{CapitalInicial}";
        }


    }
}


