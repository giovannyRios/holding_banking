using System.Text.Json.Serialization;

namespace exercise_three.Models
{
	public class CurrencyHistory
	{
		[JsonPropertyName("success")]
		public bool Success { get; set; }
		[JsonPropertyName("timestamp")]
		public long Timestamp { get; set; }
		[JsonPropertyName("historical")]
		public bool Historical { get; set; }
		[JsonPropertyName("base")]
		public string Base { get; set; }
		[JsonPropertyName("date")]
		public DateTime Date { get; set; }
		[JsonPropertyName("rates")]
		public Dictionary<string, double> Rates { get; set; }
	}
}
