﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MVCStartApp.Models.DB.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _context;
        
        public BlogRepository(BlogContext context) =>
            _context = context;

        public async Task AddUser(User user)
        {
            user.JoinDate = DateTime.Now;
            user.Id = Guid.NewGuid();
            
            EntityEntry<User> entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);
            
            await _context.SaveChangesAsync();
        }

        public async Task<User[]> GetUsers() => 
            await _context.Users.ToArrayAsync();
    }
}