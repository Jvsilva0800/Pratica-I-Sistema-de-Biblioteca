using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Biblioteca.Common.Models
{
    public class Usuario
    {

        public Usuario()
        {
            LivrosEmprestados = new();
        }
        public Usuario(Usuario usuario)
        {
            LivrosEmprestados = usuario.LivrosEmprestados;
            Nome = usuario.Nome;
            Cpf = usuario.Cpf;
        }
        public Usuario(string nome, string cpf)
        {
            LivrosEmprestados = new();
            Nome = nome;
            Cpf = cpf;
        }
        private string _nome;
        private string _cpf;
        public List<Livro> LivrosEmprestados
        {
            get;
            set;
        }
        public string Nome
        {
            get => _nome;
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("O nome do usuário não pode estar vazio.");
                }
                _nome = value;
            }
        }
        public string Cpf
        {
            get => _cpf;
            set
            {
                if (ValidarCpf(value))//Validação do CPF
                {
                    _cpf = value;
                }
                else
                {
                    throw new ArgumentException("CPF inválido.");
                }
            }
        }

        public void EmprestarLivro(Livro livro)//Recebe como parâmetro um obejto livro
        {
            if (livro.Emprestar())//Caso a função emprestar retorne true significa que o livro está disponível e pode ser pego
            {
                livro.Emprestar();
                LivrosEmprestados.Add(livro);//Depois de pego, o livro é adicionado a lista de livros emprestados de cada usuário
                Console.WriteLine("Livro emprestado com sucesso");
            }
            else //Caso o livro estaja indisponivel para ser pego, por conta de sua disponibilidade, é lançado uma exceção
            {
                throw new ArgumentException("Livro está emprestado para alguém");
            }
        }

        public void DevolverLivro(Livro livro)//Recebe um objeto Livro como parâmetro
        {
            foreach (var item in LivrosEmprestados)//Faz uma varredura na lista de livros emprestados para retira-lo da lista, simbolizando que o livro foi devolvido a biblioteca
            {
                if (item.Nome.Equals(livro.Nome, StringComparison.CurrentCultureIgnoreCase))//É verificado se o nome do livro na lista de livros emprestados é igual ao recebido como parâmetro, pois o objeto livro recebido mesmo tendo as mesmas informações de algum livro da lista ainda assim não pode ser comparado como o mesmo objeto na memoria
                {
                    LivrosEmprestados.Remove(item);
                    Console.WriteLine("Livro devolvido com sucesso");
                    return;//return usado para finalizar a busca para que não dispare a exceção 
                }
            }
            throw new ArgumentException("Esse livro não está com esse usuário");
        }

        public bool ValidarCpf(string cpf)//Validação do CPF usando Regex, exemplo valido(123.555.666-52) ou (12345678911)
        {
            string padrao = @"^(\d{3}\.\d{3}\.\d{3}-\d{2}|\d{11})$";
            return Regex.IsMatch(cpf, padrao);
        }
        public void Informacao()//É exibido as informações do usuário juntamente com os livros que estão em sua posse
        {
            Console.WriteLine($"Usuário nome: {Nome} - CPF: {Cpf}");
            if (LivrosEmprestados.Count <= 0)
            {
                Console.WriteLine("Não possuí livros emprestados");
            }
            else
            {
                foreach (var item in LivrosEmprestados)
                {
                    item.Informacao();
                }
            }
        }
    }
}