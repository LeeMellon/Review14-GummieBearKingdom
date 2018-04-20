# Gummy Kingdom Proposal
***

### Current Functionality
***

### Future Functionality
***

### Database Setup
***
In the appsettings.json file look for "DefaultConnection"
Here you will find the name for the database which is currently "gummykingdom". If you want to make changes to the database name, and more importantly the password and user id this is where you would do that.

Install and run MAMP [which can be found here](https://www.mamp.info/en/downloads/ "MAMP downloads page").
..* [Documentation can be found here](https://www.mamp.info/en/documentation/ "MAMP Installation Documentation")

Launch MAMP, click on preferences and under the Ports tab, set the MySql port to 8889.

From the terminal go into the root folder of your project directory and navigate to the folder that contains your .csproj file, and type: dotnet ef database update

From here you database should be up and running and ready for you to add the products you create.

..* Generic Product Class Schema
... ProductId (int)
... Name (string)
... Cost (int)
... Description (string)
... Img (string)
... Rating (int)
... Reviews (ICollections List)

..* User Model
... UserId (int)
... UserNameFirst (string)
... UserNameLast (string)
... ProfileName (string)
... UserEmail (string)
... Reviews (ICollections List)

..* Reviews
... ReviewId (int)
... ReviewText (string)
... UserId (int)
... ProductId (int)


### Known Bugs
***

### Repository Info
***
[Click here to go to the git repository](https://github.com/LeeMellon/Review14-GummieBearKingdom "Gummy Kingdom Repo")

### Current Specs
***

##### License Information
***
