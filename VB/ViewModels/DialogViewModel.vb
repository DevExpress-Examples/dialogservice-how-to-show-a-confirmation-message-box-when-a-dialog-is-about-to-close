Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.UI

Public Class DialogViewModel
    Inherits ViewModelBase
    Implements IDialogDocumentContent

    Public Property Caption As String = "This dialog window cannot be canceled until you click Yes in the confirmation message box. "
    Public Property Dialog As IDialogDocumentOwner Implements IDialogDocumentContent.Dialog

    Protected ReadOnly Property MessageBoxService As IMessageBoxService
        Get
            Return Me.GetService(Of IMessageBoxService)()
        End Get
    End Property

    Public Async Function OnCloseAsync(ByVal e As ClosingDialogEventArgs) As Task Implements IDialogDocumentContent.OnCloseAsync
        If Me.MessageBoxService IsNot Nothing AndAlso CType(e.Id, MessageResult) = MessageResult.Cancel Then
            Dim result = Await Me.MessageBoxService.ShowAsync("Do you really want to cancel this dialog?", "Confirmation", MessageButton.YesNo)

            If result = MessageResult.No Then
                e.Cancel = True
            End If
        End If
    End Function
End Class
