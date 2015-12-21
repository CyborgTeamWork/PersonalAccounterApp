using System;
using System.ComponentModel.DataAnnotations.Schema;
using SQLite.Net.Attributes;

namespace PersonalAccounter.Models
{
    public class Expense
    {

        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public double Coast { get; set; }

        public Category Category { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey("")]
        public int UserId { get; set; }
    }
}
