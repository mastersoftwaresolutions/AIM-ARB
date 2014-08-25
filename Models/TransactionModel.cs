using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authorised.NET.Models
{
    public class TransactionModel
    {
        public string cardNumber{get;set;}
        public string expirationMonthAndYear{get;set;}
        public decimal amount{get;set;}
        public string description{get;set;}
        public bool includeCapture { get; set; }
        public string Address { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankAccountType { get; set; }
        public string City { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public string TransId { get; set; }
        public string AuthCode { get; set; }
        public string Message { get; set; }
        public bool Response { get; set; }
        public string TransactionID { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string Status { get; set; }
        public string BatchId { get; set; }
        public DateTime SetteledOn { get; set; }
        public int SubscriptionId { get; set; }
      
       
    }

}