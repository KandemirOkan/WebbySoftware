using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace WebbySoftware.DBOperations
{
    public class WebbySoftConnStr
    {
        private readonly IConfiguration _configuration;

        public WebbySoftConnStr(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            var uriString = _configuration.GetConnectionString("ElephantSQLConnection") ?? "postgres://localhost/mydb";
            var uri = new Uri(uriString);
            var db = uri.AbsolutePath.Trim('/');
            var user = uri.UserInfo.Split(':')[0];
            var passwd = uri.UserInfo.Split(':')[1];
            var port = uri.Port > 0 ? uri.Port : 5432;
            var connStr = string.Format("Server={0};Port={4};Database={1};User Id={2};Password={3};",
                uri.Host, db, user, passwd, port);
            return connStr;
        }


    }
}