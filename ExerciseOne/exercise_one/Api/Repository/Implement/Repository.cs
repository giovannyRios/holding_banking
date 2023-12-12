using Api.Context;
using Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository.Implement
{
	public class Repository : IRepository
	{
		private readonly IConfiguration _configuration;
		public Repository(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public async Task<IEnumerable<T>> GetInformation<T>() where T : class
		{
			var connection = _configuration.GetConnectionString("defaultConnectionString");

			var Builder = new DbContextOptionsBuilder<ExerciseOneContext>();
			Builder.UseSqlServer(connection);

			using (var _dbContext = new ExerciseOneContext(Builder.Options))
			{
				IQueryable<T> query = _dbContext.Set<T>().AsNoTracking();

				return await query.ToListAsync();
			}
		}
	}
}
