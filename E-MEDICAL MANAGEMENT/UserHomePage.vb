Public Class UserHomePage
    Private Sub UserHomePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblName.Text = StartPage.userName.ToString()
    End Sub

    Private Sub btnLaboratories_Click(sender As Object, e As EventArgs) Handles btnLaboratories.Click
        Me.Hide()
        Laboratories.Show()
    End Sub

    Private Sub btnDiagnosis_Click(sender As Object, e As EventArgs) Handles btnDiagnosis.Click
        Me.Hide()
        Diagnosis.Show()
    End Sub

    Private Sub btnMedicalStore_Click(sender As Object, e As EventArgs) Handles btnMedicalStore.Click
        Me.Hide()
        MedicalStore.Show()
    End Sub

    Private Sub llLogOut_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llLogOut.LinkClicked
        Me.Hide()
        StartPage.Show()
    End Sub
End Class