//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.SqlServer;
using SubjectTrackerApi.Models;

namespace SubjectTrackerApi.Brokers
{
    public class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private IConfiguration configuration;

        public StorageBroker(IConfiguration konsconfiguration)
        {
            this.configuration = konsconfiguration;
            this.Database.Migrate();
        }

        public DbSet <Subject> subjects { get; set; }

        public async Task<Subject> InsertSubjectAsync(Subject subject)
        {
            StorageBroker storageBroker = new StorageBroker(this.configuration);
            await storageBroker.AddAsync(subject);
            await storageBroker.SaveChangesAsync();
            
            return subject;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionPath = this.configuration.GetConnectionString("DefaulConnection");
            optionsBuilder.UseSqlServer(connectionPath); 
        }
    }
}
