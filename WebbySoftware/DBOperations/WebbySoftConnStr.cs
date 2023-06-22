using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

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
            var userInfo = uri.UserInfo.Split(':');
            var user = userInfo.Length > 0 ? userInfo[0] : string.Empty;
            var passwd = userInfo.Length > 1 ? userInfo[1] : string.Empty;
            var port = uri.Port > 0 ? uri.Port : 5432;
            var connStr = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4}",
                uri.Host, db, user, passwd, port);
            return connStr;
        }
    }
}