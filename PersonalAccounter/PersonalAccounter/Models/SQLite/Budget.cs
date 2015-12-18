using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace PersonalAccounter.Models.SQLite
{
    public class Budget
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public double Overall { get; set; }

        public double HouseholdExpectancy { get; set; }

        public double LifestyleExpectancy { get; set; }

        public double UnexpectedExpectancy { get; set; }

        public double Saved { get; set; }

        [ForeignKey("")]
        public string UserId { get; set; }
    }
}
