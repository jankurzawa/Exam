using Exam.Data.Context;
using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Data.DAL
{
    public class SongRepository : IBaseRepository<Song>
    {
        private ExamContext _context;

        public SongRepository () => _context = new();
        public void Add(Song entity) => _context.Songs.Add(entity);
        public void Delete(Song entity) => _context.Songs.Remove(entity);
        public void Edit(Song entity) => _context.Songs.Update(entity);
        public List<Song> GetAll() => _context.Songs.ToList();
        public Song GetSingle(Func<Song, bool> condition) => _context.Songs.Where(condition).FirstOrDefault();

        public void Sort()
        {
            _context.Songs.OrderByDescending(s => s.Title);
            Save();
        } 
        public void Save() => _context.SaveChanges();

    }
}
