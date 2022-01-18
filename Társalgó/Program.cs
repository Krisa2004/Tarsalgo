using System;
using System.Collections.Generic;
using System.IO;

namespace Társalgó
{
    class Program
    {
        private static List<Log> logs = new List<Log>();
        private static List<Artist> artists;
        private static int ID;

        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
            Task7();
            Task8();
        }

        private static void Task8()
        {
            Console.WriteLine("8. feladat");
            TimeSpan startTime = new TimeSpan();
            TimeSpan endTime = new TimeSpan();
            int minutes = 0;
            bool stayedInside = false;

            foreach (var log in logs)
            {
                if (log.ID == ID)
                {
                    if (log.DirectionIsInside)
                    {
                        startTime = new TimeSpan(log.Óra, log.Perc, 0);
                        stayedInside = true;
                    }
                    else
                    {
                        endTime = new TimeSpan(log.Óra, log.Perc, 0);
                        minutes += (endTime - startTime).Minutes;
                        stayedInside = false;

                    }
                }

            }

            if (stayedInside)
            {
                endTime = new TimeSpan(15, 0, 0);
                minutes += (endTime - startTime).Minutes;
            }

            Console.WriteLine("A(z) {0}. személy összesen {1} percet volt bent, a megfigyelés végén a társalgóban volt.", ID, minutes);
        }

        private static void Task7()
        {
            Console.WriteLine("7. feladat");
            foreach (var log  in logs)
            {
                if (log.ID == ID)
                {
                    if (log.DirectionIsInside)
                    {
                        Console.Write("{0}:{1}-", log.Óra, log.Perc);
                    }
                    else
                    {
                        Console.WriteLine("{0}:{1}", log.Óra, log.Perc);
                    }
                }

            }
            Console.WriteLine();
            Console.WriteLine();
            
        }

        private static void Task6()
        {
            Console.WriteLine("6. feladat");
            Console.Write("Adja meg a személy azonosítóját! ");
            ID = int.Parse(Console.ReadLine());

            Console.WriteLine();
        }
       

        private static void Task5()
        {
            Console.WriteLine("5. feladat");

            int count = 0;
            int max = 1;
            int maxIndex = 0;

            for (int i = 0; i < logs.Count; i++)
            {
                Log log = logs[i];
                if (log.DirectionIsInside)
                {
                    count++;
                }
                else
                {
                    count--;
                }

                if (count > max)
                {
                    max = count;
                    maxIndex = i;
                }
            }
            Console.WriteLine("{0}:{1} -kor voltak a legtöbben a társalgóban.", logs[maxIndex].Óra, logs[maxIndex].Perc);
            Console.WriteLine();
        }

        private static void Task4()
        {
            Console.WriteLine("4. feladat");
            Console.Write("A végén a társalgóban voltak: ");
            foreach (var artist in artists)
            {
                if (artist.Count % 2 == 1)
                {
                    Console.Write(artist.ID.ToString() + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void Task3()
        {
             artists = new List<Artist>();
            foreach (var log in logs)   
            {
                Artist artist = SearchArtistByLog(artists, log);
                if (artist == null)
                {
                    artists.Add(new Artist(log.ID));
                }
                else
                {
                    artist.Count = artist.Count + 1;
                }
            }
            artists = SortArtistsByID(artists);
            string[] content = new string[artists.Capacity];
            for (int i = 0; i < artists.Count; i++)
            {
                content[i] = artists[i].ID + " " + artists[i].Count;
            }
            File.WriteAllLines("athaladas.txt", content);
        }

        private static List<Artist> SortArtistsByID(List<Artist> artists)
        {
            List<Artist> result = new List<Artist>(artists);
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j < result.Count; j++)
                {
                    if (result[i].ID > result[j].ID)
                    {
                        Artist temp = result[i];
                        result[i] = result[j];
                        result[j] = temp;
                    }
                }
            }
            return result;
        }

        private static Artist SearchArtistByLog(List<Artist> artists, Log log)
        {
            foreach (var artist in artists)
            {
                if (log.ID == artist.ID)
                {
                    return artist;
                }
            }
            return null;
        }

        private static void Task2()
        {
            Console.WriteLine("2. feladat");
            int idFirst = SearchFirstVisitor();
            Console.WriteLine("Az első belépő: {0}", idFirst);

            int idLast = SearchLastLeaver();
            Console.WriteLine("Az utolsó kilépő: {0}", idLast);

            Console.WriteLine();
        }

        private static int SearchLastLeaver()
        {
            for (int i = logs.Count - 1; i >= 0; i--)
            {
                if (logs[i].DirectionIsInside) return logs[i].ID;
            }
            return -1;
        }

        private static int SearchFirstVisitor()
        {
            foreach (var log in logs)
            {
                if (log.DirectionIsInside)
                {
                    return log.ID;
                }
            }
            return -1;
        }

        private static void Task1()
        {
            string [] content = File.ReadAllLines("ajto.txt");
            foreach (var line in content)
            {
                string[] values = line.Split(' ');
                logs.Add(new Log(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), values[3] == "be"));
            }
        }

    }
}