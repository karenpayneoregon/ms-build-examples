using System.Data;
//using SLD = SqlServerLibrary.DataHelpers;

namespace MSBuildUsingExampleApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            /*
             * Here we use an using directive setup in the project file rather than
             * using a directive in this file as per the one commented out above
             */
            Console.WriteLine(SLD.ExpressDatabaseExists("NorthWind2022") ? "Exists" : "Not found");

            /*
             * To prevent a conflict with the framework DataTable, a alias is defined in the project file
             */
            SLM.DataTable dataTable1 = new SLM.DataTable
            {
                CaseSensitive = true,
                Stash = "secret stuff"
            };

            Console.WriteLine($"{dataTable1.Stash, -16}{dataTable1.CaseSensitive}");

            /*
             * System.Data.DataTable
             */
            var dataTable2 = new DataTable();
            dataTable2.CaseSensitive = true;
            Console.WriteLine(dataTable2.CaseSensitive);
            Console.ReadLine();
        }
    }
}