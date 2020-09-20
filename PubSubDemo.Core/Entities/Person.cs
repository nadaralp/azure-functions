using System;

namespace PubSubDemo.Core.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime RegisterDare { get; set; }
    }
}
