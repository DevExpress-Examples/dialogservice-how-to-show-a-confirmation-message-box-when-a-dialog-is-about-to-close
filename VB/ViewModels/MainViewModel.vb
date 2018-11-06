Imports DevExpress.Mvvm

Public Class MainViewModel
    Inherits ViewModelBase

    Protected ReadOnly Property DialogService As IDialogService
        Get
            Return Me.GetService(Of IDialogService)()
        End Get
    End Property

    Public Sub New()
        ShowDialogCommand = New DelegateCommand(AddressOf ShowDialog)
    End Sub

    Public Property ShowDialogCommand As DelegateCommand

    Public Async Sub ShowDialog()
        Dim result = Await DialogService.ShowDialogAsync(MessageButton.OKCancel, "My Dialog Window", "DialogView", Nothing, Me)
    End Sub
End Class
