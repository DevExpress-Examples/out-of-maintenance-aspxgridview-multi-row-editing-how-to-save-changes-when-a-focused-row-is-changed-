Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Web

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
		Dim param() As String = e.Parameters.Split("|"c)
		If param(0) = "oneRow" Then
			Dim visibleIndex As Integer = Integer.Parse(param(1))
			Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
			Dim tbCategoryName As ASPxTextBox = TryCast(grid.FindRowCellTemplateControl(visibleIndex, TryCast(grid.Columns("CategoryName"), GridViewDataColumn), "txtBox"), ASPxTextBox)
			Dim tbDescription As ASPxTextBox = TryCast(grid.FindRowCellTemplateControl(visibleIndex, TryCast(grid.Columns("Description"), GridViewDataColumn), "txtBox"), ASPxTextBox)
			AccessDataSource1.UpdateParameters("CategoryName").DefaultValue = tbCategoryName.Text
			AccessDataSource1.UpdateParameters("Description").DefaultValue = tbDescription.Text

			AccessDataSource1.UpdateParameters("CategoryID").DefaultValue = grid.GetRowValues(visibleIndex, "CategoryID").ToString()
			AccessDataSource1.Update()
		End If
		ASPxGridView1.DataBind()

	End Sub
	Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub txtBox_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim textBox As ASPxTextBox = TryCast(sender, ASPxTextBox)
		Dim container As GridViewDataItemTemplateContainer = TryCast(textBox.NamingContainer, GridViewDataItemTemplateContainer)

		textBox.ClientSideEvents.GotFocus = String.Format("function(s, e){{ ProcessEditorFocus(s, e, {0}); }}", container.VisibleIndex)
	End Sub
End Class
