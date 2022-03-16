using Microsoft.EntityFrameworkCore;
using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MovieActors>()
				.HasKey(x => new { x.ActorId, x.MovieId });

			modelBuilder.Entity<MovieGenres>()
				.HasKey(x => new { x.GenreId, x.MovieId });

			modelBuilder.Entity<MovieTheatersMovies>()
				.HasKey(x => new { x.MovieTheaterId, x.MovieId });

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Genre> Genres { get; set; }
		public DbSet<Actor> Actors { get; set; }

		public DbSet<MovieTheater> MovieTheaters { get; set; }

		public DbSet<Movie> Movies { get; set; }
		public DbSet<MovieActors> MovieActors { get; set; }
		public DbSet<MovieGenres> MovieGenres { get; set; }
		public DbSet<MovieTheatersMovies> MoviesTheatersMovies { get; set; }
	}
}