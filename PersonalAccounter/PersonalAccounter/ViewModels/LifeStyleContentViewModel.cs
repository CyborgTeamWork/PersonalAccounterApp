namespace PersonalAccounter.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Helpers;
    using PersonalAccounter.Extensions;

    public class LifeStyleContentViewModel : ViewModelBase, IContentViewModel
    {
        public ObservableCollection<LifeStyleViewModel> lifeExpenses;
        private ICommand saveCommand;
        private ICommand deleteCommand;

        public IEnumerable<LifeStyleViewModel> LifeExpenses
        {
            get
            {
                if (this.lifeExpenses == null)
                {
                    this.lifeExpenses = new ObservableCollection<LifeStyleViewModel>();
                }

                return this.lifeExpenses;
            }
            set
            {
                if (this.lifeExpenses == null)
                {
                    this.lifeExpenses = new ObservableCollection<LifeStyleViewModel>();
                }

                this.lifeExpenses.Clear();
                value.ForEach(this.lifeExpenses.Add);
            }
        }

        public ICommand Save
        {
            get
            {
                if (this.saveCommand == null)
                {
                    this.saveCommand = new DelegateCommand<LifeStyleViewModel>((newExpense) =>
                    {
                        this.lifeExpenses.Add(new LifeStyleViewModel(newExpense));
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
                    this.deleteCommand = new DelegateCommand<LifeStyleViewModel>((expense) =>
                    {
                        this.lifeExpenses.Remove(expense);
                    });
                }
                return this.deleteCommand;
            }
        }

    }
}
