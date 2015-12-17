namespace PersonalAccounter.ViewModels
{
    namespace PersonalAccounter.ViewModels
    {
        public class UnexpectedExpensesViewModel : ViewModelBase
        {
            public UnexpectedExpensesViewModel()
                : this(string.Empty, string.Empty, 0, string.Empty, ExpenseType.HouseHold)
            {
            }

            public UnexpectedExpensesViewModel(UnexpectedExpensesViewModel newExpense)
                : this(newExpense.Name, newExpense.ImageUrl, newExpense.Cost, newExpense.Description, newExpense.Type = ExpenseType.HouseHold)
            {
            }

            public UnexpectedExpensesViewModel(string name, string imageurl, int cost, string description, ExpenseType type = ExpenseType.HouseHold)
            {
                this.Name = name;
                this.ImageUrl = imageurl;
                this.Cost = cost;
                this.Description = description;
            }


            public ExpenseType Type { get; private set; }

            public string Name { get; set; }

            public string ImageUrl { get; set; }

            public int Cost { get; set; }

            public string Description { get; set; }

            public bool Equals(UnexpectedExpensesViewModel obj)
            {
                return this.Name == obj.Name &&
                  this.ImageUrl == obj.ImageUrl &&
                  this.Cost == obj.Cost &&
                  this.Description == obj.Description;
            }

            public override bool Equals(object obj)
            {
                var other = obj as UnexpectedExpensesViewModel;

                if (other == null)
                {
                    return false;
                }
                return this.Equals(other);
            }
        }
    }
}
