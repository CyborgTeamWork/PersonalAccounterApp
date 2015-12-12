namespace PersonalAccounter.Model.Model
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;
    using Windows.Storage;

    public class ExpenseManager
    {
        private bool loaded;

        private ObservableCollection<Expense> expenses;

        public ExpenseManager()
        {
            this.loaded = false;
            this.Expenses = new ObservableCollection<Expense>();
        }

        public ObservableCollection<Expense> Expenses
        {
            get
            {
                return this.expenses;
            }
            private set
            {
                this.expenses = value;
            }
        }

        public async Task LoadExpenses()
        {
            // Ensure that we don't load expense data more than once.
            if (loaded)
            {
                return;
            }
            loaded = true;

            StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            this.expenses.Clear();

            var item = await folder.TryGetItemAsync("expenses.xml");
            if (item == null)
            {
                // Add some 'starter' expenses
                this.expenses.Add(
                    new Expense()
                    {
                        Name = "Electricity",
                        Type = ExpenseType.Home,
                        MonthlyCost = 100,
                        Description = "Monthly elecricity bill!",
                        StartDate = new DateTime(2016, 1, 5),
                        EndDate = new DateTime(2016, 2, 5)
                    });
                this.expenses.Add(
                    new Expense()
                    {
                        Name = "Internet",
                        Type = ExpenseType.Home,
                        MonthlyCost = 40,
                        Description = "Monthly NET bill!",
                        StartDate = new DateTime(2016, 1, 10),
                        EndDate = new DateTime(2016, 2, 10)
                    });
                this.expenses.Add(
                     new Expense()
                     {
                         Name = "Friday Night",
                         Type = ExpenseType.Lifestyle,
                         MonthlyCost = 400,
                         Description = "Time to Party!",
                     });
                await this.WriteExpenses();
                return;
            }

            // Load expenses out of a simple XML format. For the purposes of this example, we're treating
            // parse failures as "no expenses exist" which will result in the file being erased.
            if (item.IsOfType(StorageItemTypes.File))
            {
                StorageFile expensesFile = item as StorageFile;

                string tripXmlText = await FileIO.ReadTextAsync(expensesFile);

                try
                {
                    XElement xmldoc = XElement.Parse(tripXmlText);

                    var expenseElements = xmldoc.Descendants("Expense");
                    foreach (var expense in expenseElements)
                    {
                        Expense newExpense = new Expense();

                        var destElement = expense.Descendants("Name").FirstOrDefault();
                        if (destElement != null)
                        {
                            newExpense.Name = destElement.Value;
                        }

                        var descElement = expense.Descendants("Description").FirstOrDefault();
                        if (descElement != null)
                        {
                            newExpense.Description = descElement.Value;
                        }


                        var startElement = expense.Descendants("StartDate").FirstOrDefault();
                        if (startElement != null)
                        {
                            DateTime startDate;
                            if (DateTime.TryParse(startElement.Value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out startDate))
                            {
                                newExpense.StartDate = startDate;
                            }
                            else
                            {
                                newExpense.StartDate = null;
                            }
                        }

                        var endElement = expense.Descendants("EndDate").FirstOrDefault();
                        if (endElement != null)
                        {
                            DateTime endDate;
                            if (DateTime.TryParse(endElement.Value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out endDate))
                            {
                                newExpense.EndDate = endDate;
                            }
                            else
                            {
                                newExpense.EndDate = null;
                            }
                        }

                        var notesElement = expense.Descendants("MonthlyCost").FirstOrDefault();
                        if (notesElement != null)
                        {
                            newExpense.MonthlyCost = int.Parse(notesElement.Value);
                        }

                        this.Expenses.Add(newExpense);
                    }
                }
                catch (XmlException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    return;
                }

            }
        }

        public async Task DeleteExpense(Expense expense)
        {
            this.Expenses.Remove(expense);
            await WriteExpenses();
        }

        /// <summary>
        /// Add a expense to the persistent expense manager and saves the expenses to data file.
        /// </summary>
        /// <param name="expense">The expense to save or update in the data file.</param>
        public async Task SaveExpense(Expense expense)
        {
            if (!this.Expenses.Contains(expense))
            {
                this.Expenses.Add(expense);
            }

            await WriteExpenses();
        }

        /// <summary>
        /// Write out a new XML file, overwriting the existing one if it already exists
        /// with the currently persisted expenses. See class comment for basic format.
        /// </summary>
        private async Task WriteExpenses()
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;

            XElement xmldoc = new XElement("Root");

            StorageFile expensesFile;

            var item = await folder.TryGetItemAsync("expenses.xml");
            if (item == null)
            {
                expensesFile = await folder.CreateFileAsync("expenses.xml");
            }
            else
            {
                expensesFile = await folder.GetFileAsync("expenses.xml");
            }

            foreach (var expense in this.Expenses)
            {
                string startDateField = null;
                if (expense.StartDate.HasValue)
                {
                    startDateField = expense.StartDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                }

                string endDateField = null;
                if (expense.EndDate.HasValue)
                {
                    endDateField = expense.EndDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                }

                xmldoc.Add(
                    new XElement("Expense",
                    new XElement("Name", expense.Name),
                    new XElement("Type", expense.Type),
                    new XElement("Monthly Cost", expense.MonthlyCost),
                    new XElement("Description", expense.Description),
                    new XElement("StartDate", startDateField),
                    new XElement("EndDate", endDateField)));

            }

            await FileIO.WriteTextAsync(expensesFile, xmldoc.ToString());
        }
    }
}
