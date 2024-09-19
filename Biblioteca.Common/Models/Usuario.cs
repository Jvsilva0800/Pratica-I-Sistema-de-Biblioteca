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
                if (ValidarCpf(value))
                {
                    _cpf = value;
                }
                else
                {
                    throw new ArgumentException("CPF inválido.");
                }
            }
        }

        public void EmprestarLivro(Livro livro)
        {
            if (livro.Emprestar())
            {
                livro.Emprestar();
                LivrosEmprestados.Add(livro);
                Console.WriteLine("Livro emprestado com sucesso");
            }
            else
            {
                throw new ArgumentException("Livro está emprestado para alguém");
            }
        }

        public void DevolverLivro(Livro livro)
        {
            foreach (var item in LivrosEmprestados)
            {
                if (item.Nome.Equals(livro.Nome, StringComparison.CurrentCultureIgnoreCase))
                {
                    LivrosEmprestados.Remove(item);
                    Console.WriteLine("Livro devolvido com sucesso");
                    return;
                }
            }
            throw new ArgumentException("Esse livro não está com esse usuário");
        }

        public bool ValidarCpf(string cpf)
        {
            string padrao = @"^(\d{3}\.\d{3}\.\d{3}-\d{2}|\d{11})$";
            return Regex.IsMatch(cpf, padrao);
        }
        public void Informacao()
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