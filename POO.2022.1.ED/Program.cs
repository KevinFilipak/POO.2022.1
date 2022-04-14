using System.IO;
using System;
using POO._2022._1.ED.Classes;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.ComponentModel;

class Program
{ 
    static void Main()
    {

        Console.Title = $"Analise e Desenvolvimento de Sistemas - Programação Orientada a Objeto";

        Console.ForegroundColor= ConsoleColor.Green;

        Console.WriteLine("===========================================================================================");
        Console.WriteLine();
        Console.WriteLine("      ██    ██   ████████   ████████           ████████   █████      ████████ ");
        Console.WriteLine("      ██    ██      ██      ██    ██           ██    ██   ██   ██    ██       ");
        Console.WriteLine("      ██    ██      ██      ████████   █████   ████████   ██    ██   ████████ ");
        Console.WriteLine("      ██    ██      ██      ██                 ██    ██   ██   ██          ██ ");
        Console.WriteLine("      ████████      ██      ██                 ██    ██   █████      ████████ ");
        Console.WriteLine();
        Console.WriteLine("Created By: Kevin Filipak // Erick Krzyzanovski // Nicolas Peçanha // André Luiz de Souza ");
        Console.WriteLine("===========================================================================================");


        Console.WriteLine("Cadastrando Moedas e Pares de Moedas......................................");
        Sistema.CadastrarMoedas();
        Thread.Sleep(1000);
        Console.WriteLine("Cadastrando Clientes......................................................");
        Sistema.CadastrarClientes();
        Thread.Sleep(1000);
        Console.WriteLine("Cadastrando Corretoras....................................................");
        Sistema.CadastrarCorretoras();
        Thread.Sleep(1000);
        Console.WriteLine("Cadastrando Carteiras.....................................................");
        Sistema.CadastrarCarteiras();
        Thread.Sleep(1000);
        Console.WriteLine("==========================================================================");


        Console.Clear();

        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine("                            Orientação a Objetos                                ");
        Console.WriteLine("                           Aplicação Criptomoedas                               ");
        Console.WriteLine("--------------------------------------------------------------------------------");

        var opcao = Menu();

        while (opcao != EnumOpcaoMenu.S)
        {
            Console.Clear();
            switch (opcao)
            {
                case EnumOpcaoMenu.A:   // Clientes
                    Sistema.ImprimirClientes();
                    break;
                case EnumOpcaoMenu.B:   // Moedas
                    Sistema.ImprimirMoedas();
                    break;
                case EnumOpcaoMenu.C: //Pares
                    Sistema.ImprimirPares();
                    break;
                case EnumOpcaoMenu.D: // Carteiras
                    Sistema.ImprimirCarteiras();
                    break;
                case EnumOpcaoMenu.E: // Corretoras
                    Sistema.ImprimirCorretoras();
                    break;
                case EnumOpcaoMenu.F: // Cadastro Cliente
                    Sistema.CadastrarCliente();
                    break;
                case EnumOpcaoMenu.G: // Cadastro Cliente
                    Sistema.CadastrarCorretora();
                    break;
                case EnumOpcaoMenu.H: // Cadastrar Moedas
                    Sistema.CadastrarMoeda();
                    break;
                case EnumOpcaoMenu.I: // Cadastrar Cotação
                    Sistema.CadastrarCotacao();
                    break;
                case EnumOpcaoMenu.J: // Cadastrar Carteira
                    Sistema.CadastrarCarteira();
                    break;
                case EnumOpcaoMenu.K: // Inserir Item Carteira
                    Sistema.InserirItemCarteira();
                    break;
                case EnumOpcaoMenu.L: // Depositar
                    Sistema.Depositar();
                    break;
                case EnumOpcaoMenu.M: // Sacar
                    Sistema.Sacar();
                    break;
                case EnumOpcaoMenu.S:
                    break;

                default:
                    Console.WriteLine("Opção não existente!");
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu!");
            Console.ReadKey();
            opcao = Menu();

        }
    }

    private static EnumOpcaoMenu Menu()
    {
        try
        {
            
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("                            Orientação a Objetos                                ");
            Console.WriteLine("                           Aplicação Criptomoedas                               ");
            Console.WriteLine("--------------------------------------------------------------------------------");

            var _lstMenu = Enum.GetValues(typeof(EnumOpcaoMenu));

            foreach (var _menu in _lstMenu)
            {
                Console.WriteLine(((EnumOpcaoMenu)_menu).GetDisplayName());
            }

            Console.WriteLine("--------------------------------------------------------------------------------");

            Console.WriteLine();
            Console.Write("Digite a opção desejada: ");
            
            return (EnumOpcaoMenu)Enum.Parse(typeof(EnumOpcaoMenu), Console.ReadLine().ToString().ToUpper());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Opção não existente!");
            return Menu();
        }
        
    }

}

public enum EnumOpcaoMenu
{
    [Display(Name = "A - Imprimir Clientes")]
    A,
    [Display(Name = "B - Imprimir Moedas")]
    B,
    [Display(Name = "C - Imprimir Cotações")]
    C,
    [Display(Name = "D - Imprimir Carteiras")]
    D,
    [Display(Name = "E - Imprimir Corretoras")]
    E,
    [Display(Name = "F - Cadastrar Cliente")]
    F,
    [Display(Name = "G - Cadastrar Corretora")]
    G,
    [Display(Name = "H - Cadastrar Moeda")]
    H,
    [Display(Name = "I - Cadastrar Cotação")]
    I,
    [Display(Name = "J - Cadastrar Carteira")]
    J,
    [Display(Name = "K - Inserir Item Carteira")]
    K,
    [Display(Name = "L - Depositar")]
    L,
    [Display(Name = "M - Sacar")]
    M,
    [Display(Name = "S - Sair")]
    S,
}

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>()
                        .GetName();
    }
}

