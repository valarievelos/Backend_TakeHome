# Backend_TakeHome Project

### Description
This API is written in .NET Core. It has a `POST` endpoint that accepts a request for a premium rate. The data that's requried to make a request is **Revenue**, **State**, and **Business**.  A `POST` endpoint will respond with a calculated premium rate. All this data is stored in a local database, which is created upon first `POST` request. A `GET` request returns all previous rate requests. 

## Instructions on Running Rating Engine
* Create local repository of Backend_TakeHome project 
* If using Visual Studio 2019, add a connection in the Server Explorer. Once created, copy the Connection String under Properties and paste it in `Starup.cs` in the function `ConfigureServices` where the variable `connection` is declared. This sets up the local database for the project. 
* Build project and run -- I used Postman for testing
* Send a `POST` with a JSON payload set up as the following
```
  {
    "revenue": double,
    "state": string,
    "business": string 
  }
``` 
* Acceptable strings for `"State"` are **OH**, **FL**, and **TX**
* Acceptable strings for `"Business"` are **Plumber**, **Architect**, and **Programmer**
* `"Revenue"` can be any double
* Any values inputed outside these parameters, will result in a premium of 0
* API should responsd with a JSON payload set up as the following
```
{
  "premium" : double
}
```
* This double represents the calculation that is being done by the API

## Future Versions of Rating Engine
* Give each `POST` response an ID that can be searched and retireved with a `GET`
* Make this API more dynamic and less hard coded so it'd be possible to scale and easier to maintain -- this would be accomplished once I learn more about good design practices for web APIs
* Add more validation with status codes and error messages using `try` and `catch`  

## Notes from the author 
* I learned so much working on this project, but if I had more time I would focus on better design and architecture of the project 
* Hazard factor is hardcoded in `RatesDatabase.cs`
* There are 2 Repositories: `RatesDatabase.cs` and `RateRateRepository.cs`. I used an Interface `IRateRepository.cs` to utilize dependency injection in `Starup.cs` in `ConfigureServices` function. I have it set up this way to help me understand more about web API's since this was the first API I built from scratch. `RateRateRepository.cs` is pulling data that is in line memory, but for the sake of this project, it's set up to use `RatesDatabase.cs` which uses a database.



