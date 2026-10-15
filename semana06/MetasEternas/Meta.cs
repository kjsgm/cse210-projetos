
using System;

public abstract class Meta
{
    private string _nome;
    private string _descricao;
    private int _pontos;

    public Meta(string nome, string descricao, int pontos)
    {
        _nome = nome;
        _descricao = descricao;
        _pontos = pontos;
    }

    public abstract void RegistrarEvento();

    public abstract bool EstaConcluida();

    public virtual string ObterDetalhesEmTexto()
    {
        return _nome + " (" + _descricao + ")";
    }

    public abstract string ObterRepresentacaoEmTexto();
    public abstract string ObterDadosParaSalvar();

    public int ObterPontos()
    {
        return _pontos;
    }

    public string ObterNome()
    {
        return _nome;
    }
    public string ObterDescricao()
    {
        return _descricao;
    }
}
