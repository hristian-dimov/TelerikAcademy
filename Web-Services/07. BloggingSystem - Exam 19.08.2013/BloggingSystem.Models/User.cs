using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BloggingSystem.Models
{
    public class User
    {
        public User()
        {
            this.Posts = new HashSet<Post>();
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(6), MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MinLength(6), MaxLength(30)]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(40)]
        public string AuthCode { get; set; }

        [StringLength(50)]
        public string SessionKey { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
