using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace RestApi.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [Column("Password")]
        public virtual string PasswordStored { get; set; }

        [NotMapped]
        public string Password
        {
            get => PasswordStored;
            set => PasswordStored = Encrypt(value);
        }

        private static string Encrypt(string password)
        {
            SHA256Managed sha = new();
            byte[] hashByte = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

            string hash = string.Empty;

            foreach (byte b in hashByte)
            {
                hash += $"{b:x2}";
            }

            return hash;
        }
    }
}
