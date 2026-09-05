using System;

class Program
{
    static void Main(string[] args)
    {
        Random geradorAleatorio = new Random();
        int numeroMagico = geradorAleatorio.Next(1, 101);

        int palpite = -1;

        while (palpite != numeroMagico)
        {
            Console.Write("Qual é o seu palpite? ");
            string entrada = Console.ReadLine();
            palpite = int.Parse(entrada);

            if (palpite < numeroMagico)
            {
                Console.WriteLine("Mais alto");
            }
            else if (palpite > numeroMagico)
            {
                Console.WriteLine("Mais baixo");
            }
            else
            {
                Console.WriteLine("Você adivinhou!");
            }
        }
    }
}