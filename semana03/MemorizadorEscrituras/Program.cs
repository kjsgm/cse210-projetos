using System;

class Program
{
    static void Main(string[] args)
    {
        Referencia referencia = new Referencia("Isaías", 41, 10);

        Escritura escritura = new Escritura(
            referencia,
            "Não temas, porque eu sou contigo; não te assombres, porque eu sou teu Deus; eu te fortaleço, e te ajudo, e te sustento."
        );
        while (!escritura.EstaCompletamenteOculta())
        {
            Console.WriteLine(escritura.ObterTexto());
            Console.WriteLine();
            Console.Write("Pressione Enter para continuar ou digite 'sair' para encerrar: ");

            string entrada = Console.ReadLine() ?? "";

            if (entrada == "sair")
            {
                return;
            }

            // Fiz uma pequena melhoria para não esconder de novo uma palavra que já foi escondida.
            // Assim, cada vez que aperto Enter, novas palavras são escondidas.
            escritura.OcultarPalavrasAleatorias(3);
            Console.Clear();
        }
    }
}