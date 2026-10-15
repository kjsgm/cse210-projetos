
public class MetaEterna : Meta
{
    public MetaEterna(string nome, string descricao, int pontos)
        : base(nome, descricao, pontos)
    {
    }

    public override void RegistrarEvento()
    {
        // A meta eterna continua disponível para novos registros.
    }

    public override bool EstaConcluida()
    {
        return false;
    }

    public override string ObterRepresentacaoEmTexto()
    {
        return "Eterna:[ ]:" +
               ObterNome() + ":" +
               ObterDetalhesEmTexto() + ":" +
               ObterPontos();
    }

    public override string ObterDadosParaSalvar()
    {
        return "Eterna|" +
               ObterNome() + "|" +
               ObterDescricao() + "|" +
               ObterPontos();
    }

}
