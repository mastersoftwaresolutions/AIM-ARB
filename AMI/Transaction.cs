using Authorised.NET.Models;
using AuthorizeNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Authorised.NET.AMI
{
    public class AIMTransaction
    {


        public List<TransactionModel> UnsetteledTransaction(string LoginAPI, string TransactionKey)
        {
            ReportingGateway gate = new ReportingGateway(LoginAPI, TransactionKey);

            var model = new TransactionModel();
            
            //Get all the batches Unsettled
            var batches = gate.GetUnsettledTransactionList();


            //Loop each batch returned 
            var list = new List<TransactionModel>();
            foreach (var item in batches)
            {

                var or = new TransactionModel();
                or.TransactionID = item.TransactionID;
                or.DateSubmitted = item.DateSubmitted;
                or.FirstName = item.FirstName;
                or.LastName = item.LastName;
                or.description = item.Description;
                or.Address = Convert.ToString(item.BillingAddress);
                or.Status = item.Status;
                or.TransactionID = item.TransactionID;
                or.amount = item.SettleAmount;
               
                list.Add(or);

            }
            return list;
        }

        public List<TransactionModel> SetteledTransaction(string LoginAPI, string TransactionKey)
        {

            var model = new TransactionModel();
            ReportingGateway gate = new ReportingGateway(LoginAPI, TransactionKey);
            //Get all the batches Unsettled
            var batches = gate.GetSettledBatchList(true);


            //Loop each batch returned 
            var list = new List<TransactionModel>();
            foreach (var item in batches)
            {
                var or = new TransactionModel();
                or.BatchId = item.ID;
                list.Add(or);
            }

            var data = new List<Transaction>();
           
            foreach (var item in list)
            {
                 data = gate.GetTransactionList(item.BatchId);
            }

            var setteledList = new List<TransactionModel>();
            foreach (var item in data)
            {
                var or = new TransactionModel();
                or.FirstName = item.FirstName;
                or.LastName = item.LastName;
                or.TransactionID = item.TransactionID;
                or.Status = item.Status;
                or.amount = item.SettleAmount;
                or.SetteledOn = item.BatchSettledOn;
                setteledList.Add(or);
            }


            return setteledList;
        }


        public TransactionModel CancelSubscription(string sub_id, string LoginAPI, string TransactionKey)
        {

            var model = new TransactionModel();
            SubscriptionGateway subGate = new SubscriptionGateway(LoginAPI, TransactionKey);
            var response = subGate.CancelSubscription(sub_id);
            model.Response = response;
            return model;
        }

        public TransactionModel Refund(string id, string amount, string LoginAPI, string TransactionKey,string creditcardNuber)
        {
            var model = new TransactionModel();
            //step 1 - create the gateway, sending in your credentials
            var gate = new Gateway(LoginAPI, TransactionKey, true);

            //Step 2 - create the Void Request for the requested TransactionId 
            var Credit = new CardPresentCredit(id);
            Credit.CardNum = creditcardNuber;
            Credit.Amount = amount;
            //Step 3 – Process the transaction with Authorize.Net
            var response = gate.Send(Credit);

            model.Message = response.Message;
            return model;
        }

        public TransactionModel VoidAMI(string id, string LoginAPI, string TransactionKey, string creditcardNuber)
        {
            var model = new TransactionModel();
            //step 1 - create the gateway, sending in your credentials
            var gate = new Gateway(LoginAPI, TransactionKey, true);

            //Step 2 - create the Void Request for the requested TransactionId
            var myVoidRequest = new CardPresentVoid(id);

            myVoidRequest.CardNum = creditcardNuber;

            //Step 3 – Process the transaction with Authorize.Net
            var response = gate.Send(myVoidRequest);
            model.Message = response.Message;
            return model;
          
        }

        public TransactionModel Capture(decimal amount, string transaction_id, string LoginAPI, string TransactionKey)
        {
            var model = new TransactionModel();

            // Step 1 - Create the request
            var request = new PriorAuthCaptureRequest(amount, transaction_id);

            // Step 2 - Create the gateway, sending in your credentials
            var gate1 = new Gateway(LoginAPI,TransactionKey);

            // Step 3 - Send the request to the gateway
            var response = gate1.Send(request);
            model.Message = response.Message;
            return model;

        }

        public TransactionModel CreateOrder(string LoginAPI, string TransactionKey, string cardNumber, string expirationMonthAndYear, decimal amount, string description, string FirstName, string LastName, string Address, string Country)
        {
            var model = new TransactionModel();

            // Step 1 - Create the request
            var request = new AuthorizationRequest(cardNumber,expirationMonthAndYear, 1150.00M,description, false);
            request.FirstName = FirstName;
            request.LastName = LastName;
            request.Address = Address;
            request.Description = description;
            request.Country = Country;


            // Step 2 - Create the gateway, sending in your credentials
            var gate = new Gateway(LoginAPI, TransactionKey);

            // Step 3 - Send the request to the gateway
            var response = gate.Send(request);

            model.Message = Convert.ToString(response.Message);

            return model;
        }
    }

}