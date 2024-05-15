using Microsoft.EntityFrameworkCore;
using TrinityShop.Models.Client;

namespace TrinityShop.Models;

public interface IDbContextTrinity
{
    DbSet<ClientModel> Clients { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
}
public class DbContextTrinity : DbContext, IDbContextTrinity
{
    public DbContextTrinity(DbContextOptions<DbContextTrinity>options): base(options)
    {
    }
    public DbSet<ClientModel> Clients { get; set; } 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientModel>().ToTable("Clients");
        modelBuilder.Entity<ClientModel>()
            .Property(c => c.id_client)
            .HasDefaultValueSql("uuid_generate_v4()");
        modelBuilder.Entity<ClientModel>()
            .Property(c => c.created_at)
            .HasDefaultValueSql("Now()");
        modelBuilder.Entity<ClientModel>()
            .Property(c => c.update_at)
            .IsRequired(false);
        modelBuilder.Entity<ClientModel>()
            .Property(c => c.document_type)
            .IsRequired(true);
        
    }
}

