using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Entities
{
    public class Song
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string AlbumName { get; set; }
        public double Length { get; set; }

        public Song()
        {
        }
        public Song(string title, string author, string albumName, double length)
        {
            Title = title;
            Author = author;
            AlbumName = albumName;
            Length = length;
        }   
    }
}
