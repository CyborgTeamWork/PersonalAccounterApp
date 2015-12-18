using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounter.ViewModels
{
    public class BudjetViewModel : ViewModelBase
    {
        public BudjetViewModel()
                : this(0, 0, 0, 0)
            {
        }

        public BudjetViewModel(BudjetViewModel newBudjet)
                : this(newBudjet.TotalBudjet, newBudjet.HomeExpecations, newBudjet.LifeExpecations, newBudjet.UnexpectedExpecations)
            {

        }

        public BudjetViewModel(int total, int home, int life, int unexpected)
        {
            this.TotalBudjet = total;
            this.HomeExpecations = home;
            this.LifeExpecations = life;
            this.UnexpectedExpecations = unexpected;
        }


        public int TotalBudjet { get; set; }

        public int HomeExpecations { get; set; }

        public int LifeExpecations { get; set; }

        public int UnexpectedExpecations { get; set; }

        public bool Equals(BudjetViewModel obj)
        {
            return this.TotalBudjet == obj.TotalBudjet &&
              this.HomeExpecations == obj.HomeExpecations &&
              this.LifeExpecations == obj.LifeExpecations &&
              this.UnexpectedExpecations == obj.UnexpectedExpecations;
        }

        public override bool Equals(object obj)
        {
            var other = obj as BudjetViewModel;

            if (other == null)
            {
                return false;
            }
            return this.Equals(other);
        }
    }
}
