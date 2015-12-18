namespace PersonalAccounter.ViewModels
{
    using Extensions;
    using Helpers;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class BudjetContentViewModel : ViewModelBase, IContentViewModel
    {
        public ObservableCollection<BudjetViewModel> monthlyBudjets;
        private ICommand saveCommand;
        private ICommand deleteCommand;
        private ICommand editCommand;

        public IEnumerable<BudjetViewModel> MonthlyBudjets
        {
            get
            {
                if (this.monthlyBudjets == null)
                {
                    this.monthlyBudjets = new ObservableCollection<BudjetViewModel>();
                }

                return this.monthlyBudjets;
            }
            set
            {
                if (this.monthlyBudjets == null)
                {
                    this.monthlyBudjets = new ObservableCollection<BudjetViewModel>();
                }

                this.monthlyBudjets.Clear();
                value.ForEach(this.monthlyBudjets.Add);
            }
        }

        public ICommand Save
        {
            get
            {
                if (this.saveCommand == null)
                {
                    this.saveCommand = new DelegateCommand<BudjetViewModel>((newBudjet) =>
                    {
                        this.monthlyBudjets.Add(new BudjetViewModel(newBudjet));
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
                    this.deleteCommand = new DelegateCommand<BudjetViewModel>((budjet) =>
                    {
                        this.monthlyBudjets.Remove(budjet);
                    });
                }
                return this.deleteCommand;
            }
        }

    }
}
