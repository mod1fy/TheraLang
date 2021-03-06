﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;


namespace TheraLang.DLL.Models
{
    public class LiqPayHelper
    {
        static private readonly string _privateKey;
        static private readonly string _publicKey;
        private const int ApiVersion = 3;
        

        static LiqPayHelper()
        {
            _publicKey = "sandbox_i42859998914";
            _privateKey = "sandbox_nqmktFe8ozPyPOGdjck7HgIfXp14kr0vcBF0RHhY"; //TODO: set via env variables
        }

        static public LiqPayCheckoutModel GetLiqPayCheckoutModel(string donationAmount, int? projectId, HttpContext context)
        {
            string donationId = Guid.NewGuid().ToString();
            var hostName = $"{context.Request.Scheme}://{context.Request.Host}";
            LiqPayCheckout dataSource = new LiqPayCheckout()
            {
                PublicKey = _publicKey,
                Version = ApiVersion,
                Action = "pay",
                Amount = Convert.ToDecimal(donationAmount),
                Currency = "UAH",
                Description = "Благодійність",
                ResultUrl = $"{hostName}/transaction/{donationId}",
                ServerUrl = $"{hostName}/api/donations/{donationId}/{projectId}",
                Language = "uk"
            };


            string jsonString = JsonConvert.SerializeObject(dataSource);
            string data = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonString));
            string signature = GetLiqPaySignature(data);

            LiqPayCheckoutModel checkoutModel = new LiqPayCheckoutModel()
            {
                Data = data,
                Signature = signature,
            };
          
            return checkoutModel;
        }

        static public string GetLiqPaySignature(string data)
        {
            return Convert.ToBase64String(SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(_privateKey + data + _privateKey)));
        }
    }
}
