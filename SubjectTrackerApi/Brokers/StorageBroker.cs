//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.SqlServer;
using SubjectTrackerApi.Models;

namespace SubjectTrackerApi.Brokers
{
    public interface IStorageBroker
    {

    }

    public class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private IConfiguration configuration;

        public StorageBroker(IConfiguration konsconfiguration)
        {
            this.configuration = konsconfiguration;
            this.Database.Migrate();
        }

        public DbSet <Subject> subjects { get; set; }   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionPath = this.configuration.GetConnectionString("DefaulConnection");
            optionsBuilder.UseSqlServer(connectionPath); 
        }
    }
}
