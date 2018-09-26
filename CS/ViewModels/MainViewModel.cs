using DevExpress.Mvvm;

namespace dxDialog1.ViewModels {
    public class MainViewModel : ViewModelBase {
        protected IDialogService DialogService { get { return this.GetService<IDialogService>(); } }

        public MainViewModel() {
            ShowDialogCommand = new DelegateCommand(ShowDialog);
        }

        public DelegateCommand ShowDialogCommand { get; private set; } 

        public async void ShowDialog() {

            var result = await DialogService.ShowDialogAsync(
                MessageButton.OKCancel,
                "My Dialog Window",
                "DialogView",
                null,
                this);

        }
        
    }
}
