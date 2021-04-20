using System.Collections.Generic;
using A7MovieLibrary.Models;

namespace A7MovieLibrary.Data
{
    public interface IContext
    {
        void AddMovie(Movie movie);
        List<Movie> GetMovies();
        Movie SearchMovies(string title);
    }
}