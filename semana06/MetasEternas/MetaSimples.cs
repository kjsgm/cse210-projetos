
public class MetaSimples : Meta
{
    private bool _estaConcluida;

    public MetaSimples(
        string nome,
        string descricao,
        int pontos,
        bool estaConcluida = false)
        : base(nome, descricao, pontos)
    {
        _estaConcluida = estaConcluida;
    }

    public override void RegistrarEvento()
    {
        _estaConcluida = true;
    }

    public override bool EstaConcluida()
    {
        return _estaConcluida;
    }

    public override string ObterRepresentacaoEmTexto()
    {
        string status = _estaConcluida ? "[X]" : "[ ]";

        return "Simples:" + status + ":" +
               ObterNome() + ":" +
               ObterDetalhesEmTexto() + ":" +
               ObterPontos();
    }

    public override string ObterDadosParaSalvar()
    {
        return "Simples|" +
               ObterNome() + "|" +
               ObterDescricao() + "|" +
               ObterPontos() + "|" +
               _estaConcluida;
    }

}
