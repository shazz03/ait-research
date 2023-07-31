using System;
using System.Data.SqlClient;

namespace AITSurvey.Core.Repository
{
    public static class DataConvertorExtention
    {
        public static string GetString(this SqlDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? default : reader.GetString(reader.GetOrdinal(columnName));
        }

        public static int GetInt32(this SqlDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? default : reader.GetInt32(reader.GetOrdinal(columnName));
        }

        public static bool GetBoolean(this SqlDataReader reader, string columnName)
        {
            return !reader.IsDBNull(reader.GetOrdinal(columnName)) && reader.GetBoolean(reader.GetOrdinal(columnName));
        }

        public static DateTime GetDateTime(this SqlDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? default : reader.GetDateTime(reader.GetOrdinal(columnName));
        }
    }
}
