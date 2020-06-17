# API-RandomPersonGen
This is a .net Core 3.1 application that provides an API to generate random users.
The application is built upon TDD apporach and NSubstitute is used to Mock the actual database for testing purposes.
The database and the application are hosted on Azure. Hence you can directly access the links below without any initial setup.

The various EndPoints provided by the API are as follows
# GET: https://celointerview.azurewebsites.net/api/Users
This endpoint provides a list of all the available users.
# GET: https://celointerview.azurewebsites.net/api/Users/{quantity}
This endpoint generates a random list of users based upon the quantity parameter provided.
# GET: https://celointerview.azurewebsites.net/api/Users/{first or last name}
This endpoint fetches the specific user or users based upon the first or last name provided.
# GET: https://celointerview.azurewebsites.net/api/Users/id/{id}
This endpoint fetches a specific user based upon the id provided.
# PUT: https://celointerview.azurewebsites.net/api/Users/{id}
This endpoint updates the details of the user with the mentioned id parameter  with the values specified in the body section.
# DELETE: https://celointerview.azurewebsites.net/api/Users/{id}
This endpoint deletes the user based upon the userId mentioned.
# POST: https://celointerview.azurewebsites.net/api/Users/
This endpoint will insert a new user based upon the values passed in the body section.The arguments to be passed in the body section invlove Title, FirstName, LastName, PhoneNumber, EmailId, DateOfBirth[Format("YYYY-MM-DDT00:00:00")], ProfileImages (this is a byte[], make sure to pass a byte[] object or ignore as this is optional).
