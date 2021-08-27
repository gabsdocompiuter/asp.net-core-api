﻿using System.ComponentModel.DataAnnotations;

namespace RestApi.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title {  get; set; }
        public string Description {  get; set; }
        public string Author {  get; set; }
    }
}
