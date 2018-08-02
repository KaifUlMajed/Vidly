using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Models.DTOs;
using AutoMapper;
using System.Data.Entity;

namespace Vidly.Controllers.api
{
    public class MoviesController : ApiController
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: /api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var movies = _context.Movies.Include(mov => mov.Genre).Where(mov => mov.NumberAvailable > 0);
            if (!String.IsNullOrWhiteSpace(query))
            {
                movies = movies.Where(m => m.Name.Contains(query));
            }
            
            var filteredMovies = movies.ToList().Select(Mapper.Map<Movie, MovieDTO>);
            return Ok(filteredMovies);

        }

        // GET: /api/movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var movieInDb = _context.Movies.Single(mov => mov.ID == id);
            if (movieInDb == null) return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movieInDb));
        }

        // POST: /api/movies/{Obj Data}
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            movie.DateAdded = DateTime.Now;
            movie.NumberAvailable = movie.NumberInStock;

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDTO.ID = movie.ID;
            return Created(new Uri(Request.RequestUri + "/" + movieDTO.ID), movieDTO);
        }

        // PUT: /api/movies/{id} and {obj data}
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var movieInDb = _context.Movies.Single(mov => mov.ID == id);
            if (movieInDb == null) return NotFound();

            Mapper.Map<MovieDTO, Movie>(movieDTO, movieInDb);
            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: /api/movies/{id}
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.Single(mov => mov.ID == id);
            if (movie == null) return NotFound();
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);

        }
    }
}
