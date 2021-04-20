using System;
using System.Collections.Generic;
using A7MovieLibrary.Data;
using A7MovieLibrary.Models;
using System.Linq;
using ConsoleTables;

namespace A7MovieLibrary.Menus
{
public class Menu : IMenu
    {
        public Menu(bool validMenu) 
        {
            this.ValidMenu = validMenu;
        }
        public bool ValidMenu { get; set; }
        private IContext _movieContext;
        public Menu(IContext context)
        {
            _movieContext = context;
        }
        private List<Movie> _movies;
        public void DisplayMenu()
        {
            int menuSelection;
            do{
                MediaType();
                menuSelection = Int32.Parse(Console.ReadLine());
                switch(menuSelection){
                    case 1:
                    do{
                        ActionMenu();
                        menuSelection = Int32.Parse(Console.ReadLine());
                        if(menuSelection.Equals(1)){
                            //Add movie
                            var movie = GetMovie();
                            _movieContext.AddMovie(movie);
                        } else if(menuSelection.Equals(2)){
                            //Display movies
                            ConsoleTable.From<Movie>(_movieContext.GetMovies()).Write();
                            // PrintList();
                        } else if (menuSelection.Equals(3)){
                            var movie = Search();
                            System.Console.WriteLine($"Movie: {movie.Title}");
                        }
                    }while(!menuSelection.Equals(3));
                    Console.WriteLine("Closing window....");
                    break;
                    case 2: 
                    System.Console.WriteLine("Implementation not required for this assignment");
                    break;
                    case 3: 
                    System.Console.WriteLine("Implementation not required for this assignment");
                    break;
                }
            }while(!menuSelection.Equals(4));
            Console.WriteLine("Closing window....");
        }

        public Movie GetMovie()
        {
            Console.WriteLine("Enter the movie title: ");
            string mTitle = Console.ReadLine();

            System.Console.WriteLine("Enter the movie genre: ");
            string mGenre = Console.ReadLine();

            return new Movie { Title = mTitle, Genres = mGenre };
        }

        public Movie Search(string mTitle)
        {
            System.Console.WriteLine("enter title: ");
            mTitle = Console.ReadLine();

            var foundMovies = _movies.FirstOrDefault(m => m.Title.Contains(mTitle));
            return foundMovies;
        }

        //Menu option
        public void MediaType(){
            Console.WriteLine("Select media type\n");
            Console.WriteLine("1. Movie");
            Console.WriteLine("2. Show -- not available");
            Console.WriteLine("3. Video -- not available");
            Console.WriteLine("4. Exit\n");
        }

        public void ActionMenu(){
            Console.WriteLine("Make a selection\n");
            Console.WriteLine("1. Add new content");
            Console.WriteLine("2. See content");
            Console.WriteLine("3. Search\n");
        }
    }
}