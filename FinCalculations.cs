using AtorinVladyslavPZ_32Exam.Resources;
using System;
using System.Data.Entity;
using System.Linq;

namespace AtorinVladyslavPZ_32Exam
{
    public class FinCalculations : DbContext
    {
        // Your context has been configured to use a 'FinCalculations' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AtorinVladyslavPZ_32Exam.FinCalculations' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FinCalculations' 
        // connection string in the application configuration file.
        public FinCalculations()
            : base("name=FinCalculations")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<FinData> Expenditures { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}