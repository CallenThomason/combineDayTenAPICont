# Intro to API's .NET, & Status Codes, HTTP Request Methods

What does API Stand for?

## Application Program Interface

** API allows different applications to communicate with each other **

** Front end -> API -> Data -> API -> Front end. 

## .NET is Microsofts Development Platform

** Dotnet Lets us create Application from Console Projects to Web API to Frontend Website **

## What Is an Endpoint / Route?

An endpoint is a specified location where we send our requests too(ex: localhost5000/user/api/login)

## What is a Controller?

Controllers hold our endpoints and allows applications to send requests to them. 

** Request -> Controller -> C# logic -> request / response is sent back **

## CRUD - Create, Read, Update, and Delete

### Read Method [HttpGet]

Retrieves Data from our API / Database

### Create Method [HttpPost]

Used to *create new Data* (Ex: creating a new account)

### Update Method [HttpPut]

Used to *Update existing data* 

### Delete Method [HttpDelete]

Used to *Delete Existing Data* 

//-------------------------------------------------//

# Status Codes

 ## 200 Status Code 
 
 means your request is good - success
(ok)
 ## 201 Status Code

 This means that creation was successful. 
 (Used for CreateAtAction)

 ## 204 Status Code

 Simply states that the request was successful with nothing to return. 
 (NoContent)

 ## 400 Status Code 
 
 means a bad request - failure
 Something went wrong with the request
(BadRequest)
 ## 404 Status Code

 Not Found means whatever user expected was there, was not there
(NotFound)


 //-------------------------------------//

 ## Day 3 Services, Interfaces, and Dependancy Injection

 # Controller is our waiter - Takes orders (request methods)

 # Interface is our Menu - Tells us what our kitchen has

 # Service is our kitchen - Makes the food (Implements our logic)

 # Dependency Injection is our Manager - Everything runs smoothly (connects everything)

 ### Services

 This layer of our application is where our Logic Resides. (We access our Database from this layer only)

 ### Interface

 This is a contract or list of promises that our services must implement (There is no logic here)

 ### Dependancy Injection

 We inject our services into the controller using our constuctor
 We must add our services and interface to our program.cs
 when we implement our interface it will pass on the responsibility to our services

