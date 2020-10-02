using System;
using System.Text.Json.Serialization;

namespace Cosmos.DataInteractionFacade.Entities
{
    public class BaseCosmosEntity : CosmosMetadata
    {
        [JsonPropertyName("id")]
        public Guid id { get; set; }
    }
}
