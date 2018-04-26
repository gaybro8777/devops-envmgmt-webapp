using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DBDevOps.Models
{
    public class Value
    {
        public string value { get; set; }
        public string ReferenceValue { get; set; }
    }

    public class Field
    {
        public string Name { get; set; }
        public IList<Value> values { get; set; }
    }

    public class Entity
    {
        public IList<Field> Fields { get; set; }
        public string Type { get; set; }

        [JsonProperty(PropertyName = "children-count")]
        public int children_count { get; set; }
    }

    public class RootObject
    {
        public IList<Entity> entities { get; set; }
        public int TotalResults { get; set; }
    }
}
