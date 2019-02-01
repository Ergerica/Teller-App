# Teller-App
Desktop application to be used by the teller employees on a physical bank.

It was created using Windows Form/C#, as the project for the programming course at the Instituto Tecnológico de Santo Domingo.

<b>Description</b>

The user can perform transactions such as withdrawal and deposit. Each transaction will be stored on a local database, and there will also 
be a tracking of how many bills of each quantity has the actual cash register.

For verifying each transaction, the App does a request to the "Integrador"(unifier), a web-based app in charge of doing the requests to the
bank's core system. The local app will request several objects such as Clients and Accounts, making verifications like checking the 
amount of the desired withdrawal is less than the Account's balance. After doing all verifications the App will tell the 'unifier'(Sending a
transaction object), the information of the transaction so that it can be stored on the core system.

During each withdrawal, the app recommends though a greedy algorithm the employee how many bills of each quantity he/she should give to the client.

<b>Connections and databases</b>

The local database for the cash tracking, transaction storage and local employees were managed using SQL server through Sqlconnection and 
Sqlcommand classes.

The connections between the local app and the 'unifier' were made by consuming the SOAP web services by the 'unifier'.


