using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using YUI.Models;

namespace YUI.Services
{
    public class TestService
    {
        public List<Test> SelectAll()
        {
            using (var con = GetConnection())
            {
                var cmd = con.CreateCommand();

                cmd.CommandText = "Test_SelectAll";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    var testSelectAll = new List<Test>();

                    while (reader.Read())
                    {
                        //this loop will happen once for every row
                        var test = new Test
                        {
                            Id = (int)reader["id"],
                            FirstName = (string)reader["firstName"],
                            LastName = (string)reader["lastName"]
                        };
                        testSelectAll.Add(test);
                    }
                    return testSelectAll;
                }

            } //calls con.Dispose()  what using (line15) does  (because SqlConnection implements IDisposable)
        }
        public int Create(TestCreate request)
        {
            using (var con = GetConnection())
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Test_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstName", request.FirstName);
                cmd.Parameters.AddWithValue("@lastName", request.LastName);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                //executeNonQuery means no rows will come back out
                return (int)cmd.Parameters["@Id"].Value;
            }
        }
        //helper method to create and open a database connection
        SqlConnection GetConnection()
        {

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            con.Open();
            return con;
        }
    }
}