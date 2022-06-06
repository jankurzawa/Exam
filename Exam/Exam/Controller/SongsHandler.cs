using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Data.DAL;
using Exam.Data.Entities;

namespace Exam.Controller
{
    public class SongsHandler
    {
        IBaseRepository<Song> _songRepository;

        public SongsHandler(IBaseRepository<Song> songRepository)
        {
            _songRepository = songRepository;
        }

        public void
    }
}
