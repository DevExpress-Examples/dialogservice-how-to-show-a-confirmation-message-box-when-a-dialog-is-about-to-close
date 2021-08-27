<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/150450149/19.1.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T829072)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# DialogService - How to show a confirmation message box when a dialog is about to close

In this example, you can see how to handle the moment when a dialog shown with the help of DialogService is closed and confirm closing by showing a separate MessageBox. 

To do this, you need to implement the **IDialogDocumentContent** interface in the dialog's ViewModel and implement this interface's **OnCloseAsync** method. DialogService calls this method when an end-user's action leads to closing your dialog. 

In the current implementation, when an end-user clicks the Cancel button in the dialog window, a confirmation MessageBox is shown. If an end-user clicks No, the dialog window will remain visible: 

* **C#:**
```cs
    public async Task OnCloseAsync(ClosingDialogEventArgs e) {
        if(this.MessageBoxService != null && (MessageResult)e.Id == MessageResult.Cancel)
        {
            var result = await this.MessageBoxService.ShowAsync("Do you really want to cancel this dialog?",
                "Confirmation", MessageButton.YesNo);
            if(result == MessageResult.No)
            {
                e.Cancel = true;
            }
        }
    }
```

* **Visual Basic:**

```vb
    Public Async Function OnCloseAsync(ByVal e As ClosingDialogEventArgs) As Task
        If Me.MessageBoxService IsNot Nothing AndAlso CType(e.Id, MessageResult) = MessageResult.Cancel Then
            Dim result = Await Me.MessageBoxService.ShowAsync("Do you really want to cancel this dialog?", "Confirmation", MessageButton.YesNo)

            If result = MessageResult.No Then
                e.Cancel = True
            End If
        End If
    End Function
```
