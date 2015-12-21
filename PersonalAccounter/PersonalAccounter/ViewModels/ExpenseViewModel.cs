using System.Collections.ObjectModel;
using PersonalAccounter.Models;

namespace PersonalAccounter.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using PersonalAccounter.Helpers.ViewModelHelpers;
    using PersonalAccounter.Models;
    using WinRTXamlToolkit.Tools;
    using Extensions;

    public class ExpenseViewModel : ViewModelBase
    {
        private ExpenseViewModelHelper expensesHelper;
        private ObservableCollection<Expense> expenses;

        private List<Expense> testData = new List<Expense>
        {
            new Expense
            {
                Name = "Item1",
                Category = Category.Household,
                ImageUrl =
                    "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRfZe1i5YXwK4gRWPJgYFQ7hceve5qqJf5qOcvUAToRv30qdzEB",
                Coast = 2.56,
                Description = "Some description",
                CreatedOn = DateTime.Now
            },
            new Expense
            {
                Name = "Item2",
                Category = Category.Household,
                ImageUrl =
                    "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRfZe1i5YXwK4gRWPJgYFQ7hceve5qqJf5qOcvUAToRv30qdzEB",
                Coast = 10.56,
                Description = "Some description",
                CreatedOn = DateTime.Now
            },
            new Expense
            {
                Name = "Item3",
                Category = Category.Household,
                ImageUrl =
                    "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRfZe1i5YXwK4gRWPJgYFQ7hceve5qqJf5qOcvUAToRv30qdzEB",
                Coast = 12.56,
                Description = "Some description",
                CreatedOn = DateTime.Now
            },
            new Expense
            {
                Name = "Item4",
                Category = Category.Household,
                ImageUrl =
                    "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRfZe1i5YXwK4gRWPJgYFQ7hceve5qqJf5qOcvUAToRv30qdzEB",
                Coast = 20.56,
                Description = "Some description",
                CreatedOn = DateTime.Now
            },
            new Expense
            {
                Name = "Item5",
                Category = Category.Household,
                ImageUrl =
                    "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRfZe1i5YXwK4gRWPJgYFQ7hceve5qqJf5qOcvUAToRv30qdzEB",
                Coast = 234.56,
                Description = "Some description",
                CreatedOn = DateTime.Now
            },
            new Expense
            {
                Name = "Item6",
                Category = Category.Household,
                ImageUrl =
                    "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRfZe1i5YXwK4gRWPJgYFQ7hceve5qqJf5qOcvUAToRv30qdzEB",
                Coast = 1222.56,
                Description = "Some description",
                CreatedOn = DateTime.Now
            },
            new Expense
            {
                Name = "Item7",
                Category = Category.Household,
                ImageUrl =
                    "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRfZe1i5YXwK4gRWPJgYFQ7hceve5qqJf5qOcvUAToRv30qdzEB",
                Coast = 2.56,
                Description = "Some description",
                CreatedOn = DateTime.Now
            },
            new Expense
            {
                Name = "Item8",
                Category = Category.Household,
                ImageUrl =
                    "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRfZe1i5YXwK4gRWPJgYFQ7hceve5qqJf5qOcvUAToRv30qdzEB",
                Coast = 202.56,
                Description = "Some description",
                CreatedOn = DateTime.Now
            },
            new Expense
            {
                Name = "Item9",
                Category = Category.Household,
                ImageUrl =
                    "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRfZe1i5YXwK4gRWPJgYFQ7hceve5qqJf5qOcvUAToRv30qdzEB",
                Coast = 67.56,
                Description = "Some description",
                CreatedOn = DateTime.Now
            },
            new Expense
            {
                Name = "Item10",
                Category = Category.Household,
                ImageUrl =
                    "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRfZe1i5YXwK4gRWPJgYFQ7hceve5qqJf5qOcvUAToRv30qdzEB",
                Coast = 21.56,
                Description = "Some description",
                CreatedOn = DateTime.Now
            }
        };

    public ExpenseViewModel()
        {
            this.expensesHelper = new ExpenseViewModelHelper();
        if (this.expenses == null)
        {
                this.PopulateExpense();
            }
              
        }

        public void PopulateExpense()
        {
            this.expenses = new ObservableCollection<Expense>();
            foreach (var item in testData)
            {
                this.expenses.Add(item);
            }
        }
        public IEnumerable<Expense> Expenses
        {
            get
            {
                return this.expenses ?? (this.expenses = new ObservableCollection<Expense>());

            }
            set
            {
                if (this.expenses == null)
                {
                    this.expenses = new ObservableCollection<Expense>();
                }

                this.expenses.Clear();

                value.Foreach(e => this.expenses.Add(e));
            }
        }

        public void AddExpense(string name, string imageUrl, string description, double price, Category category)
        {
            this.expensesHelper.AddNewExpenseLocally(name, imageUrl, description, price, category);
            this.expensesHelper.AddExpenseParse(name, imageUrl, description, price, category);
            var newExpense = new Expense
            {
                Name = name,
                ImageUrl = imageUrl,
                Description = description,
                Coast = price,
                Category = category
            };
            this.expenses.Add(newExpense);
        }

        public async void Display()
        {
           await this.expensesHelper.Get();
        }

        public async Task<List<Tuple<string, double>>> EditChart()
        {
            return await this.expensesHelper.PopulatingChart();
        }
    }
}

