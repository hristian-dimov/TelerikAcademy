using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Dictionary
{
    class MongoDictionary
    {
        private MongoCollection<Word> dictionary;

        public MongoDictionary(MongoCollection<Word> collection)
        {
            this.dictionary = collection;
        }

        public void AddWord(string name, string translation)
        {
            Word word = new Word(name, translation);
            dictionary.Insert(word);
        }

        public MongoCursor<Dictionary.Word> GetAllWords()
        {
            var allWords = dictionary.FindAll();

            return allWords;
        }

        public Word FindWordByName(string wordName)
        {
            var query = Query<Word>.EQ(w => w.Name, wordName);
            var word = dictionary.FindOne(query);

            return word;
        }
    }
}
