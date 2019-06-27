using LabMvcWebApi.Models;
using LabMvcWebApi.Models.AES256Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabMvcWebApi.Repository
{
    public class ClientKeyAppRep : IClientKeyRep
    {

        public void GenerateUniqueKey(out string ClientID, out string ClientSecret)
        {
            ClientID = EncryptionLibrary.KeyGenerator.GetUniqueKey(15);
            ClientSecret = EncryptionLibrary.KeyGenerator.GetUniqueKey(15);
        }

        public ClientKey GetGenerateUniqueKey()
        {
            return new ClientKey { Client_Id = GlobalAppRep.APP_CLIENT_ID, Client_Secret = GlobalAppRep.APP_CLIENT_SECRET };
        }

        public int SaveClientIDandClientSecret(ClientKey ClientKeys)
        {
            GlobalAppRep.APP_CLIENT_ID = ClientKeys.Client_Id;
            GlobalAppRep.APP_CLIENT_SECRET = ClientKeys.Client_Secret;

            return 0;
        }

        public int UpdateClientIDandClientSecrect(ClientKey ClientKeys)
        {
            GlobalAppRep.APP_CLIENT_ID = ClientKeys.Client_Id;
            GlobalAppRep.APP_CLIENT_SECRET = ClientKeys.Client_Secret;

            return 0;
        }
    }
}