namespace PersonalAccounter.ViewModels
{
    using Extensions;
    using Helpers;
    using PersonalAccounter.ViewModels;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class UnexpectedExpensesContentViewModel : ViewModelBase, IContentViewModel
    {
        public ObservableCollection<UnexpectedExpensesViewModel> unexpectedExpenses;
        private ICommand saveCommand;
        private ICommand deleteCommand;
        private ICommand editCommand;

        public IEnumerable<UnexpectedExpensesViewModel> UnexpectedExpenses
        {
            get
            {
                if (this.unexpectedExpenses == null)
                {
                    this.unexpectedExpenses = new ObservableCollection<UnexpectedExpensesViewModel>();
                }

                return this.unexpectedExpenses;
            }
            set
            {
                if (this.unexpectedExpenses == null)
                {
                    this.unexpectedExpenses = new ObservableCollection<UnexpectedExpensesViewModel>();
                }

                this.unexpectedExpenses.Clear();
                value.ForEach(this.unexpectedExpenses.Add);
            }
        }

        public ICommand Save
        {
            get
            {
                if (this.saveCommand == null)
                {
                    this.saveCommand = new DelegateCommand<UnexpectedExpensesViewModel>((newExpense) =>
                    {
                        this.unexpectedExpenses.Add(new UnexpectedExpensesViewModel(newExpense));
                    });
                }
                return this.saveCommand;
            }
        }

        public ICommand Delete
        {
            get
            {
                if (this.deleteCommand == null)
                {
                    this.deleteCommand = new DelegateCommand<UnexpectedExpensesViewModel>((expense) =>
                    {
                        this.unexpectedExpenses.Remove(expense);
                    });
                }
                return this.deleteCommand;
            }
        }

        public ICommand Edit
        {
            get
            {
                if (this.editCommand == null)
                {
                    this.editCommand = new DelegateCommand<UnexpectedExpensesViewModel>((newExpense) =>
                    {
                        this.unexpectedExpenses.Add(new UnexpectedExpensesViewModel(newExpense));
                    });
                }
                return this.editCommand;
            }
        }
    }
}
