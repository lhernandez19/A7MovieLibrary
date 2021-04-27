using System;
using System.Collections.Generic;
using A7MovieLibrary.Data;
using A7MovieLibrary.Models;
using System.Linq;
using ConsoleTables;
using System.Globalization;

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
        public Menu(){}
        public Menu(IContext context)
        {
            _movieContext = context;
            DisplayMenu();
        }
        public void DisplayMenu()
        {
            string menuSelection;
            do{
                MediaType();
                menuSelection = Console.ReadLine();
                switch(menuSelection){
                    case "1":
                    do{
                        ActionMenu();
                        menuSelection = Console.ReadLine();
                        if(menuSelection == "1"){
                            //Add movie
                            var movie = GetMovie();
                            _movieContext.AddMovie(movie);
                        } else if(menuSelection == "2"){
                            //Display movies
                            ConsoleTable.From<Movie>(_movieContext.GetMovies()).Write();
                        } else if (menuSelection == "3"){
                            //Search movies
                            var movie = Search();
                            System.Console.WriteLine();
                            movie.ForEach(x=> System.Console.WriteLine($"Movie: {x.Title}"));
                        } else{
                            System.Console.WriteLine("Invalid selection.");
                        }
                    }while(menuSelection != "4");
                    Console.WriteLine("\nClosing window....\n");
                    break;
                    case "2": 
                    System.Console.WriteLine("Implementation not required for this assignment");
                    break;
                    case "3": 
                    System.Console.WriteLine("Implementation not required for this assignment");
                    break;
                }
            }while(menuSelection != "4");
            Console.WriteLine("\nClosing window....\n");
        }

        public Movie GetMovie()
        {
            Console.Write("\nEnter the movie title: ");
            string mTitle = Console.ReadLine().ToLower();

            System.Console.Write("\nEnter the movie genre: ");
            string mGenre = Console.ReadLine().ToLower();

            return new Movie { Title = mTitle, Genres = mGenre };
        }

        public List<Movie> Search()
        {
            System.Console.Write("\nEnter title: ");
            var mTitle = Console.ReadLine().ToLower();

            var foundMovies = _movieContext.SearchMovies(mTitle);
            return foundMovies;
        }

        //Menu option
        public void MediaType(){
            Console.WriteLine("\nSelect media type\n");
            Console.WriteLine("1. Movie");
            Console.WriteLine("2. Show -- not available");
            Console.WriteLine("3. Video -- not available");
            Console.WriteLine("4. Exit\n");
        }

        public void ActionMenu(){
            Console.WriteLine("\nMake a selection\n");
            Console.WriteLine("1. Add new content");
            Console.WriteLine("2. See content");
            Console.WriteLine("3. Search");
            Console.WriteLine("4. Exit\n");
        }
    }
}