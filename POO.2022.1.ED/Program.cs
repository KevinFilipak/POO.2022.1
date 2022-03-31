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
        Console.WriteLine(Crypto.EncodeBase58(123456));
        Console.ReadLine();
        Console.WriteLine("Cadastrando Moedas................");
        Sistema.CadastrarMoedas();
        Thread.Sleep(1000);
        Console.WriteLine("Cadastrando Clientes..............");
        Sistema.CadastrarClientes();
        Thread.Sleep(1000);
        Console.WriteLine("Cadastrando Corretoras............");
        Sistema.CadastrarCorretoras();
        Thread.Sleep(1000);

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
                case EnumOpcaoMenu.A:   // Cliente
                    Sistema.ImprimirClientes();
                    break;
                case EnumOpcaoMenu.B:
                    Sistema.ImprimirMoedas();


                    break;
                case EnumOpcaoMenu.C:


                    break;
                case EnumOpcaoMenu.D:


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
    [Display(Name = " - Imprimir Pares")]
    Z,
    [Display(Name = " - Imprimir Carteiras")]
    X,
    [Display(Name = "C - Imprimir Corretoras")]
    C,
    [Display(Name = "D - Inserir Carteira")]
    D,
    [Display(Name = "E - Inserir Item Carteira")]
    E,
    [Display(Name = "F - Deposita")]
    F,
    [Display(Name = "G - Saca")]
    G,
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