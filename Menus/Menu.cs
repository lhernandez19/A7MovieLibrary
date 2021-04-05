using System;
using System.Collections.Generic;
using A7MovieLibrary.Data;
using A7MovieLibrary.Models;

namespace A7MovieLibrary.Menus
{
public class Menu : IMenu

    {
        public bool ValidMenu { get; set; }
        private IRepository _movieWriter;

        public Menu(IRepository writer)
        {
            ValidMenu = true;
            _movieWriter = writer;
        }

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
            Console.WriteLine("3. Exit\n");
        }
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
                            Add();
                        } else if(menuSelection.Equals(2)){
                            PrintList();
                        } else{System.Console.WriteLine("Invalid option!");}
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

        public void Add()
        {
            _movieWriter.WriteToFile(GetMovie());
            Console.WriteLine("The movie has been added");
        }

        public Movie GetMovie()
        {
            string title;
            string genre;
            string option;
            List<string> genres = new List<string>();

            Console.WriteLine("Enter the movie title? ");
            title = Console.ReadLine();

            do
            {
                Console.WriteLine("Add genres: ");
                genre = Console.ReadLine();
                genres.Add(genre);
                Console.WriteLine("Do you want to add a genre: (Y/N)");
                option = Console.ReadLine().ToUpper();
            } while (option == "Y");

            return new Movie(_movieWriter.GetNextId(), title, genres);
            
        }
        public void PrintList()
        {
            List<Movie> movies = _movieWriter.ReadFromFile();
            Console.WriteLine($"{"ID", -5} {"Title", -15} {"Genres", -30}");
            foreach (var m in movies)
            {
                Console.WriteLine(m.ToString());
            }
        }
    }
}