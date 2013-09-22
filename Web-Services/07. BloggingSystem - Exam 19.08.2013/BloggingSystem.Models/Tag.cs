using System;
using System.Collections.Generic;

namespace BloggingSystem.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Text { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
