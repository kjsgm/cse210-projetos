using System;
using System.Threading;

public class Atividade
{
    protected string _nome;
    protected string _descricao;
    protected int _duracao;

    public Atividade()
    {
        _nome = "";
        _descricao = "";
        _duracao = 0;
    }

    public void ExibirMensagemInicial()
    {
        Console.WriteLine($"Bem-vindo à atividade de {_nome}.");
        Console.WriteLine();
        Console.WriteLine(_descricao);
        Console.WriteLine();
        Console.Write("Por quantos segundos você gostaria de realizar esta atividade? ");
        _duracao = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Prepare-se...");
        ExibirProgresso(3);
    }

    public void ExibirMensagemFinal()
    {
        Console.WriteLine();
        Console.WriteLine("Muito bem! Você concluiu a atividade.");
        ExibirProgresso(3);
    }

    public void ExibirProgresso(int segundos)
    {
        for (int i = 0; i < segundos; i++)
        {
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b/");
            Thread.Sleep(250);
            Console.Write("\b \b-");
            Thread.Sleep(250);
            Console.Write("\b \b\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
        }

        Console.WriteLine();
    }

    public void ExibirContagemRegressiva(int segundos)
    {
        for (int i = segundos; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}