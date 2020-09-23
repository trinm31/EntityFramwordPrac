using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EF_2
{
    internal class Program
    {
        public static async Task CreateDatabase ()
        {
            using (var dbcontext = new ProductContext ()) {
                // mydata
                String databasename = dbcontext.Database.GetDbConnection ().Database;

                Console.WriteLine ("Tạo " + databasename);

                bool result = await dbcontext.Database.EnsureCreatedAsync ();
                string resultstring = result ? "tạo  thành  công" : "đã có trước đó";
                Console.WriteLine ($"CSDL {databasename} : {resultstring}");
            }
        }
        public static async Task Main(string[] args)
        {
            await CreateDatabase();
            Console.ReadKey();
        }
    }
}