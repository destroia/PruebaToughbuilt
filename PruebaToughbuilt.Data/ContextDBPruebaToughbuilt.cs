using Microsoft.EntityFrameworkCore;
using PruebaToughbuilt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaToughbuilt.Data
{
    public class ContextDBPruebaToughbuilt : DbContext
    {
        public ContextDBPruebaToughbuilt(DbContextOptions<ContextDBPruebaToughbuilt> opt):base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=.;Initial Catalog=PruebaToughbuiltDB;Integrated Security=true"
             );
            base.OnConfiguring(optionsBuilder);
            //Primer Migracion   Add-Migration InitialCreate
            //Despues de la primera migracion se utiliza  Update-Database
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
