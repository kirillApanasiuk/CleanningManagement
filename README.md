# Welcome to Quaternity
#### Our vision is to enable consumers to satisfy their energy needs consciously, transparently and easily through technology.

## Introduction
One of our core software products aims to automate the current way energy is being traded. 
We build service oriented REST APIs which allow 3rd party services and business customers to place energy orders. 

Those API-driven solutions do implement a custom logic to aggregates orders and calculate their price.

As you continue reading the requirements of this exercise, we like to point out that you're confronted with a real-world scenario, as such we want you to treat this exercise as one.

I.e.: you shall design your software, design your rest api, write code, commits, tests, comments, treat any database design or functionality you end up using as you would do in your job.

## Order information
As stated above, we need to develop a REST API that is able to receive orders, which do consist of following attributes:
* Type of commodity. Either power or gas
* Order volume (i.e. quantity) in MWh. Minimum amount of order is 50 MWh per anno.
* Order type. Either fixed-price or special-price.
* An unique customer identification number, so you shall be able to list orders of a certain customer.
* The year of order. i.e. the year in which the ordered energy shall be delivered. Must not be greater than 10 years from now.

_(Any customer information beyond the identification number is not part of this exercise, you can assume that an API for managing customers already exists and all you need to consider in the order system is the customer Id.)_

When orders are placed. The API should provide a response to your API users informing them about:
* The order you have accepted, i.e. returning the same order information that was provided

__plus:__

* created order Id
* current order state
* order price
* sum of overall order quantities made for the certain customer
* total price of all orders made for the certain customer

## Order types:
* ### Fixed price:
  * Orders of type "fixed" do always provide the same type of quoting using a static price per MWh, € / MWh
  * Where € / MWh equals 1.30 €
 
* ### Special price:
  * prices of orders with order type "special" are being calculated the same way as fixed order types, with following differences:
  * The price of all orders up to the total amount of 500MWh is: 1.50 € / MWh
  * Every 500th MWh ordered at the special price, a customer receives 3 percent discount. 
  * In total a customer can only receive a discount up to 27 %.

## Order states
* ### Orders can end up in following three states
  * **Accepted**: Everything went on fine
  * **Waiting For Approval**: As soon as a customer orders more than 10'000 MWh, certain approvals are required. (Fetching those approvals is not part of this exercise)
  * **Failed**: E.g.: When the amount of an order is below 50 MWh.
  
## Endpoints
In summary you shall design and write a REST API, which has at least following endpoints:
* Endpoint for adding an order to a certain customer
* Endpoint that lists all orders of certain customer
* Endpoint that allows to delete a certain order
  * Only orders with order state 'failed' can be deleted

