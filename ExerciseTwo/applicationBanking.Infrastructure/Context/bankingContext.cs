using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

/// <summary>
/// Summary description for Class1
/// </summary>
public class bankingContext:DbContext
{
	private readonly IConfiguration _config;
	public bankingContext(DbContextOptions<bankingContext> options, IConfiguration configuration):base(options)
	{
		_config = configuration;
	}

    public async Task CommitAsync()
	{
		await SaveChangesAsync().ConfigureAwait(false);
	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.HasDefaultSchema(_config.GetSection("SchemaName").Value);
		base.OnModelCreating(modelBuilder);
    }

	public DbSet<Client> Clients { get; set; }

    public DbSet<Account> Accounts { get; set; }

    public DbSet<AccountMovement> AccountMovements { get; set; }
}
