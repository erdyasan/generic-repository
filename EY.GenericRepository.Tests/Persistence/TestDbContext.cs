using EY.GenericRepository.Tests.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace EY.GenericRepository.Tests.Persistence;

public sealed class TestDbContext : DbContext
{
    public DbSet<TestEntity> TestEntities { get; set; } = null!;
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
    }

}