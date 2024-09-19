using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Common.Models
{
    public class ColecaoDeLivros
    {
        public ColecaoDeLivros()
        {
            ListaDeLivros = new();
        }
        public List<Livro> ListaDeLivros { get; set; }

        public void AdicionarLivro()
        {
            string nome, autor, isbn;
            Console.WriteLine("Informe o nome do livro: ");
            nome = Console.ReadLine();
            Console.WriteLine("Informe o nome do autor: ");
            autor = Console.ReadLine();
            Console.WriteLine("Informe o ISBN do livro: ");
            isbn = Console.ReadLine();

            Livro livro = new(nome, autor, isbn);
            ListaDeLivros.Add(livro);
            Console.WriteLine("Livro adicionado com sucesso!!");
        }

        public void ListarLivrosDaColecao()
        {
            if (ListaDeLivros.Count <= 0)
            {
                Console.WriteLine("Nenhum livro foi cadastrado.");
            }
            else
            {
                foreach (Livro item in ListaDeLivros)
                {
                    item.Informacao();
                }
            }

        }

        public Livro PesquisarLivro()
        {
            Console.WriteLine("Digite o nome de um livro");
            string nome = Console.ReadLine();

            foreach (Livro item in ListaDeLivros)
            {
                if (item.Nome.Equals(nome, StringComparison.CurrentCultureIgnoreCase))
                {
                    return item;
                }

            }
            throw new ArgumentException("Livro não encontrado");
        }

        public void AtualizarDisponibilidade(Livro livro)
        {
            foreach (var item in ListaDeLivros)
            {
                if (item.Nome == livro.Nome)
                {
                    if (item.Disponivel == true)
                    {
                        item.Emprestar();
                    }
                    else
                    {
                        item.Devolver();
                    }

                }
            }
        }

    }
}