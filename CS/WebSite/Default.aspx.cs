using System;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void ASPxGridView1_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e) {
        string[] param = e.Parameters.Split('|');
        if(param[0] == "oneRow") {
            int visibleIndex = int.Parse(param[1]);
            ASPxGridView grid = sender as ASPxGridView;
            ASPxTextBox tbCategoryName = grid.FindRowCellTemplateControl(visibleIndex, grid.Columns["CategoryName"] as GridViewDataColumn, "txtBox") as ASPxTextBox;
            ASPxTextBox tbDescription = grid.FindRowCellTemplateControl(visibleIndex, grid.Columns["Description"] as GridViewDataColumn, "txtBox") as ASPxTextBox;
            AccessDataSource1.UpdateParameters["CategoryName"].DefaultValue = tbCategoryName.Text;
            AccessDataSource1.UpdateParameters["Description"].DefaultValue = tbDescription.Text; ;
            AccessDataSource1.UpdateParameters["CategoryID"].DefaultValue = grid.GetRowValues(visibleIndex, "CategoryID").ToString();
            AccessDataSource1.Update();
        }
        ASPxGridView1.DataBind();

    }
    protected void ASPxButton1_Click(object sender, EventArgs e) {

    }
    protected void txtBox_Init(object sender, EventArgs e) {
        ASPxTextBox textBox = sender as ASPxTextBox;
        GridViewDataItemTemplateContainer container = textBox.NamingContainer as GridViewDataItemTemplateContainer;

        textBox.ClientSideEvents.GotFocus = string.Format("function(s, e){{ ProcessEditorFocus(s, e, {0}); }}", container.VisibleIndex);
    }
}
