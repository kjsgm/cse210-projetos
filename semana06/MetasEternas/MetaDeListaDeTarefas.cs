
public class MetaDeListaDeTarefas : Meta
{
    private int _concluidas;
    private int _total;
    private int _bonus;

    public MetaDeListaDeTarefas(
        string nome,
        string descricao,
        int pontos,
        int total,
        int bonus,
        int concluidas = 0)
        : base(nome, descricao, pontos)
    {
        _concluidas = concluidas;
        _total = total;
        _bonus = bonus;
    }

    public override void RegistrarEvento()
    {
        if (_concluidas < _total)
        {
            _concluidas++;
        }
    }

    public override bool EstaConcluida()
    {
        return _concluidas >= _total;
    }

    public override string ObterDetalhesEmTexto()
    {
        return base.ObterDetalhesEmTexto() +
               " - Concluída " + _concluidas +
               "/" + _total + " vezes";
    }


    public override string ObterRepresentacaoEmTexto()
    {
        string status = EstaConcluida() ? "[X]" : "[ ]";

        return "Lista:" + status + ":" +
               ObterNome() + ": " +
               ObterDetalhesEmTexto() + ": " +
               ObterPontos();
    }

    public override string ObterDadosParaSalvar()
    {
        return "Lista|" +
               ObterNome() + "|" +
               ObterDescricao() + "|" +
               ObterPontos() + "|" +
               _concluidas + "|" +
               _total + "|" +
               _bonus;
    }


    public int ObterBonus()
    {
        return _bonus;
    }

    public int ObterTotal()
    {
        return _total;
    }

    public int ObterConcluidas()
    {
        return _concluidas;
    }
}
