using MovieTicketBooking.Data.Models.Dto;
using MovieTicketBooking.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketBooking.Business.Repository
{
    public interface IMovieRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        Task<PrepareResponse> Create(Movie movie);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<Movie>> GetMovie();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        Task<Movie> GetMovie(string movieId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        Task<PrepareResponse> DeleteMovie(string movieId);
    }
}
