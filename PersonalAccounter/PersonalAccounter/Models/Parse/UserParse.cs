using System.Collections;
using System.Collections.Generic;
using Parse;

namespace PersonalAccounter.Models.Parse
{
    public class UserParse : ParseUser
    {
        //[ParseFieldName("Username")]
        //public string Username
        //{
        //    get { return this.GetProperty<string>(); }
        //    set { this.SetProperty(value);}
        //}

        //[ParseFieldName("Password")]
        //public string Password
        //{
        //    get { return this.GetProperty<string>(); }
        //    set { this.SetProperty(value); }
        //}

        [ParseFieldName("Budget")]
        public BudgetParse Budget
        {
            get { return this.GetProperty<BudgetParse>(); }
            set { this.SetProperty(value); }
        }

        [ParseFieldName("Expense")]
        public IList<ExpenseParse> Expenses
        {
            get { return this.GetProperty<IList<ExpenseParse>>(); }
            set { this.SetProperty(value);}
        }
    }
}
