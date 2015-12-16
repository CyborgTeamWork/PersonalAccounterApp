using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounter.ViewModels
{
    public class LifeStyleViewModel : ViewModelBase
    {
        public LifeStyleViewModel()
            :this (string.Empty, string.Empty, 0, string.Empty)
        {
        }


        public LifeStyleViewModel(LifeStyleViewModel newExpense)
            :this (newExpense.Name, newExpense.ImageUrl, newExpense.Cost, newExpense.Description)
        {

        }

        public LifeStyleViewModel(string name, string imageurl, int cost, string description)
        {
            this.Name = name;
            this.ImageUrl = imageurl;
            this.Cost = cost;
            this.Description = description;
        }


        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int Cost { get; set; }

        public string Description { get; set; }

        public bool Equals(LifeStyleViewModel obj)
        {
            return this.Name == obj.Name &&
              this.ImageUrl == obj.ImageUrl &&
              this.Cost == obj.Cost && 
              this.Description == obj.Description;
        }

        public override bool Equals(object obj)
        {
            var other = obj as LifeStyleViewModel;

            if (other == null)
            {
                return false;
            }
            return this.Equals(other);
        }
    }
}
