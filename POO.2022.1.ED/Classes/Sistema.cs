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
                Email = "kevinaguiar09@gmail.com",
                Celular = "+55 (41) 99121-4268",
                PassHash = Crypto.MD5Hash("123456"),
            }) ;

            Clientes.Add(new Cliente
            {
                Codigo = 2,
                Nome = "Erick Krzyzanovski",
                Email = "erickkrzyz@gmail.com",
                Celular = "+55 (41) 99281-8738",
                PassHash = Crypto.MD5Hash("654321"),
            });

            Clientes.Add(new Cliente
            {
                Codigo = 3,
                Nome = "Sergio Marques",
                Email = "sergio.marques@utp.br",
                Celular = "+55 (41) 99002-8922",
                PassHash = Crypto.MD5Hash("UTPBR"),
            });
        }
        public static void CadastrarMoedas()
        {
            Moedas.Add(new Moeda
            {
                Codigo = "BTC",
                Nome = "BitCoin",
            });

            Moedas.Add(new Moeda
            {
                Codigo = "ETH",
                Nome = "Ethereum",
            });

            Moedas.Add(new Moeda
            {
                Codigo = "LTC",
                Nome = "Litecoin",
            });

            Moedas.Add(new Moeda
            {
                Codigo = "USD",
                Nome = "Dólar",
            });

            ParMoedas.Add(new ParMoeda {
                MoedaBase = Moedas[3],
                MoedaCotacao = Moedas[0],
                Valor = 9073.51
            });
            ParMoedas.Add(new ParMoeda
            {
                MoedaBase = Moedas[3],
                MoedaCotacao = Moedas[1],
                Valor = 576.52
            });
            ParMoedas.Add(new ParMoeda
            {
                MoedaBase = Moedas[3],
                MoedaCotacao = Moedas[2],
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

        public static void CadastrarCarteiras()
        {
            var ct1 = new Carteira();

            ct1.Endereco = Crypto.EncodeBase58(1);
            ct1.Cliente = Clientes[0];
            ct1.InsereItemCarteira(Moedas[0], 2.5);
            ct1.InsereItemCarteira(Moedas[1], 1.65);
            ct1.InsereItemCarteira(Moedas[2], 0.55);

            Corretoras[0].InserirCarteira(ct1);

        }

        public static void ImprimirClientes()
        {
            Console.Clear();
            
            foreach (Cliente cliente in Clientes)
            {
                cliente.Imprime();
            }
        }
        public static void ImprimirMoedas()
        {
            Console.Clear();

            foreach (Moeda moeda in Moedas)
            {
                moeda.Imprime();
            }
        }

        public static void ImprimirPares()
        {
            foreach (ParMoeda parMoeda in ParMoedas)
            {
                parMoeda.Imprime();
            }
        }

        public static void ImprimirCorretoras()
        {
            foreach (Corretora corretora in Corretoras)
            {
                corretora.Imprime();
            }
        }

        public static void ImprimirCarteiras()
        {
            foreach (Corretora corretora in Corretoras)
            {
                Console.WriteLine($"Corretora: {corretora.Nome} ");
                Console.WriteLine();

                foreach (Carteira carteira in corretora.Carteiras)
                {
                    foreach (var itemCarteira in carteira.ItensCarteira)
                    {
                        itemCarteira.ObtemCotacaoMoeda(Moedas[3], ParMoedas); 
                    }

                    carteira.Imprime();
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
