namespace exercise_three.Services.Interfaces
{
	public interface IProcessHttp
	{
		public Task<T> ProcessResponse<T>(string data);
	}
}
