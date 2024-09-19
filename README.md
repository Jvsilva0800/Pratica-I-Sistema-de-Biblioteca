# Pratica-I-Sistema-de-Biblioteca

## Métodos

## Problema: Sistema de Gerenciamento de Biblioteca
Você foi contratado para desenvolver um sistema simples de gerenciamento de biblioteca. O sistema deve permitir a gestão de livros e usuários, além de registrar empréstimos e devoluções.

### Requisitos:
Classes principais:

- Livro: Representa um livro da biblioteca.
- Atributos: 
    - titulo (String): o título do livro.
    - autor (String): o nome do autor do livro.
    - isbn (String): código ISBN do livro.
    - disponivel (Boolean): indica se o livro está disponível para empréstimo.
- Métodos:
    - emprestar(): Se o livro estiver disponível, marca como emprestado (disponível = False).
    - devolver(): Marca o livro como disponível novamente (disponível = True).

- Usuario: Representa um usuário da biblioteca.
- Atributos:
    - nome (String): o nome do usuário.
    - cpf (String): o CPF do usuário.
    - livros_emprestados (lista de Livro): lista de livros emprestados pelo usuário.
- Métodos:
    - emprestar_livro(livro): Empresta um livro ao usuário se o livro estiver disponível.
    - devolver_livro(livro): Devolve um livro emprestado.

### Coleção de dados:

Mantenha uma lista de todos os livros disponíveis na biblioteca.
Mantenha uma lista de todos os usuários registrados.
Funcionalidades principais:

- Adicionar novos livros ao sistema.
- Adicionar novos usuários ao sistema.
- Permitir que um usuário empreste um livro, desde que o livro esteja disponível.
- Permitir que um usuário devolva um livro.
- Listar todos os livros da biblioteca, indicando quais estão disponíveis e quais estão emprestados.
- Listar todos os usuários e os livros que eles estão com posse, se houver.

