using System.Collections.Generic;

namespace MilesBoxApi.Models
{

    public class Box
    {
        public int BoxId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Description { get; set; }
        public List<Measurement> Measurements { get; set; }
    }

    public class BoxDto
    {
        public int id { get; set; }
        public string user { get; set; }
        public string description { get; set; }
    }
}
