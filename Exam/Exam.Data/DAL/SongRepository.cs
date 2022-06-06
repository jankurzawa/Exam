using Exam.Data.Context;
using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.DAL
{
    public class SongRepository : IBaseRepository<Song>
    {
        private ExamContext _context;

        public SongRepository () => _context = new();
        public void Add(Song entity) => _context.Songs.Add(entity);
        public void Delete(Song entity) => _context.Songs.Remove(entity);
        public void Edit(Song entity) => _context.Songs.Update(entity);
        public List<Song> GetAll() => _context.Songs.AsNoTracking().ToList();
        public Song GetSingle(Func<Song, bool> condition) => _context.Songs.Where(condition).FirstOrDefault();
        public void Save() => _context.SaveChanges();
    }
}
