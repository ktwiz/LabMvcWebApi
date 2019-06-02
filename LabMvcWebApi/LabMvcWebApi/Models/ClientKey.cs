using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabMvcWebApi.Models
{
    public class ClientKey
    {
        public int ClientKeyId { get; set; }

        public string Client_Id { get; set; }

        public string Client_Secret { get; set; }

        public string Company_code { get; set; }
    }
}