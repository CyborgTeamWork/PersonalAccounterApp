using PersonalAccounter.Extensions;
using PersonalAccounter.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PersonalAccounter.ViewModels
{
    public class HouseHoldContentViewModel : ViewModelBase, IContentViewModel
    {
        public ObservableCollection<HouseHoldViewModel> houseHoldExpenses;
        private ICommand saveCommand;
        private ICommand deleteCommand;
        private ICommand editCommand;

        public IEnumerable<HouseHoldViewModel> HouseHoldExpenses
        {
            get
            {
                if (this.houseHoldExpenses == null)
                {
                    this.houseHoldExpenses = new ObservableCollection<HouseHoldViewModel>();
                }

                return this.houseHoldExpenses;
            }
            set
            {
                if (this.houseHoldExpenses == null)
                {
                    this.houseHoldExpenses = new ObservableCollection<HouseHoldViewModel>();
                }

                this.houseHoldExpenses.Clear();
                value.ForEach(this.houseHoldExpenses.Add);
            }
        }

        public ICommand Save
        {
            get
            {
                if (this.saveCommand == null)
                {
                    this.saveCommand = new DelegateCommand<HouseHoldViewModel>((newExpense) =>
                    {
                        this.houseHoldExpenses.Add(new HouseHoldViewModel(newExpense));
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
                    this.deleteCommand = new DelegateCommand<HouseHoldViewModel>((expense) =>
                    {
                        this.houseHoldExpenses.Remove(expense);
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
                    this.editCommand = new DelegateCommand<HouseHoldViewModel>((newExpense) =>
                    {
                        this.houseHoldExpenses.Add(new HouseHoldViewModel(newExpense));
                    });
                }
                return this.editCommand;
            }
        }
    }
}
