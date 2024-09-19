using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Biblioteca.Common.Models
{
    public class ColecaoDeUsuarios
    {
        public ColecaoDeUsuarios()//É instanciado a lista de usuários vazia sempre que um objeto é criado
        {
            ListaDeUsuarios = new();
        }
        public List<Usuario> ListaDeUsuarios//Lista de Usuários
        {
            get;
            set;
        }

        public void AdicionarUsuario()//Adiciona um Usuário a lista
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

        public Usuario PesquisarUsuario()//Utilizada para pesquisar um usuário específico pelo nome
        {
            Console.WriteLine("Digite o nome de um usuário");
            string nome = Console.ReadLine();//Recebe o nome do usuário digitado no terminal

            foreach (Usuario item in ListaDeUsuarios)
            {
                if (item.Nome.Equals(nome, StringComparison.CurrentCultureIgnoreCase))//Quando os nomes coincidem é retornado o usuário em questão da lista de usuários cadastrados no sistema
                {
                    return item;
                }

            }
            throw new ArgumentException("Usuário não encontrado");//Caso ele não esteja na lista
        }
    }
}