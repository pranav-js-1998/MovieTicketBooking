using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketBooking.Data.Models
{
    public class Tickets
    {
        /// <summary>
        /// 
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TicketId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TicketsCount { get; set; }


        // <summary>
        /// 
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string MovieId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [BsonIgnore]
        public Movie Movie { get; set; }

        // <summary>
        /// 
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [BsonIgnore]
        public User User { get; set; }
    }
}
