using Microsoft.EntityFrameworkCore;
using SpbLeague.Data.Interfaces;
using SpbLeague.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpbLeague.Data.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.Email == email);
            return user;
        }

        public async Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
