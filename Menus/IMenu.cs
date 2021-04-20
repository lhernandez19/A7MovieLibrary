using A7MovieLibrary.Data;
using A7MovieLibrary.Models;

namespace A7MovieLibrary.Menus
{
public interface IMenu
    {
        bool ValidMenu { get; set; }
        void DisplayMenu();
        Movie GetMovie();
        void MediaType();
        void ActionMenu();

    }
}