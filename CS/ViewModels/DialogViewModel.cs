using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using System.Threading.Tasks;

namespace dxDialog1.ViewModels {
    public class DialogViewModel : ViewModelBase, IDialogDocumentContent {

        public string Caption { get; set; } = "This dialog window cannot be canceled until you click Yes in the confirmation message box. ";
        public IDialogDocumentOwner Dialog { get; set; }
        public bool IsOpen { get; set; }

        protected IMessageBoxService MessageBoxService { get { return this.GetService<IMessageBoxService>(); } }

        public async Task OnCloseAsync(ClosingDialogEventArgs e) {
            if(this.MessageBoxService != null && (MessageResult)e.Id == MessageResult.Cancel)
            {
                var result = await this.MessageBoxService.ShowAsync("Do you really want to cancel this dialog?", "Confirmation", MessageButton.YesNo);
                if(result == MessageResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
