using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO._2022._1.ED.Classes
{
    public static class Sistema
    {
        public static List<Moeda> Moedas = new List<Moeda>();
        public static List<Cliente> Clientes = new List<Cliente>();
        public static List<Corretora> Corretoras = new List<Corretora>();
        public static List<ParMoeda> ParMoedas = new List<ParMoeda>();


        public static void CadastrarClientes()
        {
            Clientes.Add(new Cliente
            {
                Codigo = 1,
                Nome = "Kevin",
                Email = "kevin@filipak.com.br",
                Celular = "+55 (41) 99121-4268",
                PassHash = Crypto.MD5Hash("123456"),
            }) ;

            Clientes.Add(new Cliente
            {
                Codigo = 2,
                Nome = "",
                Email = "",
                Celular = "",
                PassHash = "",
            });

            Clientes.Add(new Cliente
            {
                Codigo = 3,
                Nome = "",
                Email = "",
                Celular = "",
                PassHash = "",
            });
        }
        public static void CadastrarMoedas()
        {
            Moedas.Add(new Moeda
            {
                Codigo = "1",
                Nome = "BitCoin",
            });

            Moedas.Add(new Moeda
            {
                Codigo = "2",
                Nome = "Ethereum",
            });

            Moedas.Add(new Moeda
            {
                Codigo = "3",
                Nome = "Litecoin",
            });

            Moedas.Add(new Moeda
            {
                Codigo = "4",
                Nome = "Dólar",
            });

            ParMoedas.Add(new ParMoeda {
                MoedaBase = Moedas[0],
                MoedaCotacao = Moedas[3],
                Valor = 9073.51
            });
            ParMoedas.Add(new ParMoeda
            {
                MoedaBase = Moedas[1],
                MoedaCotacao = Moedas[3],
                Valor = 576.52
            });
            ParMoedas.Add(new ParMoeda
            {
                MoedaBase = Moedas[2],
                MoedaCotacao = Moedas[3],
                Valor = 173.39
            });



        }
        public static void CadastrarCorretoras()
        {
            Corretoras.Add(new Corretora
            {
                Codigo = 1,
                Nome = "BisCoin",
                Carteiras = new List<Carteira>(),
            });
            Corretoras.Add(new Corretora
            {
                Codigo = 2,
                Nome = "Binance",
                Carteiras = new List<Carteira>(),
            });

        }

        public static void ImprimirClientes()
        {
            Console.Clear();
            Console.WriteLine("Imprimindo Clientes...");
            Console.WriteLine();
            
            foreach (Cliente cliente in Clientes)
            {
                cliente.Imprime();
            }
        }
        public static void ImprimirMoedas()
        {
            //Console.Clear();
            //Console.WriteLine("Imprimindo Clientes...");
            //Console.WriteLine();

            //foreach (Moeda cliente in Clientes)
            //{
            //    cliente.Imprime();
            //}
        }

        public static void InserirCarteira()
        {
            
        }

    }
}
