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

            movies.Add(movie);

            using (StreamWriter sw = new StreamWriter(_fileName))
            {
                string json = JsonConvert.SerializeObject(movies, Formatting.Indented);

                sw.Write(json);
            }
        }

        public List<Movie> GetAll()
        {
            string json;
            using (var sr = new StreamReader(_fileName))
            {
                json = sr.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<Movie>>(json);
            
        }

        public List<Movie> Search(string title)
        {
            var moviesSearch = GetAll();

            var movie = moviesSearch.Where(m => m.Title.Contains(title)).ToList();
            if(movie.Count() < 1)
            {
                System.Console.WriteLine("\nRecord not found");
            }
              return movie;  
        }
    }
}