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
    public class SongHandler
    {
        IBaseRepository<Song> _songRepository;
        IDisplay<Song> _display;
        IMenuDisplay _menuDisplay;
        IInputSystem _inputSystem;
        IFactory<Song> _songFactory;

        public SongHandler(IBaseRepository<Song> songRepository, IDisplay<Song> display,IMenuDisplay menuDisplay, 
            IInputSystem inputSystem, IFactory<Song> songFactory )
        {
            _songRepository = songRepository;
            _display = display;
            _menuDisplay = menuDisplay;
            _inputSystem = inputSystem;
            _songFactory = songFactory;
        }

        public List<Song> GetAll()
        {
            return _songRepository.GetAll();
        }

        public void AddSongToPlaylist(Song song)
        {
            _songRepository.Add(song);
            _songRepository.Save();
        }

        public void DeleteSong(Song song)
        {
            if (song == null)
            {
                _menuDisplay.DisplayMessage($"The song is not found in your playlist.\nPress enter to continue.");
                return;
            }
            else
            {
                _songRepository.Delete(song);
                _songRepository.Save();
                _inputSystem.FetchStringValue($"The song '{song.Title}' of the performance of '{song.Author}' has been removed." + 
                    "\nPress enter to continue");
            }
                
        }
        public Song? FindSong(string title, string author)
        {
            if (title == null || title.Length < 1 || author == null || author.Length < 1) return null;
            var song = _songRepository.GetSingle(s => s.Title.Equals(title) && s.Author.Equals(author));
            if (song == null) return null;
            return song;
        }

        public void SortSongsInPlaylist()
        {
            _songRepository.Sort();
            _songRepository.Save();
        }
    }
}
