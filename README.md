# Welcome to Quaternity
#### We believe in enhancing the world of energy production, sales and trading by building pioneering software. 

One of our core software solutions shall automate the current way of energy trading. As one part of the components, we need to build service oriented REST APIs allowing 3rd party services/business customers to places their orders. These API-driven systems may implement custom user-oriented logic by the way aggregations of orders are made. As you follow reading the requirements of this exercise, we want to remind you that you're about to work on real-world scenarios, as we want you treat this exercise as such. You shall design your software, design your rest api, write code, commits, tests, comments, treat any database design or functionality you end up using as you would end up doing in ready-to-release software.

As the requirements are stated, we need to write a REST API, that takes in orders consisting of following attributes:
* They type of commodity (either: power or gas) that this order was placed for.
* The order-volume (quantity) in MWh, the minimal amount of order is 50 MWh.
* The order-type (either: fixed or special-priced)
* An unique customer identification number, so you shall be able to list orders of a certain customer
* The year of order. i.e. the year in which the order shall be processed

When orders are placed, you should provide response to your API users informing them about:
The order you have accepted, i.e. returning the same order information:
plus:
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
* There are three order states
  * Accepted: Everything went on fine
  * Waiting For Approval: As soon as a customer orders more than 10'000 MWh, certain approvals are required. (Fetching those approvals are not part of this exercie)
  * Failed: E.g.: When the amount of order is below 50 MWh.
 
