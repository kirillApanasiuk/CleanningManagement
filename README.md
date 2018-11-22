# Welcome to Quaternity
#### We believe in enhancing the world of energy production, sales and trading by building pioneering software. 

One of our core software solutions shall automate the current way of energy trading. As one part of the components, we need to build service oriented REST APIs allowing 3rd party services/business customers to places their orders. These API-driven systems may implement custom user-oriented logic by the way aggregations of orders are made. As you follow reading the requirements of this exercise, we want to remind you that you're about to work on a real-world scenario, as we want you treat this exercise as such. You shall design your software, design your rest api, write code, commits, tests, comments, treat any database design or functionality you end up using as you would end up doing in ready-to-release software.

As our customer requires, we need to write a REST API with a json content-type, that takes in orders consisting of following attributes:
* They type of commodity (either: power or gas) that this order was placed for.
* The order-volume (quantity) in MWh
* An unique customer identification number, so you shall be able to list orders of a certain customer
* The year of order. i.e. the year in which the order shall be processed

When orders are placed, you should provide response to your API users informing them about:
The order you have accepted, i.e. returning the same order information:
plus:
* current order state
* current order price
* sum of overall order quantities made for the certain customer
* price of overall orders made for the certain customer



As soon as an order has been taken in you should validate them in and provide according response information, also in terms of http status codes, to your api users.

