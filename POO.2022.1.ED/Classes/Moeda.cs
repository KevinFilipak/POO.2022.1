using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO._2022._1.ED.Classes
{
    public class Moeda
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public void Imprime()
        {
            Console.WriteLine();
            Console.WriteLine($"Código: {Codigo}");
            Console.WriteLine($"Nome: {Nome}");
        }
        
    }
}
