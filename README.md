# Interlogica.Pastry
Pastry Management simulator


This is an alpha version, lots of features are missing. Here is what's what:

- Database: for semplicity's sake I implemented everything on SQLite databases, both the data db and the security db. This is not ideal.
- BackEnd: written wirh asp.net core 3.1, it can be launched as a console app (Kestrel) and should be working on multiple platforms.
- FrontEnd: the main application uses Razor pages.

The application was developed on Windows 10 with Visual Studio 2019 Community v. 16.8.3

ToDo list:
- To properly implement the ingredient management, right now all the backend and data stuff is there but the frontend is NOT working. Needs to be properly implemented, tested and debugged
- Add unit tests for API and backend methods.
- Support for the managing of spoiled confectionery.
- Add complete user management

