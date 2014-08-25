using Authorised.NET.Models;
using AuthorizeNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Authorised.NET.AMI
{
    public class ARB
    {
        AIMTransaction AIMobj = new AIMTransaction();
        public TransactionModel createSubscription(string transaction_id, string LoginAPI, string TransactionKey, string BuyerEmailId, string CardNumber, short BillingInterval, int CardExpirationMonth, int CardExpirationYear, string InvoiceNumber, DateTime StartsOn, string StreetAddress,decimal amount,short numberOfBillings)
        {
            var model = new TransactionModel();
            var data = AIMobj.UnsetteledTransaction(LoginAPI,TransactionKey).Where(p => p.TransactionID == transaction_id).First();


            SubscriptionGateway subGate = new SubscriptionGateway(LoginAPI,TransactionKey);

            var ARB = SubscriptionRequest.CreateMonthly(BuyerEmailId, data.FirstName, amount, numberOfBillings);


            ARB.CardNumber = CardNumber;
            ARB.BillingInterval = BillingInterval;
            ARB.CardExpirationMonth = CardExpirationMonth;
            ARB.CardExpirationYear = CardExpirationYear;
            ARB.SubscriptionName = data.FirstName;
            ARB.Invoice = InvoiceNumber;
            ARB.StartsOn = StartsOn;


            var addr = new Address();
            addr.First = data.FirstName;
            addr.Last = data.LastName;
            addr.Street = StreetAddress;
            ARB.BillingAddress = addr;

            var responseARB = subGate.CreateSubscription(ARB);

            model.SubscriptionId =Convert.ToInt16(responseARB.SubscriptionID);

            return model;
        }
    }
}