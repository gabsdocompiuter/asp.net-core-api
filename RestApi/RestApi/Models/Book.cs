using System.ComponentModel.DataAnnotations;

namespace RestApi.Models
{
    public class Book : BaseEntity
    {
        public string Title {  get; set; }
        public string Description {  get; set; }
        public string Author {  get; set; }
    }
}
