using System;
using System.Collections.Generic;
using System.Threading;

public class AtividadeDeListagem : Atividade
{
    private int _contador;
    private List<string> _perguntas;
    private List<string> _respostas;
    private Random _random = new Random();

    public AtividadeDeListagem()
    {
        _nome = "Listagem";
        _descricao = "Esta atividade vai ajudar você a reconhecer coisas positivas em sua vida.";

        _contador = 0;

        _perguntas = new List<string>
        {
            "Quem são pessoas pelas quais você é grato?",
            "Quais são algumas de suas qualidades?",
            "Quem você ajudou nesta semana?",
            "Quando sentiu a influência do Espírito Santo?",
            "Quem é um exemplo positivo para você?"
        };

        _respostas = new List<string>();
    }

    public void Executar()
    {
        _contador = 0;
        _respostas.Clear();

        ExibirMensagemInicial();

        Console.WriteLine("Pense na seguinte pergunta:");
        ObterPerguntaAleatoria();

        ExibirContagemRegressiva(5);
        Console.WriteLine();
        Console.WriteLine("Digite suas respostas, uma por linha.");
        Console.WriteLine("Pressione Enter depois de cada resposta.");
        Console.WriteLine("Digite 'fim' para terminar antes do tempo.");
        Console.WriteLine();

        DateTime fim = DateTime.Now.AddSeconds(_duracao);
        string respostaAtual = "";

        Console.Write("> ");

        while (DateTime.Now < fim)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo tecla = Console.ReadKey(true);

                if (tecla.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();

                    if (respostaAtual.Trim().Equals(
                        "fim", StringComparison.OrdinalIgnoreCase))
                    {
                        respostaAtual = "";
                        break;
                    }

                    AdicionarResposta(respostaAtual);
                    respostaAtual = "";

                    if (DateTime.Now < fim)
                    {
                        Console.Write("> ");
                    }
                }
                else if (tecla.Key == ConsoleKey.Backspace)
                {
                    if (respostaAtual.Length > 0)
                    {
                        respostaAtual = respostaAtual.Substring(
                            0, respostaAtual.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (!char.IsControl(tecla.KeyChar))
                {
                    respostaAtual += tecla.KeyChar;
                    Console.Write(tecla.KeyChar);
                }
            }
            else
            {
                Thread.Sleep(50);
            }
        }

        if (!string.IsNullOrWhiteSpace(respostaAtual))
        {
            AdicionarResposta(respostaAtual);
        }

        Console.WriteLine();
        Console.WriteLine($"Você listou {_contador} respostas!");

        ExibirMensagemFinal();
    }

    private void AdicionarResposta(string resposta)
    {
        if (!string.IsNullOrWhiteSpace(resposta))
        {
            _respostas.Add(resposta.Trim());
            _contador++;
        }
    }

    public string ObterPerguntaAleatoria()
    {
        string pergunta = _perguntas[_random.Next(_perguntas.Count)];
        Console.WriteLine(pergunta);
        return pergunta;
    }

    public List<string> ObterListaDoUsuario()
    {
        return _respostas;
    }
}