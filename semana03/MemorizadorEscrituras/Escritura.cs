class Escritura
{
    private Referencia _referencia;
    private List<Palavra> _palavras;

    public Escritura(Referencia referencia, string texto)
    {
        _referencia = referencia;
        _palavras = new List<Palavra>();

        string[] palavras = texto.Split(' ');

        foreach (string palavra in palavras)
        {
            _palavras.Add(new Palavra(palavra));
        }
    }

    public string ObterTexto()
    {
        string texto = "";

        foreach (Palavra palavra in _palavras)
        {
            texto += palavra.ObterTexto() + " ";
        }

        return $"{_referencia.ObterTexto()} {texto.Trim()}";
    }

    public void OcultarPalavrasAleatorias(int numeroParaOcultar)
    {
        Random random = new Random();

        for (int i = 0; i < numeroParaOcultar; i++)
        {
            List<int> indicesVisiveis = new List<int>();

            for (int j = 0; j < _palavras.Count; j++)
            {
                if (!_palavras[j].EstaOculta())
                {
                    indicesVisiveis.Add(j);
                }
            }

            if (indicesVisiveis.Count == 0)
            {
                return;
            }

            int indiceAleatorio = random.Next(indicesVisiveis.Count);
            int indicePalavra = indicesVisiveis[indiceAleatorio];

            _palavras[indicePalavra].Ocultar();
        }
    }

    public bool EstaCompletamenteOculta()
    {
        foreach (Palavra palavra in _palavras)
        {
            if (!palavra.EstaOculta())
            {
                return false;
            }
        }

        return true;
    }
}