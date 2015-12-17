namespace PersonalAccounter.ViewModels
{
    using Extensions;
    using Helpers;
    using PersonalAccounter.ViewModels;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class LifestyleContentViewModel : ViewModelBase, IContentViewModel
    {
        public ObservableCollection<LifestyleViewModel> lifeStyleExpenses;
        private ICommand saveCommand;
        private ICommand deleteCommand;
        private ICommand editCommand;

        public IEnumerable<LifestyleViewModel> LifeStyleExpenses
        {
            get
            {
                if (this.lifeStyleExpenses == null)
                {
                    this.lifeStyleExpenses = new ObservableCollection<LifestyleViewModel>();
                }

                return this.lifeStyleExpenses;
            }
            set
            {
                if (this.lifeStyleExpenses == null)
                {
                    this.lifeStyleExpenses = new ObservableCollection<LifestyleViewModel>();
                }

                this.lifeStyleExpenses.Clear();
                value.ForEach(this.lifeStyleExpenses.Add);
            }
        }

        public ICommand Save
        {
            get
            {
                if (this.saveCommand == null)
                {
                    this.saveCommand = new DelegateCommand<LifestyleViewModel>((newExpense) =>
                    {
                        this.lifeStyleExpenses.Add(new LifestyleViewModel(newExpense));
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
                    this.deleteCommand = new DelegateCommand<LifestyleViewModel>((expense) =>
                    {
                        this.lifeStyleExpenses.Remove(expense);
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
                    this.editCommand = new DelegateCommand<LifestyleViewModel>((newExpense) =>
                    {
                        this.lifeStyleExpenses.Add(new LifestyleViewModel(newExpense));
                    });
                }
                return this.editCommand;
            }
        }
    }
}
