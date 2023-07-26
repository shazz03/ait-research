using System.Configuration;

namespace AITResearch.Core.Database
{
    public class Connection
    {
        public static string ConnectionString =>
              ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    }
}
