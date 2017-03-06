# TradingDashboardApp
Displays list of trades with the option to edit price/volume of each trade


EF Code First is used in this project. So to setup the database, you need to run `update-database` command .
I have created Web API project as self host service and independent as it can be used in other projects.
To run the project you need to  run  `TradingDashboad.Web` and `TradingDashboard.WebAPI`. 
`TradingDashboard.Web` MVC project is just a bootstrap for Angular app for now.
Usually `Entities` can be shared across other projects, so i felt the need to separate them in a class library or nuget package later.
