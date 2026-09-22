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

 ## 400 Status Code 
 
 means a bad request - failure
 Something went wrong with the request