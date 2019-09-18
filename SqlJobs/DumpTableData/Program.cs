using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpTableData
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Read Configurations Data.
            string sourceCS = Convert.ToString(ConfigurationManager.ConnectionStrings["SourceCS"]);
            string destinationCS = Convert.ToString(ConfigurationManager.ConnectionStrings["DestinationCS"]);
            string sourceQuery = Convert.ToString(ConfigurationManager.AppSettings["SourceQuery"]);
            string destinationQuery = Convert.ToString(ConfigurationManager.AppSettings["DestinationQuery"]);

            #endregion

            #region Read source table Data and Write into destination table.
            if (!string.IsNullOrEmpty(sourceCS) && !string.IsNullOrEmpty(destinationCS)&&!string.IsNullOrEmpty(sourceQuery) && !string.IsNullOrEmpty(destinationQuery))
            {
                try
                {
                    SqlConnection sourceCon = new SqlConnection(sourceCS);
                    SqlCommand cmd = new SqlCommand("Select * from Departments", sourceCon);
                    sourceCon.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    SqlConnection destinationCon = new SqlConnection(destinationCS);
                    using (SqlBulkCopy bc = new SqlBulkCopy(destinationCon))
                    {
                        bc.DestinationTableName = "Departments";
                        destinationCon.Open();
                        bc.WriteToServer(rdr);
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                }

            }
            else
            {
                Console.WriteLine("Configuration value not found!!!");
            }
            #endregion

            #region Write into destination table.


            #endregion

        }
    }
}
