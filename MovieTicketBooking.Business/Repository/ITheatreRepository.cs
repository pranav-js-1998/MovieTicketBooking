using MovieTicketBooking.Data.Models;

namespace MovieTicketBooking.Business.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITheatreRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<Theatre>> GetTheatre();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Theatre> GetTheatre(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<PrepareResponse> AddTheatre(Theatre data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<PrepareResponse> UpdateTheatre(Theatre data, string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PrepareResponse> DeleteTheatre(string id);
    }
}
