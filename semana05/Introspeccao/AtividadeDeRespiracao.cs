using System;
using System.Threading;

public class AtividadeDeRespiracao : Atividade
{
    public AtividadeDeRespiracao()
    {
        _nome = "Respiração";
        _descricao = "Esta atividade vai ajudar você a relaxar, respirando lentamente. Inspire e expire com calma.";
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        DateTime fim = DateTime.Now.AddSeconds(_duracao);

        while (DateTime.Now < fim)
        {
            Console.Write("Inspire...");
            ExibirContagemRegressiva(4);
            Console.WriteLine();

            if (DateTime.Now >= fim)
            {
                break;
            }

            Console.Write("Expire...");
            ExibirContagemRegressiva(4);
            Console.WriteLine();
        }

        ExibirMensagemFinal();
    }
}