<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title></title>

	<script type="text/javascript">
		function ProcessEditorFocus(s, e, index) {
			grid.SetFocusedRowIndex(index);
		}

		var lastFocusedRow = 0;
		function OnFocusedRowChanged(s, e) {
			if (textChangedFlag) {
				s.PerformCallback("oneRow|" + lastFocusedRow);
				textChangedFlag = false;
			}
			lastFocusedRow = s.GetFocusedRowIndex();
		}

		var textChangedFlag = false;
		function OnTextChanged(s, e) {
			textChangedFlag = true;
		}
	</script>

</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" KeyFieldName="CategoryID"
			DataSourceID="AccessDataSource1" Width="599px" ClientInstanceName="grid" OnCustomCallback="ASPxGridView1_CustomCallback">
			<ClientSideEvents FocusedRowChanged="OnFocusedRowChanged" />
			<Columns>
				<dx:GridViewDataTextColumn FieldName="CategoryID" ReadOnly="True" VisibleIndex="0">
					<EditFormSettings Visible="False" />
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="CategoryName" VisibleIndex="1">
					<DataItemTemplate>
						<dx:ASPxTextBox ID="txtBox" Width="100%" runat="server" Value='<%#Eval("CategoryName")%>'
							OnInit="txtBox_Init">
							<ClientSideEvents TextChanged="OnTextChanged" />
						</dx:ASPxTextBox>
					</DataItemTemplate>
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2">
					<DataItemTemplate>
						<dx:ASPxTextBox ID="txtBox" Width="100%" runat="server" Value='<%#Eval("Description")%>'
							OnInit="txtBox_Init">
							<ClientSideEvents TextChanged="OnTextChanged" />
						</dx:ASPxTextBox>
					</DataItemTemplate>
				</dx:GridViewDataTextColumn>
			</Columns>
			<SettingsBehavior AllowFocusedRow="true" />
		</dx:ASPxGridView>
		<asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
			SelectCommand="SELECT * FROM [Categories]" UpdateCommand="UPDATE [Categories] SET [CategoryName] = ?, [Description] = ? WHERE [CategoryID] = ?">
			<UpdateParameters>
				<asp:Parameter Name="CategoryName" Type="String" />
				<asp:Parameter Name="Description" Type="String" />
				<asp:Parameter Name="CategoryID" Type="Int32" />
			</UpdateParameters>
		</asp:AccessDataSource>
	</div>
	</form>
</body>
</html>
