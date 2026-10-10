using System;
using System.Collections.Generic;

public class AtividadeDeReflexao : Atividade
{
    private List<string> _reflexoes;
    private List<string> _perguntas;
    private Random _random = new Random();

    public AtividadeDeReflexao()
    {
        _nome = "Reflexão";
        _descricao = "Esta atividade vai ajudar você a refletir sobre momentos em que demonstrou força e resiliência.";

        _reflexoes = new List<string>
        {
            "Pense em uma ocasião em que você ajudou alguém.",
            "Pense em uma ocasião em que fez algo difícil.",
            "Pense em uma ocasião em que defendeu alguém que precisava de ajuda.",
            "Pense em uma ocasião em que fez algo bom sem esperar nada em troca."
        };

        _perguntas = new List<string>
        {
            "Por que essa experiência foi importante para você?",
            "Como você se sentiu nessa situação?",
            "O que aprendeu com essa experiência?",
            "Como pode usar esse aprendizado no futuro?",
            "O que essa experiência ensina sobre você?",
            "Como essa experiência ajudou outra pessoa?"
        };
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        DateTime fim = DateTime.Now.AddSeconds(_duracao);

        Console.WriteLine("Considere a seguinte situação:");
        ObterReflexoesAleatorias();
        ExibirProgresso(3);

        while (DateTime.Now < fim)
        {
            ObterPerguntasAleatorias();
            ExibirProgresso(5);
        }

        ExibirMensagemFinal();
    }

    public string ObterReflexoesAleatorias()
    {
        string reflexao = _reflexoes[_random.Next(_reflexoes.Count)];
        Console.WriteLine(reflexao);
        return reflexao;
    }

    public string ObterPerguntasAleatorias()
    {
        string pergunta = _perguntas[_random.Next(_perguntas.Count)];
        Console.WriteLine(pergunta);
        return pergunta;
    }

    public void ExibirReflexoes()
    {
        ObterReflexoesAleatorias();
    }

    public void ExibirPerguntas()
    {
        ObterPerguntasAleatorias();
    }
}