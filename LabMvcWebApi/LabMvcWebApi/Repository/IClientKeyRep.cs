using LabMvcWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabMvcWebApi.Repository
{
    public interface IClientKeyRep
    {
        void GenerateUniqueKey(out string ClientID, out string ClientSecret);
        int SaveClientIDandClientSecret(ClientKey ClientKeys);
        int UpdateClientIDandClientSecrect(ClientKey ClientKeys);
        ClientKey GetGenerateUniqueKey();
    }
}
