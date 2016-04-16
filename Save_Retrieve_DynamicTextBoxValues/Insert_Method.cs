// An Insert Method
    private void InsertRecords(StringCollection sc)
    {
      SqlConnection conn = new SqlConnection(GetConnectionString());
        StringBuilder sb = new StringBuilder(string.Empty);
        string[] splitItems = null;
        foreach (string item in sc)
        {
            const string sqlStatement = "INSERT INTO DemoTab (Column1,Column2,Column3,Column4,Column5) VALUES";
            if (item.Contains(","))
           {
                splitItems = item.Split(",".ToCharArray());
                sb.AppendFormat("{0}('{1}','{2}','{3}',’{4}’,’{5}’); ", sqlStatement, splitItems[0], splitItems[1], splitItems[2]);
            }
        }
        
        
        try
       {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records are Saved Successfuly!');", true);
       }
       
       
        catch (System.Data.SqlClient.SqlException ex)
      {
            string msg = "Insert Error:";
            msg += ex.Message;
           throw new Exception(msg);
        }
        
        
        finally
        {
            conn.Close();
      }
    }
