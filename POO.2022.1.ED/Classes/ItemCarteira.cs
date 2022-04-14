using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO._2022._1.ED.Classes
{
    public class ItemCarteira
    {
        public Moeda Moeda { get; set; } 
        public double Quantidade { get; set; }

        private double Valor;

        public void ObtemCotacaoMoeda(Moeda moeda, List<ParMoeda> parMoedas)
        {
            var _par = new ParMoeda();

            foreach (ParMoeda parMoeda in parMoedas)
            {
                if(parMoeda.MoedaBase.Codigo == moeda.Codigo && parMoeda.MoedaCotacao.Codigo == Moeda.Codigo)
                {
                    _par = parMoeda;
                }
            }

            if (_par.Valor > 0)
            {
                Valor = Quantidade * _par.Valor;
            }
        }
        public void Imprime()
        {
            Console.WriteLine();
            Console.Write($"Moeda: {Moeda.Codigo} Nome: {Moeda.Nome} Quantidade: {Quantidade.ToString("N4")} Valor: {Valor.ToString("N3")}");
        }

    }
}
