using Exam.Data.Entities;
using Exam.View.DisplayManager.Interfaces;
using static System.Console;
using System.Linq;

namespace Exam.View.DisplayManager
{
    public class SongView : IDisplay<Song>
    {
        public void DisplayList(List<Song> entities) => entities.ForEach(e => DisplaySingle(e));

        public void DisplaySingle(Song entity) 
            => Write($"Author:\t{entity.Author}|Title:\t{entity.Title}|Album name:\t{entity.AlbumName}|Length:\t{entity.Length}\n");
    }
}
