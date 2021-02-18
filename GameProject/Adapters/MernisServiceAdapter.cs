using GameProject.Abstract;
using GameProject.Entities;
using MernisServiceReference;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Adapters
{
    public class MernisServiceAdapter : IUserCheckService
    {
        public bool CheckIfRealPerson(string FirstName, string LastName, string NationalityId, string YearOfBirth)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            return client.TCKimlikNoDogrulaAsync(
                new TCKimlikNoDogrulaRequest(
                    new TCKimlikNoDogrulaRequestBody(
                        Convert.ToInt64(NationalityId),
                        FirstName.ToUpper(),
                        LastName.ToUpper(),
                        Convert.ToInt16(YearOfBirth)))).
                    Result.Body.TCKimlikNoDogrulaResult;
        }
    }
}
