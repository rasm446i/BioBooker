using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BioBooker.WebApi.UnitTests
{
    public class DatabaseConnection
    {
        private string GetConnectionString()
        {
            return "server=localhost; Database=BioBooker; integrated security=true;";
        }

        [Fact]
        public void TestConnectionString()
        {
            string connectionString = GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Assert.True(true);
                }
                catch (Exception)
                {
                    Assert.True(false, "Cannot open database connection. Check the connection string.");
                }
            }
        }







    }
}
