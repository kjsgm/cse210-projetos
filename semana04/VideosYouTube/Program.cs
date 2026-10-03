Video video1 = new Video(
    "Como aprender C#",
    "Katherine",
    420
);
video1.AdicionarComentario(new Comentario(
    "Maria",
    "Gostei muito desse vídeo!"
));

video1.AdicionarComentario(new Comentario(
    "João",
    "A explicação foi muito clara."
));

video1.AdicionarComentario(new Comentario(
    "Ana",
    "Aprendi bastante com esse conteúdo."
));
Video video2 = new Video(
    "Dicas para estudar programação",
    "David",
    600
);
video2.AdicionarComentario(new Comentario(
    "Pedro",
    "Essas dicas ajudaram bastante."
));

video2.AdicionarComentario(new Comentario(
    "Laura",
    "Vou começar a estudar dessa forma."
));

video2.AdicionarComentario(new Comentario(
    "Rafael",
    "Muito bom o conteúdo!"
));
Video video3 = new Video(
    "Programação Orientada a Objetos",
    "Christopher",
    780
);
video3.AdicionarComentario(new Comentario(
    "Lucas",
    "Agora entendi melhor esse assunto."
));

video3.AdicionarComentario(new Comentario(
    "Julia",
    "Gostei muito da explicação."
));

video3.AdicionarComentario(new Comentario(
    "Marcos",
    "Esse vídeo foi muito útil."
));
List<Video> videos = new List<Video>
{
    video1,
    video2,
    video3
};
foreach (Video video in videos)
{
    Console.WriteLine($"Título: {video.GetTitulo()}");
    Console.WriteLine($"Autor: {video.GetAutor()}");
    Console.WriteLine($"Duração: {video.GetDuracao()} segundos");
    Console.WriteLine($"Comentários: {video.ObterQuantidadeComentarios()}");

    foreach (Comentario comentario in video.GetComentarios())
    {
        Console.WriteLine($"- {comentario.GetNome()}: {comentario.GetTexto()}");
    }

    Console.WriteLine();
}