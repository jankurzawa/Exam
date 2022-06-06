using Exam.Controller.Factories;
using Exam.Data.Entities;
using Exam.View.DisplayManager.Interfaces;
using Exam.View.InputManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Controller.Handlers
{
    public class AppHandler : BaseHandler<Song>
    {
        SongHandler _songHandler;
        IFactory<Song> _songFactory; 
        public AppHandler(SongHandler songHandler, IFactory<Song> songFactory, IMenuDisplay menuDisplay, IDisplay<Song> display, IInputSystem inputSystem) : base(menuDisplay, display, inputSystem)
        {
            _songHandler = songHandler;
            _songFactory = songFactory;
        }

        protected override string[] GetAvailableCommands()
             => new string[] {"[1] - Display all songs in playlist.", "[2] - Add song to playlist.", "[3] - Display sorted playlist by title",
             "[4] - Remove song", "[quit] - to quit "};

        protected override void RunFeatureBasedOn(string option)
        {
            switch (option)
            {
                case "1":
                    _display.DisplayList(_songHandler.GetAll());
                    break;
                case "2":
                    var song = _songFactory.Create();
                    _songHandler.AddSongToPlaylist(song);
                    break;
                case "3":
                    _songHandler.SortSongsInPlaylist();
                    break;
                case "4":
                    _songHandler.DeleteSong(_songHandler.FindSong(_inputSystem.FetchStringValue("Title:"), _inputSystem.FetchStringValue("Author:")));
                    break;
                case "quit":
                    break;
                default:
                    _inputSystem.FetchStringValue("Wrong option. Press enter to continue.");
                    break;
            }
        }
    }
}
