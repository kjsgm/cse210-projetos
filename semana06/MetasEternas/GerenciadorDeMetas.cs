
using System;
using System.Collections.Generic;

public class GerenciadorDeMetas
{
    private List<Meta> _metas;
    private int _pontos;

    public GerenciadorDeMetas()
    {
        _metas = new List<Meta>();
        _pontos = 0;
    }

    public void ExibirInfoJogador()
    {
        Console.WriteLine();
        Console.WriteLine("Pontuação atual: " + _pontos);
    }

    public void ListarNomesDasMetas()
    {
        Console.WriteLine("\n--- Minhas Metas ---");

        if (_metas.Count == 0)
        {
            Console.WriteLine("Nenhuma meta cadastrada.");
            return;
        }

        for (int i = 0; i < _metas.Count; i++)
        {
            Console.WriteLine(
                (i + 1) + ". " +
                _metas[i].ObterRepresentacaoEmTexto());
        }
    }

    public void ListarDetalhesDasMetas()
    {
        Console.WriteLine("\n--- Detalhes das Metas ---");

        foreach (Meta meta in _metas)
        {
            Console.WriteLine(meta.ObterDetalhesEmTexto());
        }
    }

    public void CriarMeta()
    {
        Console.WriteLine("\nQual tipo de meta deseja criar?");
        Console.WriteLine("1. Meta simples");
        Console.WriteLine("2. Meta eterna");
        Console.WriteLine("3. Meta de lista de tarefas");
        Console.Write("Escolha: ");

        string escolha = Console.ReadLine() ?? "";

        Console.Write("Nome da meta: ");
        string nome = Console.ReadLine() ?? "";

        Console.Write("Descrição: ");
        string descricao = Console.ReadLine() ?? "";

        Console.Write("Pontos por registro: ");

        if (!int.TryParse(Console.ReadLine(), out int pontos) ||
            pontos < 0)
        {
            Console.WriteLine("Quantidade de pontos inválida.");
            return;
        }

        if (escolha == "1")
        {
            _metas.Add(new MetaSimples(nome, descricao, pontos));
        }
        else if (escolha == "2")
        {
            _metas.Add(new MetaEterna(nome, descricao, pontos));
        }
        else if (escolha == "3")
        {
            Console.Write("Quantas vezes precisa realizar a meta? ");

            if (!int.TryParse(Console.ReadLine(), out int total) ||
                total <= 0)
            {
                Console.WriteLine("Quantidade de vezes inválida.");
                return;
            }

            Console.Write("Bônus pela conclusão: ");

            if (!int.TryParse(Console.ReadLine(), out int bonus) ||
                bonus < 0)
            {
                Console.WriteLine("Bônus inválido.");
                return;
            }

            _metas.Add(
                new MetaDeListaDeTarefas(
                    nome, descricao, pontos, total, bonus));
        }
        else
        {
            Console.WriteLine("Opção inválida.");
            return;
        }

        Console.WriteLine("Meta criada com sucesso!");
    }

    public void RegistrarEvento()
    {
        ListarNomesDasMetas();

        if (_metas.Count == 0)
        {
            return;
        }

        Console.Write("Qual meta deseja registrar? ");

        if (!int.TryParse(Console.ReadLine(), out int escolha) ||
            escolha < 1 || escolha > _metas.Count)
        {
            Console.WriteLine("Número de meta inválido.");
            return;
        }

        Meta meta = _metas[escolha - 1];

        if (meta is MetaSimples && meta.EstaConcluida())
        {
            Console.WriteLine("Essa meta simples já foi concluída.");
            return;
        }

        if (meta is MetaDeListaDeTarefas && meta.EstaConcluida())
        {
            Console.WriteLine("Essa meta de lista já foi concluída.");
            return;
        }

        bool estavaConcluida = meta.EstaConcluida();

        meta.RegistrarEvento();
        _pontos += meta.ObterPontos();

        if (meta is MetaDeListaDeTarefas lista &&
            !estavaConcluida && lista.EstaConcluida())
        {
            _pontos += lista.ObterBonus();
            Console.WriteLine(
                "Parabéns! Você ganhou " +
                lista.ObterBonus() + " pontos de bônus!");
        }

        Console.WriteLine("Registro realizado!");
        ExibirInfoJogador();
    }

    public void SalvarMetas()
    {
        using (System.IO.StreamWriter arquivo =
               new System.IO.StreamWriter("metas.txt"))
        {
            arquivo.WriteLine(_pontos);

            foreach (Meta meta in _metas)
            {
                arquivo.WriteLine(meta.ObterDadosParaSalvar());
            }
        }

        Console.WriteLine("Metas salvas com sucesso!");
    }

