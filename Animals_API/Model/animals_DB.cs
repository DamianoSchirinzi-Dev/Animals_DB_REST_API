using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Animals_API.Model;

public partial class animals_DB : DbContext
{
    public animals_DB()
    {
    }

    public animals_DB(DbContextOptions<animals_DB> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:damianodevserver.database.windows.net,1433;Initial Catalog=Learning_DB;Persist Security Info=False;User ID=damidev;Password=Bd2d04c5d3d235bc8891da32def1eea315a7fe34\n;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;\n");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__animals__3213E83FD6A6B004");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
