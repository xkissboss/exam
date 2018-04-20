using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;

namespace Exam.Models
{
    public class IQEntity : BaseEntity
    {

        public IQEntity()
        {
            OptionList = new List<IQOption>();
        }

        [BsonElement("我是中文")]
        public string Context { get; set; }

        public List<IQOption> OptionList { get; set; }

        public int IType { get; set; }
    }


    public class IQOption : BaseEntity
    {

        public IQOption()
        {
            Id = ObjectId.GenerateNewId();
        }

        public string Context { get; set; }
    }

}
