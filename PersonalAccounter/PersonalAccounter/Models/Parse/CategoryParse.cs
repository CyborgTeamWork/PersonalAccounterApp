using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;

namespace PersonalAccounter.Models.Parse
{
    [ParseClassName("Category")]
     public class CategoryParse : ParseObject
    {
        [ParseFieldName("Name")]
        public string Name
        {
            get { return this.GetProperty<string>(); }
            set { this.SetProperty<string>(value); }
        }
    }
}
