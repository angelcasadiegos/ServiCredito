using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class CreditoCompuesto : Credito
    {
        private int v;

        public CreditoCompuesto(int v)
        {
            this.v = v;
        }

        public CreditoCompuesto(string numerodeCredito, string identificacion, double periodo, double tasadeInteres, double capitalinicial, double capitalFinal)
        {
            NumerodeCredito = numerodeCredito;
            Identificacion = identificacion;
            Periodo = periodo;
            TasadeInteres = tasadeInteres;
            CapitalInicial = capitalinicial;
            CapitalFinal = capitalFinal;
        }

        public CreditoCompuesto(string numerodeCredito, string identificacion, double periodo, double tasadeInteres, double capitalinicial, double capitalFinal, string típodecredito) : base(numerodeCredito, identificacion, periodo, tasadeInteres, capitalinicial, capitalFinal, "Compuesto")
        {

        }

        public override void CalcularCapital()
        {
            CapitalFinal = CapitalInicial * Math.Pow((1 + TasadeInteres), (Periodo));
        }
    }
}
