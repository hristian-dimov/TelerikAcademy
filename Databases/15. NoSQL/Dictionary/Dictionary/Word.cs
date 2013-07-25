using MongoDB.Bson;

namespace Dictionary
{
    public class Word
    {
        public Word()
        {
        }

        public Word(string name, string translation)
        {
            this.Name = name;
            this.Translation = translation;
        }

        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Translation { get; set; }
    }
}