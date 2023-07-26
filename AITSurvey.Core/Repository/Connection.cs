using System.Configuration;

namespace AITSurvey.Core.Database
{
    public class Connection
    {
        public static string ConnectionString =>
              ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    }
}
