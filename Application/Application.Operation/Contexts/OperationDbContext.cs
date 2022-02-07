using Application.Operation.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Operation.Contexts
{
    public class OperationDbContext : DbContext, IOperationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public OperationDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<ApplicationUser>()
            //     .ToTable("AspNetUsers", x => x.ExcludeFromMigrations())
            //     .HasMany<Question>()
            //     .WithOne(x => x.ApplicationUser);

            // modelBuilder.Entity<Question>()
            //     .HasMany(q => q.Comments)
            //     .WithOne(c => c.Question)
            //     .HasForeignKey(c => c.QuestionId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
    }
}
