using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Biblioteca.Common.Models
{
    public class ColecaoDeUsuarios
    {
        public ColecaoDeUsuarios()
        {
            ListaDeUsuarios = new();
        }
        public List<Usuario> ListaDeUsuarios
        {
            get;
            set;
        }

        public void AdicionarUsuario()
        {
            string nome, cpf;
            Console.WriteLine("Informe o nome do usuário:");
            nome = Console.ReadLine();
            Console.WriteLine("Informe o CPF do usuário:");
            cpf = Console.ReadLine();

            Usuario usuario = new(nome, cpf);
            ListaDeUsuarios.Add(usuario);

            Console.WriteLine("Usuário cadastrado com sucesso");
        }

        public void ListarUsuarios()
        {
            foreach (var item in ListaDeUsuarios)
            {
                item.Informacao();
            }
        }

        public Usuario PesquisarUsuario()
        {
            Console.WriteLine("Digite o nome de um usuário");
            string nome = Console.ReadLine();

            foreach (Usuario item in ListaDeUsuarios)
            {
                if (item.Nome.Equals(nome, StringComparison.CurrentCultureIgnoreCase))
                {
                    return item;
                }

            }
            throw new ArgumentException("Usuário não encontrado");
        }
    }
}