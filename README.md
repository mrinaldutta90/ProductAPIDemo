# ProductAPIDemo


Instructions to Run This API.

1. Clone the repo onto the local machine
2. Build the Solution using Visual Studio 2015
3. Hit F5 to run and the API should be running
4. Note down the port in which the API is running locally, it would be required to test the API locally using a web application.
5. Basic Authentication has been implemented in the API, in an ideal world the authentication protocol should be OAuth 2.0 but for intents of this demo project kept things simple.
6. The Username and password to access the API is scott:tiger.
7. Wanted this project to be self contained without dependency on a database, so the API is writing and reading to a JSON file.
8. Go to the Web.Config file of the API to paste the path in which you want to store the source JSON file. The key name is LocalJSONPath
9. When you download the project the JSON file would be downloaded into ProductAPI/Products.txt. Get the full path+file name and paste it onto the LocalJSONPath key.
10. There is one Unit test written to test the functionality of the API. Running this unit test would delete and insert data into the source JSOn File.
11. Have a look at the ProductController.cs file to have a look at the API paths
The paths are :
Get Products: GET api/products
Get Products by Filter : GET api/products and pass the filter condition and value
Get Product by ID : GET api/products/5
Post Product : POST api/products and pass the Product object
Put Product : PUT api/products/5 and pass the updated Product object
Delete Product : DELETE api/products/5
