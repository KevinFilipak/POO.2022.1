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
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("                           Listagem de Clientes                                 ");

            foreach (Cliente cliente in Clientes)
            {
                cliente.Imprime();
            }

            Console.WriteLine("--------------------------------------------------------------------------------");

        }
        public static void ImprimirMoedas()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("                            Listagem de Moedas                                  ");

            foreach (Moeda moeda in Moedas)
            {
                moeda.Imprime();
            }

            Console.WriteLine("--------------------------------------------------------------------------------");

        }

        public static void ImprimirPares()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("                            Listagem de Pares                                   ");
            foreach (ParMoeda parMoeda in ParMoedas)
            {
                parMoeda.Imprime();
            }
            Console.WriteLine("--------------------------------------------------------------------------------");

        }

        public static void ImprimirCorretoras()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("                          Listagem de Corretoras                                ");
            foreach (Corretora corretora in Corretoras)
            {
                corretora.Imprime();
            }
            Console.WriteLine("--------------------------------------------------------------------------------");

        }

        public static void ImprimirCarteiras()
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("                          Listagem de Carteiras                                 ");
            foreach (Corretora corretora in Corretoras)
            {
                Console.WriteLine("--------------------------------------------------------------------------------");

                Console.WriteLine($"Corretora: {corretora.Nome} ");

                foreach (Carteira carteira in corretora.Carteiras)
                {
                    foreach (var itemCarteira in carteira.ItensCarteira)
                    {
                        itemCarteira.ObtemCotacaoMoeda(Moedas[3], ParMoedas); 
                    }
                    carteira.Imprime();
                }
            }
            Console.WriteLine("--------------------------------------------------------------------------------");

        }

        public static void CadastrarCliente()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("                          Cadastro de Clientes                                  ");
            Console.WriteLine("--------------------------------------------------------------------------------");

            var cliente = new Cliente();

            Console.Write("Digite o Nome: ");
            cliente.Nome = Console.ReadLine();

            Console.Write("Digite o E-mail: ");
            cliente.Email = Console.ReadLine();

            Console.Write("Digite o Celular: ");
            cliente.Celular = Console.ReadLine();

            Console.Write("Digite a Senha: ");
            cliente.PassHash = Crypto.MD5Hash(Console.ReadLine());

            
            cliente.Codigo = Clientes.Count + 1;


            Clientes.Add(cliente);
            Console.Clear();
            Console.WriteLine("Cliente Cadastrado com Sucesso!");
            cliente.Imprime();
            Console.WriteLine("--------------------------------------------------------------------------------");


        }
        public static void CadastrarCorretora()
        {
            Console.Clear();
            var corretora = new Corretora();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("                          Cadastro de Corretoras                                  ");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.Write("Digite o Nome da corretora: ");
            corretora.Nome = Console.ReadLine();

            corretora.Codigo = Corretoras.Count + 1;

            Corretoras.Add(corretora);
            Console.Clear();
            Console.WriteLine("Corretora Cadastrada com Sucesso!");
            Console.WriteLine();
            corretora.Imprime();

        }

        public static void CadastrarMoeda()
        {
            Console.Clear();
            var moeda = new Moeda();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("                          Cadastro de Moedas                                  ");
            Console.WriteLine("--------------------------------------------------------------------------------");

            Console.Write("Digite o Código da moeda: ");
            moeda.Codigo = Console.ReadLine();

            Console.Write("Digite o nome da moeda: ");
            moeda.Nome = Console.ReadLine();

            Moedas.Add(moeda);
            Console.Clear();
            Console.WriteLine("Moeda Cadastrada com Sucesso!");
            Console.WriteLine();
            moeda.Imprime();

        }

        public static void CadastrarCotacao()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("                          Cadastro de Cotações                                  ");
            Console.WriteLine("--------------------------------------------------------------------------------");
            string _moedaBase;
            string _moedaCotacao;
            string _moedaValor;

            ImprimirMoedas();

            Console.WriteLine();
            Console.Write("Digite o Código da Moeda Base: ");
            _moedaBase = Console.ReadLine();

            Console.Write("Digite o Código da Moeda Cotação: ");
            _moedaCotacao = Console.ReadLine();

            Console.Write("Digite o Valor da Cotação: ");
            _moedaValor = Console.ReadLine();

            ParMoeda parMoeda = new ParMoeda();

            foreach (var moeda in Moedas)
            {
                if (moeda.Codigo == _moedaBase)
                {
                    parMoeda.MoedaBase = moeda;
                }

                if (moeda.Codigo == _moedaCotacao)
                {
                    parMoeda.MoedaCotacao = moeda;
                }

            }
            parMoeda.Valor = Convert.ToDouble(_moedaValor.ToString());

            ParMoedas.Add(parMoeda);

            Console.Clear();
            Console.WriteLine("Cotação Cadastrada com Sucesso!");
            Console.WriteLine();
            parMoeda.Imprime();

        }

        public static void CadastrarCarteira()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("                          Cadastro de Carteiras                                 ");
            Console.WriteLine("--------------------------------------------------------------------------------");

            string _corretora;
            string _cliente;
            string _endereco;

            ImprimirCorretoras();

            Console.WriteLine();
            Console.Write("Digite o Código da Corretora: ");
            _corretora = Console.ReadLine();

            ImprimirClientes();

            Console.Write("Digite o Código do Cliente: ");
            _cliente = Console.ReadLine();

            Console.Write("Digite o Endereço da Carteira (Número Inteiro): ");
            _endereco = Console.ReadLine();

            var carteira = new Carteira();

            foreach (var cliente in Clientes)
            {
                if (cliente.Codigo.ToString() == _cliente)
                {
                    carteira.Cliente = cliente;
                }
            }

            carteira.Endereco = Crypto.EncodeBase58(int.Parse(_endereco));

            carteira.ItensCarteira = new List<ItemCarteira>();


            foreach (var corretora in Corretoras)
            {
                if (corretora.Codigo.ToString() == _corretora)
                {
                    corretora.InserirCarteira(carteira);
                }
            }


            Console.Clear();
            Console.WriteLine("Carteira Cadastrada com Sucesso!");
            Console.WriteLine();
            carteira.Imprime();

        }

        public static void InserirItemCarteira()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("                         Inserir Item na Carteira                               ");
            Console.WriteLine("--------------------------------------------------------------------------------");

            string _endereco;
            string _moeda;
            string _quantidade;

            ImprimirCarteiras();

            Console.WriteLine();
            Console.Write("Digite o Endereço da Carteira: ");
            _endereco = Console.ReadLine();

            ImprimirMoedas();

            Console.WriteLine();
            Console.Write("Selecione o Código da Moeda: ");
            _moeda = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Digite a Quantidade: ");
            _quantidade = Console.ReadLine();

            var _moedaCarteira = new Moeda();

            foreach (var moeda in Moedas)
            {
                if (moeda.Codigo == _moeda)
                {
                    _moedaCarteira = moeda;
                }

            }

            foreach (var corretora in Corretoras)
            {
                foreach (var carteira in corretora.Carteiras)
                {
                    if (carteira.Endereco == _endereco)
                    {
                        carteira.InsereItemCarteira(_moedaCarteira, double.Parse(_quantidade));
                    }
                }
            }

            Console.Clear();
            Console.WriteLine("Item Inserido com Sucesso!");
            Console.WriteLine();
        }

        public static void Depositar()
        {
            Console.Clear();
            string _endereco;
            string _moeda;
            string _quantidade;

            ImprimirCarteiras();

            Console.WriteLine();
            Console.Write("Digite o Endereço da Carteira: ");
            _endereco = Console.ReadLine();

            ImprimirMoedas();

            Console.WriteLine();
            Console.Write("Selecione o Código da Moeda: ");
            _moeda = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Digite a Quantidade: ");
            _quantidade = Console.ReadLine();

            var _moedaCarteira = new Moeda();

            foreach (var moeda in Moedas)
            {
                if (moeda.Codigo == _moeda)
                {
                    _moedaCarteira = moeda;
                }

            }

            var _deposito = false;

            foreach (var corretora in Corretoras)
            {
                foreach (var carteira in corretora.Carteiras)
                {
                    if (carteira.Endereco == _endereco)
                    {
                        foreach (var item in carteira.ItensCarteira)
                        {
                            if (item.Moeda.Codigo == _moedaCarteira.Codigo)
                            {
                               
                                carteira.Deposita(_moedaCarteira, double.Parse(_quantidade));
                                
                                _deposito = true;
                            }
                        }
                        
                    }
                }
            }

            if (_deposito)
            {
                Console.Clear();
                Console.WriteLine("Operação Finalizada!");
                Console.WriteLine();

            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Não existe nenhum item na Carteira Selecionada com a Moeda {_moedaCarteira.Codigo}");
                Console.WriteLine();

            }

        }
        public static void Sacar()
        {
            Console.Clear();

            string _endereco;
            string _moeda;
            string _quantidade;

            ImprimirCarteiras();

            Console.WriteLine();
            Console.Write("Digite o Endereço da Carteira: ");
            _endereco = Console.ReadLine();

            ImprimirMoedas();

            Console.WriteLine();
            Console.Write("Selecione o Código da Moeda: ");
            _moeda = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Digite a Quantidade: ");
            _quantidade = Console.ReadLine();

            var _moedaCarteira = new Moeda();

            foreach (var moeda in Moedas)
            {
                if (moeda.Codigo == _moeda)
                {
                    _moedaCarteira = moeda;
                }

            }

            var _saque = false;


            foreach (var corretora in Corretoras)
            {
                foreach (var carteira in corretora.Carteiras)
                {
                    if (carteira.Endereco == _endereco)
                    {
                        foreach (var item in carteira.ItensCarteira)
                        {
                            if (item.Moeda.Codigo == _moedaCarteira.Codigo)
                            {
                                if (item.Quantidade < double.Parse(_quantidade))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Você não tem saldo disponivel para realizar o saque!");
                                }
                                else
                                {
                                    carteira.Saca(_moedaCarteira, double.Parse(_quantidade));
                                    Console.Clear();
                                }
                                _saque = true;
                            }
                        }
                    }
                }
            }

            if (_saque)
            {
                Console.WriteLine("Operação Finalizada!");
                Console.WriteLine();

            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Não existe nenhum item na Carteira Selecionada com a Moeda {_moedaCarteira.Codigo}");
                Console.WriteLine();

            }
        }
    }
}
