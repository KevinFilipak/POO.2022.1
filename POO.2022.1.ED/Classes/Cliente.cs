using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO._2022._1.ED.Classes
{
    public class Cliente
    {
        public int Codigo { get; set; } 
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string PassHash { get; set; }

        public void Imprime()
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine($"Código: {Codigo}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Celular: {Celular}");
            Console.WriteLine($"PassHash: {PassHash}");
        }

    }
}
