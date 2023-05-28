using EY.GenericRepository.Concretes;
using EY.GenericRepository.Contracts;
using EY.GenericRepository.Tests.Persistence;
using EY.GenericRepository.Tests.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace EY.GenericRepository.Tests;

public sealed class RepositoryTests
{

    private TestDbContext _dbContext;
    private IRepository<TestEntity> _repository;
    private IUow _uow;

    [SetUp]
    public void Setup()
    {
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<TestDbContext>();
        dbContextOptionsBuilder.UseInMemoryDatabase("TestDb");
        _dbContext = new TestDbContext(dbContextOptionsBuilder.Options);
        _uow = new Uow<TestDbContext>(_dbContext);
        _repository = _uow.GetRepository<TestEntity>();
    }

    [Test]
    [Order(1)]
    public void AddTest()
    {
        _repository.Add(new TestEntity { Id = 1, Name = "Test Ediyorum" });
        _uow.SaveChanges();
        var entity = _repository.FirstOrDefault(x => true);
        Assert.AreEqual("Test Ediyorum", entity?.Name);
    }


    [Test]
    [Order(2)]
    public void RemoveTest()
    {
        var entity = _repository.First(x => true);
        _repository.Delete(entity);
        _uow.SaveChanges();
        var entityCount = _repository.Count(x => true);
        Assert.AreEqual(0, entityCount);
    }

    [Test]
    [Order(3)]
    public async Task AddRangeTest()
    {
        _repository.AddRange(new List<TestEntity>
        {
            new TestEntity { Id = 1, Name = "Test Ediyorum" },
            new TestEntity { Id = 2, Name = "Test Ediyorum 2" },
            new TestEntity { Id = 3, Name = "Test Ediyorum 3" },
            new TestEntity { Id = 4, Name = "Test Ediyorum 4" },
            new TestEntity { Id = 5, Name = "Test Ediyorum 5" },
        });
        _uow.SaveChanges();
        var entityCount = await _repository.CountAsync(x => true);
        Assert.AreEqual(5, entityCount);
    }
    [Test]
    [Order(4)]
    public void RemoveBulkTest()
    {
        var entities = _repository.GetByCondition(x => true);
        _repository.DeleteRange(entities);
        _uow.SaveChanges();
        var entityCount = _repository.Count(x => true);
        Assert.AreEqual(0, entityCount);
    }
}