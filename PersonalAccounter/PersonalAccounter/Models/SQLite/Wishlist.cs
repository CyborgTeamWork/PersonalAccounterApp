using System.ComponentModel.DataAnnotations.Schema;
using SQLite.Net.Attributes;

namespace PersonalAccounter.Models
{
    public class Wishlist
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Resource { get; set; }

        public string Description { get; set; }

        public float Coast { get; set; }

        public bool isBought { get; set; }

        [ForeignKey("")]
        public int UserId { get; set; }
    }
}
