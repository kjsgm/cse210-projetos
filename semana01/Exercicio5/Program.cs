using System;

class Program
{
    static void Main(string[] args)
    {
        ExibirBoasVindas();

        string nomeUsuario = PerguntarNomeUsuario();
        int numeroFavorito = PerguntarNumeroFavorito();
        int numeroAoQuadrado = ElevarAoQuadrado(numeroFavorito);

        ExibirResultado(nomeUsuario, numeroAoQuadrado);
    }

    static void ExibirBoasVindas()
    {
        Console.WriteLine("Bem-vindo ao programa!");
    }

    static string PerguntarNomeUsuario()
    {
        Console.Write("Por favor, insira seu nome: ");
        string nome = Console.ReadLine();
        return nome;
    }

    static int PerguntarNumeroFavorito()
    {
        Console.Write("Por favor, insira seu número favorito: ");
        string entrada = Console.ReadLine();
        int numero = int.Parse(entrada);
        return numero;
    }

    static int ElevarAoQuadrado(int numero)
    {
        int resultado = numero * numero;
        return resultado;
    }

    static void ExibirResultado(string nome, int numeroAoQuadrado)
    {
        Console.WriteLine($"{nome}, o quadrado do seu número é {numeroAoQuadrado}");
    }
}