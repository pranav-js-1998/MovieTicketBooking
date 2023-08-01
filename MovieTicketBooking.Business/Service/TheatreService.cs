using AutoMapper;
using MovieTicketBooking.Business.Repository;
using MovieTicketBooking.Data.Models;

namespace MovieTicketBooking.Business.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class TheatreService : ITheatreService
    {
        public readonly ITheatreRepository Repository;
        public readonly IMapper Mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public TheatreService(ITheatreRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<Theatre>> GetTheatre()
        {
            return Repository.GetTheatre();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Theatre> GetTheatre(string id)
        {
            return Repository.GetTheatre(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<PrepareResponse> AddTheatre(TheatreDto data)
        {
            var theatre = Mapper.Map<Theatre>(data);
            theatre.Created = DateTime.Now;
            theatre.Updated = DateTime.Now;

            return await Repository.AddTheatre(theatre);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<PrepareResponse> UpdateTheatre(TheatreDto data, string id)
        {
            var theatre = Mapper.Map<Theatre>(data);
            theatre.Updated = DateTime.Now;

            return await Repository.UpdateTheatre(theatre, id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PrepareResponse> DeleteTheatre(string id)
        {
            throw new NotImplementedException();
        }
    }
}
