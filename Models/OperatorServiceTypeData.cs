using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace AstroConnectCSharpClient.Models
{
    public class OperatorServiceTypeData
    {
            //"id": 0,
            //"supplierServiceOperatorId": 0,
            //"description": "string",
            //"serviceType": 0,
            //"isInactive": true

            public int Id { get; set; }

            public int SupplierServiceOperatorId { get; set; }

            public string Description { get; set; }

            public int ServiceType { get; set; }

            public bool IsInactive { get; set; }
    }
}
