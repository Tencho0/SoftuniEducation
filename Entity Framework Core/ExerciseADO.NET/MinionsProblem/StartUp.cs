using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace T2.VillainNames
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            sqlConnection.Open();
            string result = GetVillainNameWithMinionsCount(sqlConnection);
            Console.WriteLine(result);

            sqlConnection.Close();
        }

        private static string GetVillainNameWithMinionsCount(SqlConnection sqlConnection)
        {
            StringBuilder output = new StringBuilder();
            string query = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                FROM Villains AS v 
                                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                            GROUP BY v.Id, v.Name 
                              HAVING COUNT(mv.VillainId) > 3 
                            ORDER BY COUNT(mv.VillainId)";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                output.AppendLine($"{reader["Name"]} - {reader["MinionsCount"]}");
            }

            return output.ToString().TrimEnd();
        }
        
        private static string GetVillainWithMinions(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder output = new StringBuilder();
            string villainNameQuery = @"SELECT [Name]
                                          FROM [Villains]
                                         WHERE [Id] = @VillainId";
            SqlCommand getVillainNameCmd = new SqlCommand(villainNameQuery, sqlConnection);
            getVillainNameCmd.Parameters.AddWithValue("@VillainId", villainId);

            string villainName = (string)getVillainNameCmd.ExecuteScalar();
            if (villainName == null)
            {
                return $"No villain with ID {villainId} exists in the database.";
            }

            output.AppendLine($"Villain: {villainName}");

            string minionsQuery = @" SELECT [m].[Name]
                                            [m].[Age]
                                       FROM [Villains] AS [v]
                                  LEFT JOIN [MinionsVillains] AS [mv] ON [v].[Id] = [mv].[VillainId]
                                  LEFT JOIN [Minions] AS [m] ON [m].[Id] = [mv].[MinionId]
                                      WHERE [mv].[VillainId] = @VillainId
                                   ORDER BY [m].[Name]";
            SqlCommand getMinionsCommand = new SqlCommand(minionsQuery, sqlConnection);
            getMinionsCommand.Parameters.AddWithValue("@VillainId", villainId);

            using SqlDataReader miniosReader = getMinionsCommand.ExecuteReader();
            if (!miniosReader.HasRows)
            {
                output.AppendLine("(no minions)");
            }
            else
            {
                int rowNum = 1;
                while (miniosReader.Read())
                {
                    output.AppendLine($"{rowNum}. {miniosReader["Name"]} {miniosReader["Age"]}");
                    rowNum++;
                }
            }

            return output.ToString().TrimEnd();
        }
    }
}
