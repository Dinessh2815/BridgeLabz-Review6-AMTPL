namespace MusicPlayerAppliation
{
    internal class MusicPlayer
    {
        class Song
        {
            public string Title { get; set; }
            public int Duration { get; set; }

            Random random = new Random();

            public Song(string title)
            {
                Title = title;
                Duration = random.Next(1, 5);
            }

            
        }

        class Playlist
        {

            Queue<Song> songs = new Queue<Song>();
            Stack<Song> reverseSongs = new Stack<Song>();
            public void AddSong(Song song)
            {
                songs.Enqueue(song);
            }

            public void PlayFromStart()
            {
                Console.WriteLine("\nPlaying from the start\n");
                foreach(Song song in songs)
                {
                    Console.WriteLine($"Song : {song.Title} Duration : {song.Duration}");
                }
            }

            public void PlayFromLast()
            {
                Console.WriteLine("\nPlaying From last\n");
                
                
                foreach(Song song in songs)
                {
                    reverseSongs.Push(songs.Dequeue());
                }


                while (reverseSongs.Count >= 0)
                {
                    Song song = reverseSongs.Pop();
                    Console.WriteLine($"Song : {song.Title} Duration : {song.Duration}");
                }
            }
        }

       
        static void Main(string[] args)
        {
            Playlist playlist1 = new Playlist();
            playlist1.AddSong(new Song("song1"));
            playlist1.AddSong(new Song("song2"));
            playlist1.AddSong(new Song("song3"));
            playlist1.AddSong(new Song("song4"));

            playlist1.PlayFromStart();
            playlist1.PlayFromLast();

        }
    }
}
