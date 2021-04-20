using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using A7MovieLibrary.Models;
using Newtonsoft.Json;

namespace A7MovieLibrary.Data
{
public class MovieRepository : IRepository
    {
        private readonly string _fileName = Path.Combine(Environment.CurrentDirectory, "Files", "movies.json");        
        public void Add(Movie movie)
        {
            var movies = GetAll();

            var lastMovie = movies.OrderBy(o => o.MovieId).Last();
            movie.MovieId = lastMovie.MovieId + 1;

            using (StreamWriter sw = new StreamWriter(_fileName))
            {
                string json = JsonConvert.SerializeObject(sw, Formatting.Indented);

                sw.Write(json);
            }
        }

        public List<Movie> GetAll()
        {
            IEnumerable<Movie> records;
            using (var sr = new StreamReader(_fileName))
            {
                string json = sr.ReadToEnd();
            }
            return records = JsonConverter.DeserializeObject<Movie>(json);
        }

        public Movie Search(string title)
        {
            System.Console.WriteLine("enter title: ");
            title = Console.ReadLine();

            var movie = title.FirstOrDefault(m => m.Title.Contains(title));
            return movie;
        }
    }
}