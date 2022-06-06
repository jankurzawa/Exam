using Exam.Data.Entities;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.View.DisplayManager.Interfaces;

namespace Exam.View.DisplayManager
{
    public class SongView : IDisplayManager<Song>
    {
        public void DisplayList(List<Song> entities) => entities.ForEach(e => DisplaySingle(e));

        public void DisplaySingle(Song entity) 
            => Write($"Author:\t{entity.Author}|Title:\t{entity.Title}|Album name:\t{entity.AlbumName}|Length:\t{entity.Length}\n");
    }
}
