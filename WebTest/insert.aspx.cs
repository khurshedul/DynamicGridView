using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace WebTest
{
    public partial class insert : System.Web.UI.Page
    {
        DatabaseAccess da = new DatabaseAccess();
        public string qr = "select * from product";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                refresh();
            }
       
        }

        private void refresh()
        {
            GridViewData.DataSource = da.GetDataSet(qr, "ConnDB230");
            GridViewData.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {

            
            string query = "insert into product values ('" + TextBoxProductCode.Text + "','" + TextBoxProductName.Text + "'," + Convert.ToDouble(TextBoxPrice.Text) + ",'" + YesNoRadio.SelectedValue + "')";
            da.ExecuteQuery(query, "ConnDB230");
            
            
        }

        protected void GridViewData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewData.EditIndex = -1;
            refresh();
        }

        protected void GridViewData_RowEditing(object sender, GridViewEditEventArgs e)
        {
  
            GridViewData.EditIndex = e.NewEditIndex;
            refresh();
         
        }
        

        protected void GridViewData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataSet ds = da.GetDataSet(qr,"ConnDB230");
            ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["Id"] };
            string  key = e.Keys["Id"].ToString();
            var drpgender = GridViewData.Rows[e.RowIndex].FindControl("DropDownList2") as DropDownList;
            string query = "update product set  ProductCode='" + e.NewValues["ProductCode"] + "',ProductName='" + e.NewValues["ProductName"] + "',ProductPrice=" + Convert.ToDouble(e.NewValues["ProductPrice"]) + ",IsActive='" + drpgender.SelectedItem.Value + "' where Id=" + key;

            da.ExecuteQuery(query, "ConnDB230");
         
            GridViewData.EditIndex = -1;
            refresh();
            
        }

        protected void GridViewData_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void GridViewData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Int32 index = e.NewPageIndex;
            GridViewData.PageIndex = index;
            refresh();
        }
    }
}
