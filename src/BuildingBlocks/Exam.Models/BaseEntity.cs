using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Models
{
    public abstract class BaseEntity<TprimaryKey>
    {
        public virtual TprimaryKey Id { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual bool IsDeleted { get; set; }

        public BaseEntity()
        {
            CreationTime = DateTime.Now;
            IsDeleted = false;
        }
    }

    public abstract class BaseEntity: BaseEntity<ObjectId>
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        //[BsonElement("_id")]
        //[BsonId(IdGenerator = typeof(CombGuidGenerator))]
        public override ObjectId Id { get; set; }
    }
}
