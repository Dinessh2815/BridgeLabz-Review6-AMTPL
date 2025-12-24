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
                
                while (songs.Count > 0)
                {
                    reverseSongs.Push(songs.Dequeue());
                }

                while (reverseSongs.Count > 0)
                {
                    Song song = reverseSongs.Pop();
                    Console.WriteLine($"Song : {song.Title} Duration : {song.Duration}");
                }
            }
        }

        class Node
        {
            public Song song;
            public Node Next;
            public Node Prev;

            public Node(Song song1)
            {
                song = song1;
                Next = null;
                Prev = null;
            }
        }

        class DoublyLL
        {
            Node head;
            Node tail;

            public void AddAtLast(Node newNode)
            {
                if (head == null)
                {
                    head = newNode;
                    tail = newNode;
                    return;
                }   

                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }

            public void PlayFromFirstDD()
            {
                Console.WriteLine("\nPlaying from first (DoublyLL)\n");
                Node temp = head;
                while (temp != null)
                {
                    Console.WriteLine($"Song : {temp.song.Title} Duration : {temp.song.Duration}");
                    temp = temp.Next;
                }
            }

            public void PlayFromLastDD()
            {
                Console.WriteLine("\nPlayling from Last (DoublyLL)\n");
                Node temp = tail;
                while (temp != null)
                {
                    Console.WriteLine($"Song : {temp.song.Title} Duration : {temp.song.Duration}");
                    temp = temp.Prev;
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

            DoublyLL playlist2 = new DoublyLL();
            playlist2.AddAtLast(new Node(new Song("song1")));
            playlist2.AddAtLast(new Node(new Song("song2")));
            playlist2.AddAtLast(new Node(new Song("song3")));
            playlist2.AddAtLast(new Node(new Song("song4")));

            playlist2.PlayFromFirstDD();
            playlist2.PlayFromLastDD();

        }
    }
}
