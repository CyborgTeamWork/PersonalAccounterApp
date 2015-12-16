namespace PersonalAccounter.ViewModels
{
    public class MainPageViewModel : ViewModelBase, IPageViewModel
    {
        public MainPageViewModel(IContentViewModel contentViewModel)
        {
            this.ContentViewModel = contentViewModel;
        }

        public string Title
        {
            get
            {
                return "Expenses";
            }
        }

        public IContentViewModel ContentViewModel { get; set; }
    }
}
