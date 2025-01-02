using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Question2_MVC.Models
{
    public class MoviesContext:DbContext
    {
        public MoviesContext() : base("name=MovieConnection") { }
        public DbSet<Movie> Movies { get; set; }
    }
}