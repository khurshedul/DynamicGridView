using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTest
{
    public partial class test : System.Web.UI.Page
    {
        DatabaseAccess da = new DatabaseAccess();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (ViewState["CurrentTable"] != null)
            {
                AddNewRow();
            }
            else
            {
                FirstGridViewRow();
            }


        }
        private void refresh()
        {
            GridViewShowData.DataSource = (DataTable)ViewState["CurrentTable"];
            GridViewShowData.DataBind();
        }
        private void FirstGridViewRow()
        {
            DataTable dt = new DataTable();
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Id", typeof(string));
                dt.Columns.Add("ProductName", typeof(string));
                dt.Columns.Add("Quantity", typeof(string));

            }

            DataRow NewRow = dt.NewRow();
            NewRow[0] = hdnTextBoxProductName.Value;
            NewRow[1] = TextBoxProductName.Text;
            NewRow[2] = TextBoxProductQuantity.Text;
          
            ViewState["Quantity"] = TextBoxProductQuantity.Text;
            TextBoxProductName.Text = TextBoxProductQuantity.Text = "";
            Label1.Text = ViewState["Quantity"].ToString();


            dt.Rows.Add(NewRow);
            ViewState["CurrentTable"] = dt;
            GridViewShowData.DataSource = dt;
            GridViewShowData.DataBind();
        }

       
        private void AddNewRow()
        {
            int rowIndex = 0;
            int x = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow[0] = hdnTextBoxProductName.Value;
                        drCurrentRow[1] = TextBoxProductName.Text;
                        drCurrentRow[2] = TextBoxProductQuantity.Text;

                         x = Convert.ToInt16( ViewState["Quantity"]) +Convert.ToInt16( TextBoxProductQuantity.Text );


                        rowIndex++;
                       
                    }
                    ViewState["Quantity"] = x;
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    Label1.Text = ViewState["Quantity"].ToString();
                   TextBoxProductName.Text = TextBoxProductQuantity.Text = "";
                    GridViewShowData.DataSource = dtCurrentTable;
                    GridViewShowData.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
          
        }



        protected void Submit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = da.getconnection();
            conn.Open();
            
            if (ViewState["CurrentTable"] != null)
            {
                
                string QueryForOrder = "INSERT INTO  [Order] VALUES(" + Convert.ToInt16(ViewState["Quantity"]) + ") SELECT SCOPE_IDENTITY()";
                var cmd = new SqlCommand(QueryForOrder,conn);
               int ordId=Convert.ToInt16( cmd.ExecuteScalar());
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                foreach (DataRow row in dtCurrentTable.Rows)
                {
                    string id = row[0].ToString();
                    string name = row[1].ToString();
                    string quantity = row[2].ToString();

                    string QueryForOrdDetails = "INSERT INTO OrdDetails OUTPUT Inserted.Id VALUES(" + Convert.ToInt16(id) + "," + ordId + "," + Convert.ToInt16(quantity) + ")";

                    da.ExecuteQuery(QueryForOrdDetails, "ConnDB230");
                  
                }
                ViewState["CurrentTable"] = null;
                GridViewShowData.DataSource = null;
                GridViewShowData.DataBind();
            }
            
            }
        

        [WebMethod]
        public static string[] GetProducts(string prefix)
        {
            List<string> products = new List<string>();

            var da = new DatabaseAccess();
            SqlConnection conn = da.getconnection();


            using (var cmd = new SqlCommand())
            {
                cmd.CommandText = "select ProductName, Id from product where " +
                "ProductName like '%" + prefix + "%'";
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        products.Add(string.Format("{0}-{1}", sdr["ProductName"], sdr["Id"]));
                    }
                }
                conn.Close();
            }
            return products.ToArray();
        }

        protected void GridViewShowData_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void GridViewShowData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewShowData.EditIndex = -1;
            refresh();
        }

        protected void GridViewShowData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable) ViewState["CurrentTable"];
                
                int rowIndex = Convert.ToInt32(e.RowIndex);

                dt.Rows.Remove(dt.Rows[rowIndex]);
                    DataRow drCurrentRow = null;
                    drCurrentRow = dt.NewRow();

                if (dt.Rows.Count > 0)
                {
                    ViewState["CurrentTable"] = dt;
                }
                else
                {
                    ViewState["CurrentTable"] = null;
                }

                refresh();
            }
            
        }

        protected void GridViewShowData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
             DataRow drCurrentRow =dtCurrentTable.NewRow();
            drCurrentRow = dtCurrentTable.Select("Id=" + e.NewValues["Id"]).FirstOrDefault();
            if (drCurrentRow != null)
            {
                drCurrentRow["id"] = e.NewValues["Id"];
                drCurrentRow["ProductName"] = e.NewValues["ProductName"];
                drCurrentRow["Quantity"] = e.NewValues["Quantity"];
                dtCurrentTable.Rows.Equals(drCurrentRow);
            }
            ViewState["CurrentTable"] = dtCurrentTable;
            GridViewShowData.EditIndex = -1;
            refresh();
        }

        protected void GridViewShowData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewShowData.EditIndex = e.NewEditIndex;
            
            refresh();
        }
    }

}

