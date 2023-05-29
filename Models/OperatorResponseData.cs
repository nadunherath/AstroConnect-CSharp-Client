using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroConnectCSharpClient.Models
{
    public class OperatorResponseData
    {
        //"id": 0,
        //"name": "string",
        //"locationId": 0,
        //"displayName": "string",
        //"state": "string",
        //"city": "string",
        //"address1": "string",
        //"address2": "string",
        //"positionLat": 0,
        //"positionLng": 0,
        //"isInactive": true,
        //"maxRegionLevel": 0,
        //"level1Name": "string",
        //"level2Name": "string",
        //"level3Name": "string"

        public int Id { get; set; }

        public string Name { get; set; }

        public string LocationId { get; set; }

        public string DisplayName { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string PositionLat { get; set; }

        public string PositionLng { get; set; }

        public bool IsInactive { get; set; }

        public bool MaxRegionLevel { get; set; }

        public string Level1Name { get; set; }

        public string Level2Name { get; set; }

        public string Level3Name { get; set; }
    }
}