    public void CarregarMetas()
    {
        if (!System.IO.File.Exists("metas.txt"))
        {
            Console.WriteLine("Nenhum arquivo salvo foi encontrado.");
            return;
        }

        string[] linhas = System.IO.File.ReadAllLines("metas.txt");

        if (linhas.Length == 0 ||
            !int.TryParse(linhas[0], out int pontosSalvos))
        {
            Console.WriteLine("O arquivo salvo é inválido.");
            return;
        }

        List<Meta> metasCarregadas = new List<Meta>();

        for (int i = 1; i < linhas.Length; i++)
        {
            string[] partes = linhas[i].Split('|');

            try
            {
                if (partes[0] == "Simples" && partes.Length == 5)
                {
                    metasCarregadas.Add(
                        new MetaSimples(
                            partes[1],
                            partes[2],
                            int.Parse(partes[3]),
                            bool.Parse(partes[4])));
                }
                else if (partes[0] == "Eterna" && partes.Length == 4)
                {
                    metasCarregadas.Add(
                        new MetaEterna(
                            partes[1],
                            partes[2],
                            int.Parse(partes[3])));
                }
                else if (partes[0] == "Lista" && partes.Length == 7)
                {
                    metasCarregadas.Add(
                        new MetaDeListaDeTarefas(
                            partes[1],
                            partes[2],
                            int.Parse(partes[3]),
                            int.Parse(partes[5]),
                            int.Parse(partes[6]),
                            int.Parse(partes[4])));
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(
                    "Uma meta do arquivo não pôde ser carregada.");
            }
        }

        _metas = metasCarregadas;
        _pontos = pontosSalvos;

        Console.WriteLine("Metas carregadas com sucesso!");
        ExibirInfoJogador();
    }

    public void RefletirSobreProgresso()
    {
        string[] mensagens =
        {
        "Pequenas escolhas feitas com amor podem transformar uma vida.",
        "O progresso verdadeiro também está nas lições que aprendemos.",
        "A fé e a perseverança nos ajudam a continuar nos dias difíceis.",
        "Dedicar tempo à família e ao próximo também é uma forma de crescer."
    };

        Random random = new Random();

        Console.WriteLine("\n--- Meu Crescimento Pessoal ---");
        Console.WriteLine(mensagens[random.Next(mensagens.Length)]);

        Console.WriteLine();
        Console.WriteLine(
            "O que estou aprendendo com minhas metas?");
        Console.Write("Escreva sua reflexão: ");

        string reflexao = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(reflexao))
        {
            Console.WriteLine("Nenhuma reflexão foi registrada.");
            return;
        }

        string registro =
            DateTime.Now.ToString("dd/MM/yyyy HH:mm") +
            Environment.NewLine +
            reflexao +
            Environment.NewLine +
            Environment.NewLine;

        System.IO.File.AppendAllText("reflexoes.txt", registro);

        Console.WriteLine("Sua reflexão foi salva com sucesso!");
    }

    public void ExibirReflexoesSalvas()
    {
        Console.WriteLine("\n--- Minhas Reflexões ---");

        if (!System.IO.File.Exists("reflexoes.txt"))
        {
            Console.WriteLine("Você ainda não tem reflexões salvas.");
            return;
        }

        string reflexoes =
            System.IO.File.ReadAllText("reflexoes.txt");

        Console.WriteLine(reflexoes);
    }

    public void Iniciar()
    {
        string escolha = "";

        while (escolha != "0")
        {
            Console.WriteLine("\n=== PROGRAMA DE METAS ETERNAS ===");
            Console.WriteLine("1. Exibir pontuação");
            Console.WriteLine("2. Listar metas");
            Console.WriteLine("3. Criar nova meta");
            Console.WriteLine("4. Registrar evento");
            Console.WriteLine("5. Salvar metas");
            Console.WriteLine("6. Carregar metas");
            Console.WriteLine("7. Refletir sobre meu progresso");
            Console.WriteLine("8. Ler minhas reflexões");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            escolha = Console.ReadLine() ?? "";

            switch (escolha)
            {
                case "1":
                    ExibirInfoJogador();
                    break;

                case "2":
                    ListarNomesDasMetas();
                    ListarDetalhesDasMetas();
                    break;

                case "3":
                    CriarMeta();
                    break;

                case "4":
                    RegistrarEvento();
                    break;

                case "5":
                    SalvarMetas();
                    break;

                case "6":
                    CarregarMetas();
                    break;

                case "7":
                    RefletirSobreProgresso();
                    break;

                case "8":
                    ExibirReflexoesSalvas();
                    break;

                case "0":
                    Console.WriteLine("Até a próxima!");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
