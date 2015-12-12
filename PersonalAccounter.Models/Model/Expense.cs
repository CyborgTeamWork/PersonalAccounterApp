namespace PersonalAccounter.Model.Model
{
    using System;
    using System.ComponentModel;

    public class Expense : INotifyPropertyChanged
    {
        private string name;
        private ExpenseType expenseType;
        private int monthlyCost;
        private string description;
        private DateTime? startDate;
        private DateTime? endDate;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public ExpenseType Type
        {
            get
            {
                return this.expenseType;
            }
            set
            {
                this.expenseType = value;
                NotifyPropertyChanged("ExpenseType");
            }
        }

        public int MonthlyCost
        {
            get
            {
                return this.monthlyCost;
            }
            set
            {
                this.monthlyCost = value;
                NotifyPropertyChanged("MonthlyCost");
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
                NotifyPropertyChanged("Description");
            }
        }

        public DateTime? StartDate
        {
            get
            {
                return this.startDate;
            }
            set
            {
                this.startDate = value;
                NotifyPropertyChanged("StartDate");
            }
        }

        public DateTime? EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
                NotifyPropertyChanged("EndDate");
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                handler(this, args);
            }
        }
    }
}
