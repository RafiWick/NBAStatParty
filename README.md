**NBAStatParty**
**Overview**: NBAStatParty is an ASP.Net Core web application that takes data from the sportradar trial API and displays it to the user in a visualy appealing and easy to navigate manner.

<details><summary>Screen Shots</summary>
  
</details>

<details><summary>Wire Frames</summary>
  <img width="500" height=250 alt="image src="https://github.com/RafiWick/NBAStatParty/assets/130600943/815242f6-f79b-4f5b-9f6f-5acb20fa74e0">

</details>

## Getting Started

### Prerequisites
* [pgAdmin](https://www.pgadmin.org/)
* [Visual Studio](https://visualstudio.microsoft.com/)

### Set up
1. Make a clone of this repo and open it in Visual Studio.
2. In either appsettings.json in the project or in your user sercret folder add:
   ```
   {
   "NBAStatPartyDBCONNECTIONSTRING": "Server=localhost;Database=NBAStatParty;Port=5432;Username=YOURPGADMINUSERNAME;Password=YOURPGADMINPASSWORD",
   }
   ```
3. In your users secret folder add:
   ```
   {
   "NBA_SPORTRADAR_APIKEY": "YOUR_SPORTRADAR_NBA_API_KEY",
   "WNBA_SPORTRADAR_APIKEY": "YOUR_SPORTRADAR_WNBA_API_KEY"
   }
   ```
4. In visual studio naviagate to tools -> NuGet package manager -> Package Manager Console -> run update-database in the package manager console.
      
5. The first time you run NBAStatParty it will take a while to start up because it needs to run ~50 API calls with the trial rate limitation of one call per one second.
6. Once loaded you can begin exploring the world of basketball statistics.

## Context
Level up is solo school project ideated, designed, and developed in 8 days by
| <img src="https://github.com/RafiWick.png?"> |
| :----: |
| Rafi Wick |
|<a href="https://www.linkedin.com/in/raphael-wick-285489197/"><img src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white"></img></a><a href="https://github.com/RafiWick"><img src="https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white"></img></a>|
