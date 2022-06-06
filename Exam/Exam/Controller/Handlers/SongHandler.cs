using Exam.Controller.Factories;
using Exam.Data.DAL;
using Exam.Data.Entities;
using Exam.View.DisplayManager.Interfaces;
using Exam.View.InputManager.Interfaces;

namespace Exam.Controller.Handlers
{
    public class SongHandler
    {
        IBaseRepository<Song> _songRepository;
        IMenuDisplay _menuDisplay;
        IInputSystem _inputSystem;

        public SongHandler(IBaseRepository<Song> songRepository,IMenuDisplay menuDisplay, 
            IInputSystem inputSystem)
        {
            _songRepository = songRepository;
            _menuDisplay = menuDisplay;
            _inputSystem = inputSystem;
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

        public void DeleteSong(Song? song)
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
