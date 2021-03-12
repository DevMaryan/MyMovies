using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.Repositories.Interfaces;
using System.IO;
using System.Linq;
using MyMovies.Models;
using Newtonsoft.Json;

namespace MyMovies.Repositories
{
    public class MoviesFileRepository : IMoviesRepository
    {
        const string Path = "Movies.txt";

        public MoviesFileRepository()
        {
            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, "[]");
            }
            var result = File.ReadAllText(Path);
            var deserializedList = JsonConvert.DeserializeObject<List<Movie>>(result);
            Movies = deserializedList;
        }
        public List<Movie> Movies { get; set; }

        // Get all Movies from the list Movies
        public List<Movie> GetAllMovies()
        {
            return Movies;
        }


        // Find movie ID
        public Movie GetMovieById(int id)
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }

        // Create Movie
        public void CreateMovie(Movie movie)
        {
            movie.Id = GenerateId();
            Movies.Add(movie);
            SaveChanges();

        }


        // Save the changes to file
        private void SaveChanges()
        {
            var serialized = JsonConvert.SerializeObject(Movies);
            File.WriteAllText(Path, serialized);
        }


        // Generate ID for object.id
        private int GenerateId()
        {
            var maxId = 0;
            if (Movies.Any())
            {
                maxId = Movies.Max(x => x.Id);
            }
            return maxId + 1;
        }
    }

}
