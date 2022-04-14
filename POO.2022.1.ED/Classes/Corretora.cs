using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO._2022._1.ED.Classes
{
    public class Corretora
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public List<Carteira> Carteiras { get; set; }

        public Corretora()
        {
            Carteiras = new List<Carteira>();
        }

        public void Imprime()
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine($"Código: {Codigo}");
            Console.WriteLine($"Nome: {Nome}");
        }
        public void InserirCarteira(Carteira carteira)
        {
            Carteiras.Add(carteira);
        }
    }
}
