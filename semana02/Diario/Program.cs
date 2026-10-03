using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string[] prompts =
        {
            "O que aconteceu hoje que te fez sorrir?",
            "Se você pudesse mudar algo do dia de hoje, o que mudaria?",
            "O que aconteceu hoje que te fez sentir gratidão?",
            "Fiz alguém se sentir amado hoje?",
            "Quais sentimentos levei ao Pai Celestial hoje?",
            "Em qual parte do dia pude sentir a companhia de Cristo?"
        };
        Random random = new Random();
        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Escrever uma nova entrada");
            Console.WriteLine("2. Exibir o diário");
            Console.WriteLine("3. Salvar o diário");
            Console.WriteLine("4. Carregar o diário");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");

            choice = Console.ReadLine();
            if (choice == "1")
            {
                int index = random.Next(prompts.Length);
                string prompt = prompts[index];

                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();
                string date = DateTime.Now.ToShortDateString();

                Entry entry = new Entry();

                entry._date = date;
                entry._promptText = prompt;
                entry._entryText = response;

                journal._entries.Add(entry);
                // Extra de criatividade: após registrar uma entrada,
                // o programa apresenta uma citação de Gordon B. Hinckley
                // para incentivar o usuário a escrever e refletir sobre seu dia.
                // Fonte: https://www.churchofjesuschrist.org/study/liahona/2001/01/an-humble-and-a-contrite-heart?lang=eng
                Console.WriteLine();
                Console.WriteLine("“Espero que escrevamos isso e reflitamos sobre isso até compreendermos profundamente seu significado...”");
                Console.WriteLine("— Gordon B. Hinckley");
            }
            if (choice == "2")
            {
                foreach (Entry entry in journal._entries)
                {
                    Console.WriteLine($"Data: {entry._date}");
                    Console.WriteLine($"Pergunta: {entry._promptText}");
                    Console.WriteLine($"Resposta: {entry._entryText}");
                    Console.WriteLine();
                }
            }
            if (choice == "3")
            {
                Console.Write("Digite o nome do arquivo: ");
                string fileName = Console.ReadLine();

                journal.SaveToFile(fileName);

                Console.WriteLine("Diário salvo com sucesso!");
            }
            if (choice == "4")
            {
                Console.Write("Digite o nome do arquivo: ");
                string fileName = Console.ReadLine();

                journal.LoadFromFile(fileName);

                Console.WriteLine("Diário carregado com sucesso!");
            }

            Console.WriteLine();
        }
    }
}