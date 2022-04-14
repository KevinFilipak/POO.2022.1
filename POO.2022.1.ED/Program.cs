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
        Console.WriteLine("Cadastrando Moedas e Pares de Moedas....");
        Sistema.CadastrarMoedas();
        Thread.Sleep(100);
        Console.WriteLine("Cadastrando Clientes....................");
        Sistema.CadastrarClientes();
        Thread.Sleep(100);
        Console.WriteLine("Cadastrando Corretoras..................");
        Sistema.CadastrarCorretoras();
        Thread.Sleep(100);
        Console.WriteLine("Cadastrando Carteiras...................");
        Sistema.CadastrarCarteiras();
        Thread.Sleep(100);

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
                case EnumOpcaoMenu.S:
                    break;
                default:
                    Console.WriteLine("Opção não existente!");
                    break;
            }
            Console.WriteLine();
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
    [Display(Name = "C - Imprimir Pares")]
    C,
    [Display(Name = "D - Imprimir Carteiras")]
    D,
    [Display(Name = "E - Imprimir Corretoras")]
    E,
    //[Display(Name = "F - Inserir Carteira")]
    //F,
    //[Display(Name = "G - Inserir Item Carteira")]
    //G,
    //[Display(Name = "H - Deposita")]
    //H,
    //[Display(Name = "I - Saca")]
    //I,
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