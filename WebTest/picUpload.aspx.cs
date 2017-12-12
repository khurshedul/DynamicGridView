using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTest
{
    public partial class picUpload : System.Web.UI.Page
    {
        DatabaseAccess da= new DatabaseAccess();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Upload_Click(object sender, EventArgs e)
        {

            string fileName = "abc1.jpg"; //Path.GetFileName(pic.PostedFile.FileName);

            pic.PostedFile.SaveAs(Server.MapPath("~/pic/") + fileName);
            string query = "insert into picuplad values (1,1,'/pic/','"+fileName+"')";
            da.ExecuteQuery(query, "ConnDB230");
            // Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}