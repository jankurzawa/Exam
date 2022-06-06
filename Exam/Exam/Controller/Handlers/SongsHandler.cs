using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Controller.Factories;
using Exam.Data.DAL;
using Exam.Data.Entities;
using Exam.View.DisplayManager;
using Exam.View.DisplayManager.Interfaces;
using Exam.View.InputManager.Interfaces;

namespace Exam.Controller.Handlers
{
    public class SongsHandler
    {
        IBaseRepository<Song> _songRepository;
        IDisplay<Song> _display;
        IMenuDisplay _menuDisplay;
        IInputSystem _inputSystem;
        IFactory<Song> _songFactory;

        public SongsHandler(IBaseRepository<Song> songRepository, IDisplay<Song> display,IMenuDisplay menuDisplay, 
            IInputSystem inputSystem, IFactory<Song> songFactory )
        {
            _songRepository = songRepository;
            _display = display;
            _menuDisplay = menuDisplay;
            _inputSystem = inputSystem;
            _songFactory = songFactory;
        }

        public void AddSongToPlaylist()
        {
            string userConfirming = "";
            Song song;
            do
            {
                song = _songFactory.Create();
                _display.DisplaySingle(song);
                userConfirming = _inputSystem.FetchStringValue("Confirm?\n([y] - yes, [n] - no)");

            } while (userConfirming != "y");
            _songRepository.Add(song);
            _songRepository.Save();
        }

        public void DeleteSong()
        {
            string titleOfDeletingSong = _inputSystem.FetchStringValue("Title of song");
            string authorOfDeletingSong = _inputSystem.FetchStringValue($"Author of {titleOfDeletingSong} Song");

            var song = FindSong(titleOfDeletingSong, authorOfDeletingSong);
            if (song == null)
            {
                _menuDisplay.DisplayMessage($"the song '{titleOfDeletingSong}' of the performance of '{titleOfDeletingSong}' " +
                    "is not found in your playlist.\nPress enter to continue.");
                return;
            }
            else
            {
                _songRepository.Delete(song);
                _songRepository.Save();
                _inputSystem.FetchStringValue($"the song '{titleOfDeletingSong}' of the performance of '{titleOfDeletingSong}' has been removed." + 
                    "\nPress enter to continue");
            }
                
        }
        public Song? FindSong(string title, string author)
        {
            var song = _songRepository.GetSingle(s => s.Title.Equals(title) && s.Author.Equals(author));
            if (song == null) return null;
            return song;
        }

        public void SortSongsInPlaylist()
        {
            _songRepository.SortByAuthor();
        }
    }
}
