using A7MovieLibrary.Models;
using System.Collections.Generic;

namespace A7MovieLibrary.Data
{
    public interface IRepository
    {
        void Add(Movie movie);
        List<Movie> GetAll();
        List<Movie> Search(string title);
    }
}