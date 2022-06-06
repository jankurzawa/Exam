using Exam.Controller.Factories;
using Exam.Controller.Handlers;
using Exam.Data.DAL;
using Exam.View.DisplayManager;
using Exam.View.InputManager;

namespace Exam
{
    public class Program
    {
        static void Main(string[] args)
        {
            SongView songView = new();
            MenuDisplay menuDisplay = new ();
            InputManager inputSystem = new();
            SongFactory songFactory = new(inputSystem);
            SongRepository songRepository = new();
            SongHandler songHandler = new(songRepository, songView, menuDisplay, inputSystem, songFactory);
            var App = new AppHandler(songHandler, songFactory, menuDisplay, songView, inputSystem);
            App.Run();
        }
    }
}