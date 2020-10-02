using System;
using System.Text.Json.Serialization;

namespace Cosmos.DataInteractionFacade.Entities
{
    public class CosmosMetadata
    {
        public string _rid { get; set; }
        public string _self { get; set; }
        public string _etag { get; set; }
        public string _attachments { get; set; }
        public long _ts { get; set; }
        public DateTime _tsDateTime

        {
            get
            {
                //Unix timestamp is seconds past epoch
                DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(_ts).ToLocalTime();
                return dtDateTime;
            }
        }

    }
}
