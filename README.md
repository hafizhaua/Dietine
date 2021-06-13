
# Dietine
<em>Last update: 13 June, 2021</em><br><br>
Dietine is an application that will facilitate 
its users to help design and manage the diet program 
they are undergoing. Not only that, this application 
will also assist users in implementing a healthy 
lifestyle with a good diet through the healthy 
food information provided.

## Authors

- [Hafizha Ulinnuha Ahmad](https://github.com/hafizhaua) ( 20/456365/TK/50495 )
- [Hapsari Prabandhari](https://github.com/Hapsarip) ( 20/456366/TK/50496 )
- [Kurnia Dwi Utami](https://github.com/kurniakdu) ( 20/456369/TK/50499 )

## Features

- Meal Planner
- BMR Calculator
- Articles

## Software Installation 

In order to run this application locally, we use:
1. [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
2. [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
  
## Local Run Preparation via Visual Studio 2019

1. Clone the project<br><br>
![image](https://user-images.githubusercontent.com/72615421/121808059-79bdcd80-cc89-11eb-825f-cc68624437ca.png)<br>

2. Update-Database in Package Manager Console<br>
```bash
  PM> Update-Database
```
![image](https://user-images.githubusercontent.com/72615421/121808070-86422600-cc89-11eb-8d8f-a3c9530287d4.png)<br>

3. Compile the project<br><br>
![image](https://user-images.githubusercontent.com/72615421/121808075-893d1680-cc89-11eb-8e1f-085e6674036c.png)<br>

## Error Handling When Preparation
- <em>"A database operation failed while processing the request"</em> when accessing a page<br><br>
![image](https://user-images.githubusercontent.com/72615421/121813382-649f6980-cc9e-11eb-957d-63f05b20b700.png)<br><br>
Solution: Make sure you do the update-database step first before accessing some specific pages. It may occur because the database hasn't existed yet.<br>
- <em>"Database already exists"</em> when updating the database<br><br>
![image](https://user-images.githubusercontent.com/72615421/121808369-b1794500-cc8a-11eb-97c5-c4daa373440d.png)<br><br>
Solution: It seems like because there is still a LocalDB instance running. We can make it stop and delete it via Package Manager Console and finally update the database.
```bash
  PM> sqllocaldb stop
  PM> sqllocaldb delete
  PM> Update-Database
```

## Demo and Documentation

To know the detailed step-by-step instructions on how to use our apps and its features, kindly check:
- [Dokumentasi](https://drive.google.com/file/d/13mlffrRQuRcLDuOLbUaG3V0cEgDDZaHb/view?usp=sharing) (Indonesia)

## Development and Media References
 - [freeCodeCamp](https://www.youtube.com/channel/UC8butISFwT-Wl7EV0hUK0BQ)
 - [Inovatik](https://inovatik.com/)
 - [Fimela](https://www.fimela.com/)
 - etc.
  
  
