using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeContentCatalog
{
    public class ContentItem : IComparable, IContent
    {
        private string url;

        public ContentItem(ContentType type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)ContentDetails.Title];
            this.Author = commandParams[(int)ContentDetails.Author];
            this.Size = long.Parse(commandParams[(int)ContentDetails.Size]);
            this.URL = commandParams[(int)ContentDetails.Url];
        }

        public ContentType Type { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public long Size { get; set; }

        public string URL
        {
            get
            {
                return this.url;
            }

            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString(); // To update the text representation
            }
        }

        public string TextRepresentation { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            ContentItem otherContent = obj as ContentItem;
            if (otherContent != null)
            {
                int comparisonResult = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);

                return comparisonResult;
            }

            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            string output = string.Format("{0}: {1}; {2}; {3}; {4}", this.Type.ToString(), this.Title, this.Author, this.Size, this.URL);

            return output;
        }
    }
}
