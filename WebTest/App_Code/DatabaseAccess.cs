using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
namespace WebTest
{
    public class DatabaseAccess
    {
        Hashtable hh = new Hashtable();
        Hashtable connTable = new Hashtable();
        SqlConnection myConnection = null;
        SqlCommand cmd = null;
        SqlDataAdapter adapter = null;
        DataSet ds = null;
        public DatabaseAccess()
        {
            // connTable.Add("ConnDB230", "Data Source=192.168.1.202;Initial Catalog=PnF;User ID=bontonapi;Password=B0nt0nAp!;");

            // connTable.Add("ConnDB230", "Data Source=192.168.1.232;Initial Catalog=PnFTest;User ID=shahdul;Password=Aa123456;");
            connTable.Add("ConnDB230", "Data Source=192.168.1.232;Initial Catalog=testBarid;User ID=shahdul;Password=Aa123456;");
        }
        public SqlConnection getconnection()
        {
            string dbName = "ConnDB230";
            return myConnection = new SqlConnection(connTable[dbName].ToString());
        }
        public string getconnectionSting()
        {
            string dbName = "ConnDB230";
            return connTable[dbName].ToString();
        }
        public string ExecuteQuery(string query, string dbName)
        {
            string rValue = string.Empty;

            myConnection = new SqlConnection(connTable[dbName].ToString());
            try
            {
                cmd = new SqlCommand(query, myConnection);
                cmd.CommandTimeout = 60;
                myConnection.Open();
                rValue = cmd.ExecuteNonQuery().ToString();
                if (rValue == "-1")
                {
                    throw new Exception();

                }
            }
            catch (Exception ex)
            { rValue = ex.Message.ToString(); }
            finally
            {
                myConnection.Close();
                cmd = null;
                myConnection = null;
                query = null;
                //rValue = "1";
            }
            return rValue;
        }

        public object getObjectData(string query, string dbName)
        {
            myConnection = new SqlConnection(connTable[dbName].ToString());

            try
            {
                cmd = new SqlCommand(query, myConnection);
                myConnection.Open();
                object retValue = cmd.ExecuteScalar();
                return retValue;
            }
            catch (Exception ex)
            {
                return (object)ex.Message.ToString();
            }
            finally
            {
                myConnection.Close();
                cmd = null;
                myConnection = null;
                query = null;
                dbName = null;
            }
        }

        public string GetObjectDataId(string query, string dbName)
        {
            myConnection = new SqlConnection(connTable[dbName].ToString());
            string result = "";
            try
            {
                cmd = new SqlCommand(query, myConnection);
                myConnection.Open();
                object firstColumn = cmd.ExecuteScalar();

                if (firstColumn != null)
                {
                    result = firstColumn.ToString();
                    return result;
                }

            }
            catch (Exception ex)
            {
                return (string)ex.Message.ToString();
            }
            finally
            {
                myConnection.Close();
                cmd = null;
                myConnection = null;
                query = null;
                dbName = null;
            }
            return result;
        }
        public DataSet GetDataSet(string query, string dbName)
        {
            myConnection = new SqlConnection(connTable[dbName].ToString());
            ds = new DataSet();
            try
            {
                cmd = new SqlCommand(query, myConnection);
                adapter = new SqlDataAdapter();
                //cmd.CommandTimeout = 60;
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                    return ds;
                else
                    return null;
            }
            catch (Exception)
            { return null; }
            finally
            {
                adapter = null;
                cmd = null;
                myConnection = null;
                query = null;
            }
        }

        public DataTable GetDataTable(string query)
        {
            var dbName = "ConnDB230";
            myConnection = new SqlConnection(connTable[dbName].ToString());
            ds = new DataSet();
            var dt = new DataTable();
            try
            {
                cmd = new SqlCommand(query, myConnection);
                adapter = new SqlDataAdapter();
                //cmd.CommandTimeout = 60;
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            { return null; }
            finally
            {
                adapter = null;
                cmd = null;
                myConnection = null;
                query = null;
            }
        }

        public DataTable GetDataTableCensus(string query)
        {
            var dbName = "ConnDB231";
            myConnection = new SqlConnection(connTable[dbName].ToString());
            ds = new DataSet();
            var dt = new DataTable();
            try
            {
                cmd = new SqlCommand(query, myConnection);
                adapter = new SqlDataAdapter();
                //cmd.CommandTimeout = 60;
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            { return null; }
            finally
            {
                adapter = null;
                cmd = null;
                myConnection = null;
                query = null;
            }
        }

        public string getObjectDataStr(string query, string dbName)
        {
            myConnection = new SqlConnection(connTable[dbName].ToString());
            string result = "";
            try
            {
                cmd = new SqlCommand(query, myConnection);
                myConnection.Open();
                object firstColumn = cmd.ExecuteScalar();

                if (firstColumn != null)
                {
                    result = firstColumn.ToString();
                    return result;

                }

            }
            catch (Exception ex)
            {
                return (string)ex.Message.ToString();
            }
            finally
            {
                myConnection.Close();
                cmd = null;
                myConnection = null;
                query = null;
                dbName = null;
            }
            return result;
        }

        public string ExecuteTransactionQuery(string query, SqlConnection conn, SqlTransaction transaction)
        {

            string rValue = string.Empty;
            try
            {
                cmd = new SqlCommand(query, conn, transaction);
                cmd.CommandTimeout = 60;
                object firstColumn = cmd.ExecuteScalar();
                if (firstColumn != null)
                {
                    rValue = firstColumn.ToString();
                    return rValue;
                }
            }
            catch (Exception ex)
            { rValue = "failed"; }
            finally
            {

                cmd = null;

                query = null;
                //rValue = "1";
            }
            return rValue;
        }

    }
}