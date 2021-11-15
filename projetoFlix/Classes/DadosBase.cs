using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.Series.Classes
{
    public abstract class DadosBase
    {
        public void InsereDados()
        {   
            foreach (int i in Enum.GetValues(typeof(Tipo)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
            }
            Console.WriteLine("Digite - 1 - para inserir um Filme");
            Console.WriteLine("Digite - 2 - para inserir uma Série");
            int entradaTipo = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Qual o tipo da Série");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o Título da Série");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Qual o ano que a Série iniciou?");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Série");
            string entradaDescricao = Console.ReadLine();
            return;
        }
    }
}