using System;

namespace Neo4j.Driver.Logging.TestingApplication
{
    using System.Threading.Tasks;
    using Neo4j.Driver.Logging.Common;
    using Neo4j.Driver.Logging.ConsoleLogger;

    internal class Program
    {
        static async Task Main(string[] args)
        {
            var driver = GraphDatabase.Driver(
                "YourServer",
                AuthTokens.Basic("neo4j", "PASSWORD"), 
                cfg => cfg.WithLogger(new ConsoleLogger(LogLevel.Trace)));

            var session = driver.AsyncSession(cfg => cfg.WithDatabase("neo4j"));
            var result = await session.ReadTransactionAsync(async tx =>
            {
                var cursor = await tx.RunAsync("MATCH (n) RETURN COUNT(n)");
                if (await cursor.FetchAsync())
                    return cursor.Current["COUNT(n)"].As<int>();

                return int.MinValue;
            });

            Console.WriteLine($"There are {result} nodes in the DB");
            Console.ReadLine();
        }
    }
}
