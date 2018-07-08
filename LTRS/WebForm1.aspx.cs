using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using LTRS.DataAccess;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace LTRS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginDA loginDA = new LoginDA();
            DataSet dslogin = null;
            dslogin = loginDA.FetchFirstname(Convert.ToInt32(Session["UserID"].ToString()));
            ReportDataSource rd = new ReportDataSource("DataSet1", FetchFirstname((Convert.ToInt32(Session["UserID"].ToString()))));
            ReportViewer1.Reset();
            ReportViewer1.LocalReport.DataSources.Add(rd);
            ReportViewer1.LocalReport.ReportPath = "Report1.rdlc";
        }
        public DataTable FetchFirstname(int userid)
        {
            Database db = null;
            DbCommand dbCmd = null;
            DataSet ds = null;

            try
            {
                //Database Connection String
                db = DatabaseFactory.CreateDatabase(AllDA.DATABASE_CONNECTION_STRING);
                //Access Stored Procedure
                dbCmd = db.GetStoredProcCommand(AllDA.FETCH_FIRST_NAME);
                //Pass parameteres in stored procedure
                db.AddInParameter(dbCmd, "@USER_ID", DbType.Int32, userid);

                //Execute database commands and store results in dataset
                ds = db.ExecuteDataSet(dbCmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                AllDA.Destroy(ref dbCmd);
            }
            //return dataset 
            return ds.Tables[0];
        }
    }
}