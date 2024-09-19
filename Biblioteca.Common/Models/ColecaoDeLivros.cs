using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Common.Models
{
    public class ColecaoDeLivros
    {
        public ColecaoDeLivros()//Construtor ca ColecaoDeLivros quando um objeto é criado é instanciado uma lista de Livros vazia
        {
            ListaDeLivros = new();
        }
        public List<Livro> ListaDeLivros { get; set; }//Lista de Livro

        public void AdicionarLivro()//Recebe os valores do livro que se deseja adicionar a lista de Livros da Biblioteca
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

        public void ListarLivrosDaColecao()//É listado os livros disponíves na Biblioteca caso exista algum
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

        public void AtualizarDisponibilidade(Livro livro)//Atualiza a disponibilidade de um livro específico passado como parâmetro, essa função só é chamada quando se deseja pegar um livro emprestado ou devolver um livro para que a variável de Disponivel seja atualizada, não permitindo que um livro ja pego por algum usuário seja pego por outro.
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