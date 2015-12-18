using Parse;

namespace PersonalAccounter.Models.Parse
{
    [ParseClassName("Expense")]
    public class ExpenseParse : ParseObject
    {
        [ParseFieldName("Name")]
        public string Name
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }

        [ParseFieldName("ImageUrl")]
        public string ImageUrl
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }

        [ParseFieldName("Description")]
        public string Description
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }

        [ParseFieldName("Price")]
        public double Price
        {
            get { return this.GetProperty<double>(); }
            set { this.SetProperty<double>(value); }
        }
    }
}
