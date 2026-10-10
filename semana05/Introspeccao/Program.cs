using System;

// Recurso criativo: a atividade de Listagem permite registrar várias respostas,
// encerra automaticamente ao terminar o tempo e mostra quantas respostas foram registradas.
class Program
{
    static void Main(string[] args)
    {
        string opcao = "";

        while (opcao != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu de Atividades");
            Console.WriteLine();
            Console.WriteLine("1. Atividade de Respiração");
            Console.WriteLine("2. Atividade de Reflexão");
            Console.WriteLine("3. Atividade de Listagem");
            Console.WriteLine("4. Sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");

            opcao = Console.ReadLine();

            Console.WriteLine();

            switch (opcao)
            {
                case "1":
                    AtividadeDeRespiracao respiracao = new AtividadeDeRespiracao();
                    respiracao.Executar();
                    break;

                case "2":
                    AtividadeDeReflexao reflexao = new AtividadeDeReflexao();
                    reflexao.Executar();
                    break;

                case "3":
                    AtividadeDeListagem listagem = new AtividadeDeListagem();
                    listagem.Executar();
                    break;

                case "4":
                    Console.WriteLine("Obrigado por utilizar o Programa de Introspecção!");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            if (opcao != "4")
            {
                Console.WriteLine();
                Console.WriteLine("Continue se esforçando para se tornar uma pessoa melhor a cada dia.");
                Console.WriteLine();
                Console.WriteLine("Pressione Enter para voltar ao menu.");
                Console.ReadLine();
            }
        }
    }
}