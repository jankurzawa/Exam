using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        IInputSystem _inputSystem;

        public SongsHandler(IBaseRepository<Song> songRepository, IDisplay<Song> display, IInputSystem inputSystem)
        {
            _songRepository = songRepository;
            _display = display;
            _inputSystem = inputSystem;
        }

        public void AddSongToPlaylist()
        {
            var song = CreateNewSong();

        }
        
    }
}
