using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Consts
    {
        // <== Administrative strings ==>

        public const string BaseUrl = "http://195.222.75.252:8080/api/";
        public const string ContentTypeJson = "application/json";
        public const string ContentTypeUrlencoded = "application/x-www-form-urlencoded";

        // <== Keywords ==>

        public const string ContentType = "Content-Type";
        public const string Auth = "Authorization";
        public const string TypeOfToken = "Bearer {0}";
        public const string GrantType = "grant_type";
        public const string Password = "password";
        public const string Username = "username";
        public const string Login = "Login"; 
        public const string ConfirmPassword = "ConfirmPassword";
        public const string RequestSeparartor = "/";

        // <== Request End Points ==>
        public const string LoginEndPoint = "account/login";
        public const string RegistrationEndPoint = "account/register";
        public const string CommonStatisticsEndPoint = "commonstatistic";
        public const string WalletsEndPoint = "wallets";
        public const string CurrencyEndPoint = "currency";
        public const string StorageTypesEndPoint = "storagetype";
        public const string IncomeNotesEndPoint = "incomenote";
        public const string CostsEndPoint = "cost";
    }
}
