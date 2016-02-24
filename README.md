# InstaSport

InstaSport is a helpful application for organizing games in various sports. It is built using ASP.NET MVC as a part of [Telerik Academy](http://www.telerik.com/company/telerik-academy)'s ASP.NET MVC course.
A working version of the application can be found at http://instasport.azurewebsites.net.

## Pages

### Home
The homepage presents a jumbotron as well as some cached data regarding the number of sports, games and locations.

### Games
Users can select upcoming games, games by a given sport and games in a given city from the Games submenu. Doing so will show all games in the selected category, provided that the games are not finished. Registered users can join any game they like. A progress bar shows the percentage of gathered players.

### Sports
A list of all the sports available, cached every 30 minutes. Clicking on a sport displays all the games available for that sport.

### Locations
The locations page shows detailed information for a location, such as the list of sports available to play and the city of the location. Registered users can give ratings for the location.

### Cities
A list of all the cities available, cached every 30 minutes. Clicking on a city displays all the games available in that city.

### Administration
Users with the role of "Administrator" can manage games, locations, sports and cities. An administrator can change the name of a city, sport or location, change the number of players in a game or its location as well as change the city of a location. All data is presented in the form of a grid that allows filtering and sorting.