using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO._2022._1.ED.Classes
{
    public class Carteira
    {
        public string Endereco { get; set; }
        public Cliente Cliente { get; set; }
        public List<ItemCarteira> ItensCarteira { get; set; }

        public Carteira()
        {
            ItensCarteira = new List<ItemCarteira>();
        }

        public void InsereItemCarteira(Moeda moeda, double quantidade)
        {
            ItensCarteira.Add(new ItemCarteira
            {
                Moeda = moeda,
                Quantidade = quantidade,
            });


        }

        public void Imprime()
        {
            Console.WriteLine($"Endereço da Carteira: {Endereco} ");
            Console.WriteLine($"Cliente: {Cliente.Codigo} - {Cliente.Nome}");

            foreach (ItemCarteira itemCarteira in ItensCarteira)
            {

                itemCarteira.Imprime();
            }
        }

        public void Deposita(Moeda moeda, double quantidade)
        {
            foreach (ItemCarteira itemCarteira in ItensCarteira)
            {
                if (moeda.Codigo == itemCarteira.Moeda.Codigo)
                {
                    itemCarteira.Quantidade += quantidade;
                }
            }
        }

        public void Saca(Moeda moeda, double quantidade)
        {
            foreach (ItemCarteira itemCarteira in ItensCarteira)
            {
                if (moeda.Codigo == itemCarteira.Moeda.Codigo)
                {
                    itemCarteira.Quantidade -= quantidade;
                }
            }

        }

    }
}
