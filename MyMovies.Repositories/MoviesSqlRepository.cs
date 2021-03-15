﻿using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyMovies.Repositories
{
    public class MoviesSqlRepository : IMoviesRepository
    {
        public void CreateMovie(Movie movie)
        {
     
            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyMovieSql;Trusted_Connection=True"))
            {
                cnn.Open();
                var query = @"INSERT INTO Movies(Title, ImageUrl, Description, Genre, Date) VALUES (@Title,@ImageUrl,@Description,@Genre,@Date)";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@ImageUrl", movie.ImageUrl);
                cmd.Parameters.AddWithValue("@Description", movie.Description);
                cmd.Parameters.AddWithValue("@Genre", movie.Genre);
                cmd.Parameters.AddWithValue("@Date", movie.Date);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Movie> GetAllMovies()
        {
            var result = new List<Movie>();

            // Automatically will remove it from memory in case we have many connections
            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyMovieSql;Trusted_Connection=True"))
            {
                cnn.Open();
                var query = "SELECT * FROM Movies";
                var cmd = new SqlCommand(query, cnn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var movie = new Movie();
                    movie.Id = reader.GetInt32(0);
                    movie.Title = reader.GetString(1);
                    movie.ImageUrl = reader.GetString(2);
                    movie.Description = reader.GetString(3);
                    movie.Genre = reader.GetString(4);
                    movie.Date = reader.GetDateTime(5);

                    result.Add(movie);
                }
            }

            return result;
        }

        public Movie GetMovieById(int id)
        {
            Movie result = null;

            // Automatically will remove it from memory in case we have many connections
            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyMovieSql;Trusted_Connection=True"))
            {
                cnn.Open();
                var query = "SELECT * FROM Movies WHERE Id = @Id";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Id", id); // To avoid SQL Injection
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = new Movie();
                    result.Id = reader.GetInt32(0);
                    result.Title = reader.GetString(1);
                    result.ImageUrl = reader.GetString(2);
                    result.Description = reader.GetString(3);
                    result.Genre = reader.GetString(4);
                    result.Date = reader.GetDateTime(5);               
                }
            }
            return result;
        }
    }
}
