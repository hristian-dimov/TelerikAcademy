using System;
using System.Runtime.Serialization;

namespace _02.Students.Services.Models
{
    [DataContract]
    public class Mark
    {
        [DataMember(Name="subject")]
        public string Subject { get; set; }

        [DataMember(Name = "score")]
        public decimal Score { get; set; }
    }
}
