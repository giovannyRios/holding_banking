namespace Api.Repository.Interface
{
	public interface IRepository
	{
		Task<IEnumerable<T>> GetInformation<T>() where T : class;
	}
}
