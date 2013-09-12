
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsStore
{
    public class Producer
    {
        public Producer()
        {
            this.Models = new List<string>();
        }

        public string Name { get; set; }
        public ICollection<string> Models { get; set; }

    }
}