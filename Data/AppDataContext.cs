﻿using Microsoft.EntityFrameworkCore;
using minimalAPI.Models;

namespace minimalAPI.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<Todo> todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db; Cache=Shared");
    }
}