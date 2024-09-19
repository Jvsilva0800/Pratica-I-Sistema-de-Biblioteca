using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace Biblioteca.Common.Models
{
    public class Livro
    {
        public Livro()
        {

        }
        public Livro(Livro livro)
        {
            Disponivel = livro.Disponivel;
            Nome = livro.Nome;
            Autor = livro.Autor;
            Isbn = livro.Isbn;

        }
        public Livro(string nome, string autor, string isbn)
        {
            Nome = nome;
            Autor = autor;
            Isbn = isbn;
        }
        private string _nome;
        private string _autor;
        private string _isbn;
        public bool Disponivel = true;
        public string Nome
        {
            get => _nome;
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("O nome do livro não pode ser vazio.");
                }
                _nome = value;
            }
        }
        public string Autor
        {
            get => _autor;
            set
            {
                if (value == "")
                {
                    _autor = "Desconhecido";
                }
                else
                {
                    _autor = value;
                }

            }
        }
        public string Isbn
        {
            get => _isbn;
            set
            {
                if (ValidarCodigoIsbn(value))
                {
                    _isbn = value;
                }
                else
                {
                    throw new ArgumentException("Código ISBN inválido");
                }
            }
        }

        public bool Emprestar()
        {
            if (Disponivel)
            {
                Disponivel = false;
                return true;
            }
            return false;
        }

        public void Devolver()
        {
            Disponivel = true;
        }

        private bool ValidarCodigoIsbn(string codigo)
        {
            codigo = codigo.ToUpper().Replace(" ", "").Replace("-", "");
            string padrao = @"^(\d{9}[0-9X]|\d{13})$";
            return Regex.IsMatch(codigo, padrao);
        }

        public void Informacao()
        {
            Console.WriteLine($"Título: {Nome} - Autor: {Autor} - Disponível: {(Disponivel ? "Sim" : "Não")}");
        }

    }
}