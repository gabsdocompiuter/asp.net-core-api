using System.ComponentModel.DataAnnotations;

namespace RestApi.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
