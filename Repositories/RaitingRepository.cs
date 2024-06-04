using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RaitingRepository : IRaitingRepository
    {
        public IConfiguration _configuration { get; }

        public RaitingRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task addActionToDB(Rating raiting)
        {
                string query = "INSERT INTO Rating(HOST, METHOD, PATH, REFERER, USER_AGENT,RECORD_DATE)" +
                    "VALUES (@host, @method, @path, @referer, @user_agent,@record_date)";

                using (SqlConnection cn = new SqlConnection(_configuration["ConnectionString"]))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@host",raiting.Host);
                    cmd.Parameters.AddWithValue("@method",raiting.Method);
                    cmd.Parameters.AddWithValue("@path", raiting.Path);
                    cmd.Parameters.AddWithValue("@referer", raiting.Referer);
                    cmd.Parameters.AddWithValue("@user_agent", raiting.UserAgent);
                    cmd.Parameters.AddWithValue("@record_date", raiting.RecordDate);

                    cn.Open();
                    await cmd.ExecuteNonQueryAsync();
                    cn.Close();

                    
                }
         
        }
    }
}
