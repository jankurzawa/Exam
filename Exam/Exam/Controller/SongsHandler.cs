using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Data.DAL;
using Exam.Data.Entities;
using Exam.View.DisplayManager;

namespace Exam.Controller
{
    public class SongsHandler
    {
        IBaseRepository<Song> _songRepository;
        IDisplay<Song> _display;

        public SongsHandler(IBaseRepository<Song> songRepository, IDisplay<Song> display)
        {
            _songRepository = songRepository;
            _display = display;
        }

        public void
    }
}
