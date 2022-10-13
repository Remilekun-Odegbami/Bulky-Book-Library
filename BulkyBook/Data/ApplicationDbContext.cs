using BulkyBook.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.Data
{
    public class ApplicationDbContext : DbContext
    {
        // syntax needed to create the connection with the database (configure DB Context)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}


/*Models of Entity Framework -> code first, 
 * database first scaffolding the code later
 * Migration... keeping track of all the dbs changes that are needed, once this change is made, the migration is then pushed to the database to make changes to the table
 
 */
