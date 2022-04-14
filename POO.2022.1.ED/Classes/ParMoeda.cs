using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO._2022._1.ED.Classes
{
    public class ParMoeda
    {
        public Moeda MoedaCotacao { get; set; } 
        public Moeda MoedaBase { get; set; }
        public double Valor { get; set; }

        public void Imprime()
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine($"Vender: {MoedaCotacao.Codigo}");
            Console.WriteLine($"Comprar: {MoedaBase.Codigo}");
            Console.WriteLine($"Cotação: {Valor.ToString("N2")}");
        }
    }
}
