using LabMvcWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabMvcWebApi.Repository
{
    public interface IAuth
    {
        ClientKey GetClientKeysDetailsbyCLientIDandClientSecert(string clientID, string clientSecret);
        bool ValidateKeys(ClientKey ClientKeys);
        bool IsTokenAlreadyExists(string CompanyCode);
        int DeleteGenerateToken(string CompanyCode);
        int InsertToken(TokensManager token);
        string GenerateToken(ClientKey ClientKeys, DateTime IssuedOn);
    }
}
