using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Students.Services.Models
{
    [DataContract]
    public class Student
    {
        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "marks")]
        public IEnumerable<Mark> Marks { get; set; }
    }
}