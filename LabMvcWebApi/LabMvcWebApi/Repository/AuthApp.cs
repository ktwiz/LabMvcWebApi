using LabMvcWebApi.Models;
using LabMvcWebApi.Models.AES256Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static LabMvcWebApi.Models.AES256Encryption.EncryptionLibrary;

namespace LabMvcWebApi.Repository
{
    public class AuthApp : IAuth
    {
        public int DeleteGenerateToken(string CompanyCode)
        {
            GlobalAppRep.tokenStorage.Remove(GlobalAppRep.tokenStorage.Where(x => x.CompanyCode.Equals(CompanyCode)).SingleOrDefault());
            return 0;
        }

        public string GenerateToken(ClientKey ClientKeys, DateTime IssuedOn)
        {
            try
            {
                string randomnumber =
                   string.Join(":", new string[]
                   {
                        KeyGenerator.GetUniqueKey(12),
                        Convert.ToString(IssuedOn.Ticks),
                        ClientKeys.Company_code,
                        ClientKeys.Client_Id
                   });

                return EncryptionLibrary.EncryptText(randomnumber);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ClientKey GetClientKeysDetailsbyCLientIDandClientSecert(string clientID, string clientSecert)
        {
            return new ClientKey { Client_Id = clientID, Client_Secret = clientSecert };
        }

        public int InsertToken(TokensManager token)
        {
            GlobalAppRep.tokenStorage.Add(token);
            return 0;
        }

        public bool IsTokenAlreadyExists(string CompanyCode)
        {
            return GlobalAppRep.tokenStorage.Where(x => x.CompanyCode.Equals(CompanyCode)).Any();
        }

        public bool ValidateKeys(ClientKey ClientKeys)
        {
            try
            {
                bool r = false;
                r = ClientKeys.Client_Id.Equals(GlobalAppRep.APP_CLIENT_ID) && ClientKeys.Client_Secret.Equals(GlobalAppRep.APP_CLIENT_SECRET);

                return r;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}