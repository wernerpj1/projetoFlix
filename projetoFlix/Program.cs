using System;
using System.Runtime.CompilerServices;


namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static FilmeRepositorio filmeRepositorio = new FilmeRepositorio();
        
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X" )
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarTitulo();
                        break;
                    case "2":
                        InsereTitulo();
                        break;
                    case "3":
                        AtualizaTitulo();
                        break;
                    case "4":
                        ExcluirTitulo();
                        break;
                    case "5":
                        VizualizarTitulo();
                        break;
                    case "6":
                        DevolveTitulo();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.WriteLine();            
        }
        private static void ListarTitulo()
        {
            Console.WriteLine("Listar Títulos");
            var lista = repositorio.Lista();
            var listaFilmes = filmeRepositorio.Lista();
            
            if (lista.Count + listaFilmes.Count == 0)
            {
                Console.WriteLine("Nenhum Título cadastrado. ");
                return;
            }
            else
            Console.WriteLine("Séries");
            {
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("{2} #ID {0}: - {1} ", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
            Console.WriteLine("Filmes");
            foreach (var filme in listaFilmes)
            {
                var excluido = filme.retornaExcluido();
                Console.WriteLine("{2} #ID {0}: - {1}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }

            }
        }
        private static void InsereTitulo()
        {
            foreach (int i in Enum.GetValues(typeof(Tipo)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
            }
            int entradaTipo = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Qual o Gênero do Título");
            int entradaGenero = int.Parse(Console.ReadLine());
        
            Console.WriteLine("Digite o nome do Título");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Qual o ano do Título");
            int entradaAno = int.Parse(Console.ReadLine());;

            Console.WriteLine("Digite a descrição do Título");
            string entradaDescricao = Console.ReadLine();
            if (entradaTipo == 2)
            {            
            Serie insereSerie = new Serie( id: repositorio.ProximoId(),
                                        tipo: (Tipo)entradaTipo,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(insereSerie);
            }
            else if (entradaTipo == 1)
            {
                Filme insereFilme = new Filme( id: repositorio.ProximoId(),
                                        tipo: (Tipo)entradaTipo,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            filmeRepositorio.Insere(insereFilme);
            }
            else
            {
            Console.WriteLine("Você deve escolher entre Filme = Digite 1 e Série Digite 2");
            Console.ReadLine();
            }
        }

    
        private static void AtualizaTitulo()
        {
            Console.WriteLine("Qual tipo de Título deseja atualizar?");
            foreach (int i in Enum.GetValues(typeof(Tipo)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
            }
            int indiceTipo = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o id");
            int indice = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Qual o genêro do Título");
            int entradaGenero = int.Parse(Console.ReadLine());
        
            Console.WriteLine("Digite o nome do Titulo");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Qual o ano do Título?");
            int entradaAno = int.Parse(Console.ReadLine());;

            Console.WriteLine("Digite a descrição do Título");
            string entradaDescricao = Console.ReadLine();
            
            if (indiceTipo == 2)
            {
            Serie atualizaSerie = new Serie( id: indice,
                                        tipo: (Tipo)indiceTipo,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(indice, atualizaSerie);
            }
            else if (indiceTipo == 1)
            {
                Filme atualizaFilme = new Filme( id: indice,
                                        tipo: (Tipo)indiceTipo,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            filmeRepositorio.Atualiza(indice, atualizaFilme);
            }
        }
        private static void ExcluirTitulo()
        {   
            Console.WriteLine("Digite o Tipo do Titulo");
            foreach (int i in Enum.GetValues(typeof(Tipo)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
            }
            int indiceTipo = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o ID do Titulo");
            int indice = int.Parse(Console.ReadLine());
            if (indiceTipo == 1)
            {
                Console.WriteLine("Tem certeza que deseja excluir este Filme?");
                Console.WriteLine("S - Sim");
                string sim = Console.ReadLine().ToUpper();
                if ( sim == "S")
                    filmeRepositorio.Exclui(indice);
            }
            else if (indiceTipo == 2)
            {
                Console.WriteLine("Tem certeza que deseja excluir esta Série?");
                Console.WriteLine("S - Sim");
                string sim = Console.ReadLine().ToUpper();
                if ( sim == "S")
                    repositorio.Exclui(indice);
            }
            else
            {
                Console.WriteLine("Por favor selecione entre os tipos de Títulos");
            }
        }
        private static void VizualizarTitulo()
        {
            Console.WriteLine("Selecione o tipo do Título");
            foreach (int i in Enum.GetValues(typeof(Tipo)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
            }
            int indiceTipo = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o ID do Título");
            int indice = int.Parse(Console.ReadLine());
            if (indiceTipo == 1)
            {
                var tituloId = filmeRepositorio.RetornaPorId(indice);
                Console.WriteLine(tituloId);
            }
            else if (indiceTipo == 2)
            {
                var tituloId = repositorio.RetornaPorId(indice);
                Console.WriteLine(tituloId);
            }
            else
            {
                Console.WriteLine("Selecione entre os tipos de Títulos existentes");
            }
            
        }
        private static void DevolveTitulo()
        {   
            Console.WriteLine("Digite o Tipo do Titulo");
            foreach (int i in Enum.GetValues(typeof(Tipo)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
            }
            int indiceTipo = int.Parse(Console.ReadLine());
            
            if (indiceTipo == 1)
            {
                var listaExcluidos = filmeRepositorio.Lista();
                foreach(var item in listaExcluidos)
                {
                    var excluido = item.retornaExcluido();
                    if( excluido == true)
                    {
                        Console.WriteLine("{0}-{1}", item.Id, item.Titulo);
                    }
                }
                Console.WriteLine("Selecione o filme que deseja restaurar Filme");
                int indice = int.Parse(Console.ReadLine());
                var titulo = filmeRepositorio.RetornaPorId(indice);
                Console.WriteLine("Tem certeza que deseja restaurar este Título? {0}-{1}", titulo.Id, titulo.Titulo);
                Console.WriteLine("S - Sim");
                string sim = Console.ReadLine().ToUpper();
                if ( sim == "S")
                    filmeRepositorio.Restaura(indice);
            }
            else if (indiceTipo == 2)
            {
                var listaExcluidos = repositorio.Lista();
                foreach(var item in listaExcluidos)
                {
                    var excluido = item.retornaExcluido();
                    if( excluido == true)
                    {
                        Console.WriteLine("{0}-{1}", item.Id, item.Titulo);
                    }
                }
                Console.WriteLine("Selecione o ID da série que deseja restaurar");
                int indice = int.Parse(Console.ReadLine());
                var titulo = repositorio.RetornaPorId(indice);
                Console.WriteLine("Tem certeza que deseja restaurar este Título? {0}-{1}", titulo.Id, titulo.Titulo);
                Console.WriteLine("S - Sim");
                string sim = Console.ReadLine().ToUpper();
                if ( sim == "S")
                    repositorio.Restaura(indice);
            }
            else
            {
                Console.WriteLine("Por favor selecione entre os tipos de Títulos");
            }
        } 
       

        private static string ObterOpcaoUsuario()
            {
                Console.WriteLine();
            Console.WriteLine("MaLuFlix Apresenta...");
            Console.WriteLine("Neste menu informe a opção desejada");
            
            Console.WriteLine("1 - Listar Títulos");
            Console.WriteLine("2 - Inserir novo Título");
            Console.WriteLine("3 - Atualizar Título");
            Console.WriteLine("4 - Excluir Título");
            Console.WriteLine("5 - Visualizar Título");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
            }            
    }
}
