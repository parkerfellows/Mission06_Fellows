﻿using Microsoft.EntityFrameworkCore;

namespace Mission06_Fellows.Models
{
    public class MovieContext : DbContext 
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
    }
}
