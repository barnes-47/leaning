using Microsoft.EntityFrameworkCore;
using WebApi.Infrastructure.Dto;

namespace WebApi.Infrastructure.Db.Context
{
    public class ApplicationContext : DbContext
    {
        private readonly DbContextOptions<ApplicationContext> _options;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Remove pluralizing table name convention
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }

            base.OnModelCreating(builder);
        }

        internal DbSet<User> Users { get; set; }
    }
}
