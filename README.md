# SalesForecastingApp
Implement a basic Sales forecasting application.
Tools
 SQL Server / or any other relational database to store the historical data set and the
forecasted data.
 VB.NET or C# as a programming language.
 Any .net front end framework
o Console app is valid.
o Bonus exercise contains charts so we recommend:
 WinForms .net 4.7.2
 WPF with Interactive Data Display for WPF
 ASP.NET Web pages Razor

Deliverable
The project needs to be saved in a public source control repository (ex. GitHub). Once you
have finished the project you should send us a repository link that we can be cloned.
The repository needs to contain the next items.
1. The Sales Forecasting Application
2. All the scripts related to the DB (Creation scripts for the tables, USP…)
a. If the you have any inline queries in the code, please don’t include them.
3. A Readme.md file explaining the tech selected for the project, how to run it and any
other caveat of your project
Dataset
The dataset is an excel that contains three tables (Orders, Products, Returns) you should
have received the excel attached in the same email that you have received this exercise.
Import these tables into a SQL DB of your choice as they are the base of the exercise. If you
use an import tool like “SQL Management”, please normalize the tables and provide the
scripts of the tables.

App Requirements
The customer Superstore wants to perform a Proof of Concept or prototype for a forecasting
tool that eventually will send the data to their Financial Planning tool. For this prototype,
Superstore sent their historical data from 2018 to 2021 with all the metrics and dimensions
used on the business process.
You will need to populate the Forecast scenario (this is called seeding) copying the sales
Actual data from an N year as a starting point.
User stories

1. As a user I should be able to query for the sales of a specific year and display the
value of the sales of the selected year in the screen.
Total sales and a breakdown (list) of the total sales by State. (Orders.State)
Sales DB field = Products.Sales
Calculation
Total Sales = Year Sales – Year Returns

2. As a user I should be able to apply a percentage of increment to the total sales of the
selected year, to simulate the increase of sales in the next year.
Display the increment number of Sales after applying the percentage.
Display the increment by state in a column after the actual value.
Bonus: Apply individual percentages of increase per state.
If you need to populate a “State” dropdown, use the Orders.State.
3. As a user I should be able to download the forecasted data to a csv, with the next
columns
State, Percentage increase, Sales value.

Bonus stories
1. As a user I should be able to see the aggregated Seeding year sales (Selected year)
and the forecasted year sales in a chart.
2. As a user I should be able to see the breakdown by state of the Seeding year sales
(Selected year) and the forecasted year sales in a chart.

Details
 The solution could be shown using the console, however, it will be highly
recommended to put an additional effort on the user interface.
 The developer should explain their choices around this solution.
 Don&#39;t worry about handling any exceptions or invalid commands. Assume that the
user will always type the correct commands. Just focus on the sunny day scenarios.
 Don’t bother making it work over a network or across processes. It can all be done in
the developer laptop.
 IMPORTANT: Focus on writing the best code you can produce. Do not rush. Take as
much time as you need: there is not a strict deadline.
