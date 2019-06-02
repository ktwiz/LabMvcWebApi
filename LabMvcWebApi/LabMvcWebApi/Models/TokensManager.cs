using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabMvcWebApi.Models
{
    public class TokensManager
    {
        public int TokenID { get; set; }

        public int TokenKey { get; set; }

        public DateTime IssuedOn { get; set; }

        public DateTime? ExpiresOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CompanyCode { get; set; }
    }
}