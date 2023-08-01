using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MovieTicketBooking.Data;
using MovieTicketBooking.Data.Models;

namespace MovieTicketBooking.Business.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class TheatreRepository : ITheatreRepository
    {
        private readonly IDatabaseSettings _settings;
        private readonly IConfiguration _configuration;
        private readonly IMongoCollection<Theatre> _theatre;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="configuration"></param>
        public TheatreRepository(IDatabaseSettings settings, IConfiguration configuration)
        {
            _settings = settings;
            _configuration = configuration;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _theatre = database.GetCollection<Theatre>("Theatre");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<Theatre>> GetTheatre()
        {
            var theatres = await _theatre.Find(t => true).ToListAsync();
            return theatres;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Theatre> GetTheatre(string id)
        {
            var theatre = await _theatre.Find(t => t.Id == id).FirstOrDefaultAsync();
            return theatre;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<PrepareResponse> AddTheatre(Theatre data)
        {
            var response = new PrepareResponse();
            try
            {
                await _theatre.InsertOneAsync(data);
                response.IsSuccess = true;
                response.Message = "Data inserted";
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PrepareResponse> DeleteTheatre(string id)
        {
            var response = new PrepareResponse();

            try
            {
                await _theatre.DeleteOneAsync(t => t.Id == id);
                response.IsSuccess = true;
                response.Message = "Data deleted";
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PrepareResponse> UpdateTheatre(Theatre data, string id)
        {
            var response = new PrepareResponse();
            try
            {
                await _theatre.ReplaceOneAsync(t => t.Id == id, data);
                response.IsSuccess = true;
                response.Message = "Data updated";
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
