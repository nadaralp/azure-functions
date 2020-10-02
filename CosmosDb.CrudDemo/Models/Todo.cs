using Cosmos.DataInteractionFacade.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CosmosDb.CrudDemo.Models
{
    public class Todo : BaseCosmosEntity
    {
        [JsonPropertyName("todo_name")]
        public string TodoName { get; set; }


        [JsonPropertyName("description")]
        public string Description { get; set; }


        [JsonPropertyName("is_done")]
        public bool Test { get; set; }
    }
}
