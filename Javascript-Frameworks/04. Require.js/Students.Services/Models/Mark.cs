using System;
using System.Runtime.Serialization;

namespace Students.Services.Models
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
