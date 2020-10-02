using System;
using System.Text.Json.Serialization;

namespace Cosmos.DataInteractionFacade.Entities
{
    public class BaseCosmosEntity
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
