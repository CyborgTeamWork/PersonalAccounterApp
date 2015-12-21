using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using PersonalAccounter.Helpers.ViewModelHelpers;
using PersonalAccounter.Models;

namespace PersonalAccounter.ViewModels
{
    public class ExpenseViewModel : ViewModelBase
    {
        private ExpenseViewModelHelper expenses;

        public ExpenseViewModel()
        {
            this.expenses = new ExpenseViewModelHelper();

            this.Expenses = new ObservableCollection<Expense>();
            this.Expenses.Add(new Expense
            {
                Name = "item 1",
                ImageUrl = "https://i.ytimg.com/vi/4yikpWtIFU8/maxresdefault.jpg",
                Category = Category.Household,
                Coast = 2.56,
                Description = "Some description"
            });
            this.Expenses.Add(new Expense
            {
                Name = "item 2",
                ImageUrl = "https://i.ytimg.com/vi/4yikpWtIFU8/maxresdefault.jpg",
                Category = Category.Lifestyle,
                Coast = 2.56,
                Description = "Some description"
            });
            this.Expenses.Add(new Expense
            {
                Name = "item 3",
                ImageUrl = "https://i.ytimg.com/vi/4yikpWtIFU8/maxresdefault.jpg",
                Category = Category.Household,
                Coast = 2.56,
                Description = "Some description"
            });
            this.Expenses.Add(new Expense
            {
                Name = "item 4",
                ImageUrl = "https://i.ytimg.com/vi/4yikpWtIFU8/maxresdefault.jpg",
                Category = Category.Unexpected,
                Coast = 2.56,
                Description = "Some description"
            });
            this.Expenses.Add(new Expense
            {
                Name = "item 5",
                ImageUrl = "https://i.ytimg.com/vi/4yikpWtIFU8/maxresdefault.jpg",
                Category = Category.Lifestyle,
                Coast = 2.56,
                Description = "Some description"
            });
        }

        public ObservableCollection<Expense> Expenses { get; set; }

        public void AddExpense(string name, string imageUrl, string description, double price, Category category)
        {
            this.expenses.AddNewExpenseLocally(name, imageUrl,description,price,category);
            this.expenses.AddExpenseParse(name, imageUrl, description, price, category);
            this.Expenses.Add(new Expense
            {
                Name = name,
                ImageUrl = imageUrl,
                Description = description,
                Coast = price,
                Category = category
            });
        }

        public async void Display()
        {
           await this.expenses.Get();
        }

        public async Task<List<Tuple<string, double>>> EditChart()
        {
            return await this.expenses.PopulatingChart();
        }
    }
}
