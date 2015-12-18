using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;

namespace PersonalAccounter.Models.Parse
{
    [ParseClassName("Budget")]
    public class BudgetParse : ParseObject
    {
        [ParseFieldName("Overall")]
        public double Overall
        {
            get { return this.GetProperty<double>(); }
            set { this.SetProperty<double>(value);}
        }

        [ParseFieldName("HouseholdExpectancy")]
        public double HouseholdExpectancy
        {
            get { return this.GetProperty<double>(); }
            set { this.SetProperty<double>(value);}
        }

        [ParseFieldName("LifestyleExpectancy")]
        public double LifestyleExpectancy
        {
            get { return this.GetProperty<double>(); }
            set { this.SetProperty<double>(value); }
        }

        [ParseFieldName("UnexpectedExpectancy")]
        public double UnexpectedExpectancy
        {
            get { return this.GetProperty<double>(); }
            set { this.SetProperty<double>(value); }
        }

        [ParseFieldName("Saved")]
        public double Saved
        {
            get { return this.GetProperty<double>(); }
            set { this.SetProperty<double>(value); }
        }

        //[ParseFieldName("UserId")]
        //public ParseUser UserId
        //{
        //    get { return this.GetProperty<ParseUser>(); }
        //    set { this.SetProperty(value);}
        //}
    }
}
