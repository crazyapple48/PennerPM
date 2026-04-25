using Microsoft.EntityFrameworkCore;
using PennerProjectManager.Api.Entities;

namespace PennerProjectManager.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories => Set<Category>();

    public DbSet<Project> Projects => Set<Project>();

    public DbSet<ProjectTask> ProjectTasks => Set<ProjectTask>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Projects)
            .WithMany(p => p.Categories)
            .UsingEntity("CategoriesToProjectsJoinTable");
        modelBuilder.Entity<Project>()
            .HasMany(p => p.ProjectTasks)
            .WithMany(pt => pt.Projects)
            .UsingEntity("ProjectsToProjectTasksJoinTable");

        modelBuilder.Entity<Project>()
            .HasIndex(p => p.Name)
            .IsUnique();

        modelBuilder.Entity<ProjectTask>()
            .HasIndex(pt => pt.Name)
            .IsUnique();
    }
}
