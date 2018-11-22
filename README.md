# Welcome to Quaternity
#### Our vision is to enable consumers to satisfy their energy needs consciously, transparently and easily through technology.

One of our core software products automates the current way of energy trading. 
We build service oriented REST APIs allowing 3rd party services and business customers  place their orders. 

Those API-driven solutions, do implement custom user-oriented logic by the way aggregations of orders are made and their price is calculated.

As you continue reading the requirements of this exercise, we want to point out, that you're confronted with a real-world scenario, as such we want you to treat this exercise as one. 

I.e.: You shall design your software, design your rest api, write code, commits, tests, comments, treat any database design or functionality you end up using as you would end up doing in ready-to-release software.

As requirements are stated, we need to develop a REST API, that is able to receive order which consist of following attributes:
* Type of commodity. Either: power or gas
* Order volume (quantity) in MWh. Minimum amount of order is 50 MWh per anno.
* Order type. Either: fixed or special-priced.
* An unique customer identification number, so you shall be able to list orders of a certain customer
* The year of order. i.e. the year in which the order shall be processed. Must not be greater than 10 years from now.

When orders are placed. The API should provide response to your API users informing them about:
The order you have accepted, i.e. returning the same order information,
plus:
* the new created order Id
* current order state
* current order price
* sum of overall order quantities made for the certain customer
* price of overall orders made for the certain customer

In terms of pricing:
* Fixed order types:
  * Orders of type fixed, do always provide the same type of quoting using a static price per MWh
  * MWh x €
  * Where the € / MWh equals 1.30 €
 
* Special priced orders:
  * price of certain orders are being calculated the same way as fixed order types, with following differences:
  * The price of all orders up to the total amount of 500MWh is about: 1.50 € / MWh
  * Every 500th MWh ordered, a customer receives 3 percent discount. 
  * In total a customer can only receive a discount up to 27 %.

Order states:
* There are 3 order states
  * Accepted: Everything went on fine
  * Waiting For Approval: As soon as a customer orders more than 10'000 MWh, certain approvals are required. (Fetching those approvals are not part of this exercie)
  * Failed: E.g.: When the amount of order is below 50 MWh.
  
  
In summary you shall design and write a REST API, which has at least following endpoints:
* Endpoint for adding an order to a certain customer
* Endpoint that lists all orders of certain customer
* Endpoint that allows you delete a certain order
  * Only orders with order state 'failed' can be deleted

