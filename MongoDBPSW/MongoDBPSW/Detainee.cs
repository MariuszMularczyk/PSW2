using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBPSW
{
    public class Detainee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("id")]
        public string Id { get; set; }
        [BsonElement("firstName")]
        public string FirstName { get; set; }
        [BsonElement("lastName")]
        public string LastName { get; set; }
        [BsonElement("reasonForTheDetention")]
        public string ReasonForTheDetention { get; set; }

        public override string ToString()
        {
            return Id + " =>" + FirstName + " " + LastName + " Powód zatrzymania: " + ReasonForTheDetention;
        }
    }
}
