using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classified.Common.AppSettings
{
    public class AppSettings
    {
        public JWToptions JWT { get; set; }

        public SqlServerOptions SqlServer { get; set; }
    }

    public class JWToptions
    {
        public double Expiry { get; set; }

        public bool ValidateIssuer { get; set; }

        public int SigningKey { get; set; }
    }

    public  class SqlServerOptions
    {
        public string ConnectionStrings { get; set; }
    }
}
