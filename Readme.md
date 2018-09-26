
# DialogService - How to prevent a dialog from being closed

In this example, you can see how to handle the moment when a dialog shown with the help of DialogService is closed. You can use this approach, for example, to perform custom logic or confirm closing. 

To do this, you need to implement the **IDialogDocumentContent** interface in the dialog's ViewModel and implement this interface's **OnCloseAsync** method. DialogService calls this method when an end-user's action leads to closing your dialog. 

In the current implementation, when an end-user clicks the Cancel button in the dialog window, a confirmation MessageBox is shown. If an end-user clicks No, the dialog window will remain visible: 

* **C#:**
```
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

```
    Public Async Function OnCloseAsync(ByVal e As ClosingDialogEventArgs) As Task
        If Me.MessageBoxService IsNot Nothing AndAlso CType(e.Id, MessageResult) = MessageResult.Cancel Then
            Dim result = Await Me.MessageBoxService.ShowAsync("Do you really want to cancel this dialog?", "Confirmation", MessageButton.YesNo)

            If result = MessageResult.No Then
                e.Cancel = True
            End If
        End If
    End Function
```