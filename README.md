# Infotrack

This project contains a .NET Core WebApi as a backend and a Vue.js SPA as a frontend. It will scrape search engines for a user input search term, and store the results in an SQL Express server. Unfortunately I am unable to bypass Google's cookie window, I tried setting a user-agent header which helped a little. I also tried adding a cookie header as well, but it seems google has changed how they handle the cookie headers in the last year or two, and the information I found is all outdated ('consent'='yes+<cookiecode>' and 'SOCS'='<cookiecode>').

## Frontend

To run the frontend, simply open the infotrack_frontend folder, open a terminal. Run the command "npm install", then "npm run serve".

## Backend

To run the backend, open the solution folder, then select "ScrapeService.Api" and "HistoryService.Api" as startup project. Connection strings can be found in both of those projects, in a file named "appsettings.json". There is also a SQL file in the root of the Git repo for setting up the required table. Once set up, press run. There are also some basic tests under "ScrapeService.Domain.Tests" that can be ran.

---

## Future work if I had more time:

- Create more unit tests for a wider coverage of tests
- Develop a repository pattern for the DB Context, and use mock data for unit tests
- Orchestrate the microservices
