using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackItNow.Data
{
    public class DbSettings
    {
        public static string ConnectionString = "Data Source=127.0.0.1,1433; Persist Security Info=false; User ID=sa;Password=thisisastrongPassword!(); Initial Catalog=TrackItNow;";
    }
}
