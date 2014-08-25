 AuthorizeNet & ARB
         AuthorizedNet is AIM means Advance Integration Method. AIM is used for online transaction but with authorized way. It means Admin need to authorized the amount or order submitted by end-user.
After authorization it will go for Capture. Once amount will be captured by Admin that means it is queued for Unsettled Transaction. After some hour it will process automatically for settled Transaction.
 Authorized: it means amount is Approved by Admin or Merchant
 Capture : it means amount is deducted from buyer account
 Unsettled  : it means amount is not yet deposited to Merchant account
 Settled :  it means account is deposited to Merchant account. This is the final process for Transaction    

What is ARB??
          ARB means Automatic Recurring Billing. ARB is used for subscription .ARB can be created monthly , yearly ,  half yearly    etc. Once ARB is created Amount will be deducted from buyer account as according to set  ARB details . It will continue until it is canceled by Merchant or Admin.                                                                              
How To Work with AIM ARB C#?

   1) First of all you need to Add reference of AuthorizeNet.
   2) Add reference of  AIM DLL
      (Download AIM.DLL file)
   
**Now access all Classes of AIM ARB according to your needs***

1) To create Order by customer
   
   #1>> create object of AIMTransaction class
   #2>> Invoke CreateOrder method
   #3>> pass following parameters

Data Type	Parameter
string	 LoginAPI (get it from your Authorized.net account)
string	TransactionKey (get it from your Authorized.net account)

string	cardNumber (credit card number)

string
	expirationMonthAndYear
decimal
	amount
string
	description
string
	FirstName
string
	LastName
string
	Address
string
	Country
      #4>> It will return a message suucess/error

2) To get list of Unsetteled Transaction
    
    #1>> Invoke UnsetteledTransaction
    #2>> pass following parameters
     
    
Data Type	Parameter
string

	 LoginAPI (get it from your Authorized.net account)
string	TransactionKey (get it from your Authorized.net account)

   #3>> It will return you Unsetteled Transaction list


3) To get list of Setteled Transaction
    
    #1>> Invoke SetteledTransaction
    #2>> pass following parameters
     
     
Data Type	Parameter
string

	 LoginAPI (get it from your Authorized.net account)
string	TransactionKey (get it from your Authorized.net account)

   #3>> It will return you Setteled Transaction list

4) Create Subscription or ARB
    
   #1>> create object of ARB class
   #2>> Invoke createSubscription method
   #3>> pass following parameters

Data Type	Parameter
string

	 LoginAPI (get it from your Authorized.net account)
string	TransactionKey (get it from your Authorized.net account)

string	transaction_id

string
	BuyerEmailId
string
	CardNumber
short
	BillingInterval
int
	CardExpirationMonth
int
	CardExpirationYear
string
	InvoiceNumber
DateTime
	 StartsOn (start date)
string
	StreetAddress
decimal
	amount
short
	numberOfBillings
   #4>> It will return you Subscription ID ,save it in DB because require while cancel subscription

4) Cancel Subscription or ARB
    
   #1>> create object of AIMTransaction class
   #2>> Invoke CancelSubscription method
   #3>> pass following parameters

Data Type	Parameter
string

	 LoginAPI (get it from your Authorized.net account)
string	TransactionKey (get it from your Authorized.net account)

string	 sub_id
  #4>> It will return you message success/error


5) Refund Amount to User
   
      #1>> create object of AIMTransaction class
      #2>> Invoke Refund method
      #3>> pass following parameters

Data Type	Parameter
string

	 LoginAPI (get it from your Authorized.net account)
string	TransactionKey (get it from your Authorized.net account)

string
	   id (id here is transaction Id)
decimal
	amount
string
	creditcardNuber
      #4>> It will return you message success/error


6) Capture Amount by Admin
   
      #1>> create object of AIMTransaction class
      #2>> Invoke Capture method
      #3>> pass following parameters

Data Type	Parameter
string

	 LoginAPI (get it from your Authorized.net account)
string	TransactionKey (get it from your Authorized.net account)

string
	   transaction_id
decimal
	amount
      #4>> It will return you message success/error

6) Void Amount by Admin
    
      #1>> create object of AIMTransaction class
      #2>> Invoke VoidAMI method
      #3>> pass following parameters
Data Type	Parameter
string

	 LoginAPI (get it from your Authorized.net account)
string	TransactionKey (get it from your Authorized.net account)

string
	  id (id here as Transaction Id)

decimal
	creditcardNuber
      
      #4>> It will return you message success/error