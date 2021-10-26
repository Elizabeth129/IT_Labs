
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LAB_IT_API.Models
{
    public interface IDatabaseService
    {
        public Task<List<Database>> GetDatabases();
        public Task<int> GetDatabaseId(string name);
        public Task UpdateDatabase(Database database);
        public Task CreateDatabase(Database database);
        public Task DeleteDatabase(Database database);
        public Task<bool> DatabaseExists(int id);
    }

    public class DatabaseService : IDatabaseService
    {
        private readonly DatabaseContext _context;
        public DatabaseService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<Database>> GetDatabases()
        {
            return await _context.Databases.Include(d => d.Tables).ToListAsync();
        }
        public async Task<int> GetDatabaseId(string name)
        {
            return await _context.Databases.Where(d => d.Name == name).Select(m => m.Id).FirstAsync();
        }
        public async Task UpdateDatabase(Database database)
        {
            _context.Entry(database).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task CreateDatabase(Database database)
        {
            _context.Databases.Add(database);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDatabase(Database database)
        {
            _context.Databases.Remove(database);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DatabaseExists(int id)
        {
            return await _context.Databases.AnyAsync(e => e.Id == id);
        }
    }

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Database> Databases { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<ColumnDefinition> ColumnDefinition { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Database>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id").IsRequired();
                entity.Property(e => e.Name).HasColumnName("name").IsRequired();
                entity.HasIndex(e => e.Name).IsUnique();
            });
            modelBuilder.Entity<Table>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id").IsRequired();
                entity.Property(e => e.Name).HasColumnName("name").IsRequired();
                entity.Property(e => e.ParentId).HasColumnName("parent_id").IsRequired();

                entity.HasOne(t => t.Parent)
                    .WithMany(d => d.Tables)
                    .HasForeignKey(t => t.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Table_Database")
                    .IsRequired();
                entity.HasIndex(e => new { e.Name, e.ParentId }).IsUnique();
            });
            modelBuilder.Entity<ColumnDefinition>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id").IsRequired();
                entity.Property(e => e.Name).HasColumnName("name").IsRequired();
                entity.Property(e => e.ParentId).HasColumnName("parent_id").IsRequired();
                entity.Property(e => e.Type).HasColumnName("type").IsRequired();

                entity.HasOne(c => c.Parent)
                    .WithMany(t => t.ColumnDefinitions)
                    .HasForeignKey(c => c.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Column_Table")
                    .IsRequired();
                entity.HasIndex(e => new { e.Name, e.ParentId }).IsUnique();
            });
            modelBuilder.Entity<Row>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id").IsRequired();
                entity.Property(e => e.ParentId).HasColumnName("parent_id").IsRequired();

                entity.HasOne(r => r.Parent)
                    .WithMany(t => t.Data)
                    .HasForeignKey(r => r.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Row_Table")
                    .IsRequired();
            });
            modelBuilder.Entity<Element>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id").IsRequired();
                entity.Property(e => e.ParentId).HasColumnName("parent_id").IsRequired();

                entity.HasOne(e => e.Parent)
                    .WithMany(r => r.Elements)
                    .HasForeignKey(e => e.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Element_Row")
                    .IsRequired();
            });
        }
    }
}
