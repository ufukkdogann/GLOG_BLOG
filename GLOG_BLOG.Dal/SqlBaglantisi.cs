using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLOG_BLOG.Dal
{
    public class SqlBaglantisi
    {
        public static SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=BLOG_GLOG;Integrated Security=True");
    }
}
