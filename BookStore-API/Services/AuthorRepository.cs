using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore_API.Contracts;
using BookStore_API.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore_API.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreContext _db;

        public AuthorRepository(BookStoreContext db)
        {
            _db = db;
        }

        public async Task<IList<Author>> FindAll()
        {
            var authors = await _db.Authors.Include(x => x.Books).ToListAsync();
            return authors;
        }

        public async Task<Author> FindById(int id)
        {
            var author = await _db.Authors.Include(x => x.Books).FirstOrDefaultAsync(x => x.Id == id);
            return author;
        }

        public async Task<bool> Create(Author entity)
        {
            await _db.Authors.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Exists(int id)
        {
            return await _db.Authors.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> Update(Author entity)
        {
            _db.Authors.Update(entity);
            return await Save();
        }

        public async Task<bool> Delete(Author entity)
        {
            _db.Authors.Remove(entity);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }
    }
}
