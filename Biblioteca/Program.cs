using System.ComponentModel;
using Biblioteca.Common.Models;


ColecaoDeLivros BB = new();
ColecaoDeUsuarios U = new();
string? opcao;

Console.WriteLine("------Bem vindo a Biblioteca------");
while (true)
{
    Console.Clear();
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("[1] Cadastrar livro");
    Console.WriteLine("[2] Cadastrar usuário");
    Console.WriteLine("[3] Pegar livro emprestado");
    Console.WriteLine("[4] Devolver livro");
    Console.WriteLine("[5] Livros da biblioteca");
    Console.WriteLine("[6] Listar usuários e livros em posse");
    Console.WriteLine("[0] Sair");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            try
            {
                BB.AdicionarLivro();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case "2":
            try
            {
                U.AdicionarUsuario();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case "3":
            try
            {
                Livro LivroSelecionado = new(BB.PesquisarLivro());
                Usuario UsuarioSelecionado = new(U.PesquisarUsuario());
                UsuarioSelecionado.EmprestarLivro(LivroSelecionado);
                BB.AtualizarDisponibilidade(LivroSelecionado);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case "4":
            try
            {
                Livro LivroSelecionado = new(BB.PesquisarLivro());
                Usuario UsuarioSelecionado = new(U.PesquisarUsuario());
                UsuarioSelecionado.DevolverLivro(LivroSelecionado);
                BB.AtualizarDisponibilidade(LivroSelecionado);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case "5":
            BB.ListarLivrosDaColecao();
            break;
        case "6":
            U.ListarUsuarios();
            break;
        case "0":
            Console.WriteLine("Saindo...");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("\nPressione uma tecla para continuar");
    Console.ReadLine();
}



