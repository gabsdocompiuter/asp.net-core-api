using System.Text.Json.Serialization;

namespace RestApi.ValueObjects
{
    public class PersonVO
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
