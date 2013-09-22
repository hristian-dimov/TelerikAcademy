using System;

namespace BloggingSystem.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime PostDate { get; set; }

        public virtual User CommentedBy { get; set; }

        public virtual Post Post { get; set; }
    }
}
