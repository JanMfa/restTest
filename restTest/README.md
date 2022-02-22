This Projects consist of 3  main part:
1. Components: Main components of this project.
2. DTO: Data Transfer Object. The purpose of this is to store the data object fetch from the API calls.
3. UnitTest: Test of each main components

The main component of this project is split to 3:
1. Connect: Connects to the REST API and fetches all pages of financial transactions.
2. Processor:  Calculates running daily balances. 
3. TransactionProcessor: Object that grabs data from Connect and return calculated daily balances from Processors

Consideration:
1. Handle case when error occurs: Whenever an error occus, i.e non-200 http responses, I return empty result 
2. Consider scalability when picking data abstractions and algorithms; what would happen if the transaction list was considerably larger?
When the trasaction list was considerably larger, I would prefer to use multi-threading for each page, and join them together at the end.
3. What are the the limitations, assumptions, shortcuts, and trade-offs of your code? 
One of the limitation would be long time to fetch and run the whole process.
Shortcuts: All of the functions in each components are accessible for all classes (as all are declared as public)
4. Do you have any stretch goals for this application? What was not done? What could be better? Currently, I created the project to be as
simple as possible; one component per functionality. There are only 38 transactions in the rest api given. Currently, it takes 822 ms 
for the whole loading of data and business logic processes to finish. With increasing number of transactions and pages, the processes will 
take longer. So the stretch goal would be the scalability and the time complexity of the project.


How to install:
1. Install Visual Studio (https://visualstudio.microsoft.com/vs/)
2. Under the project folder, double click restTest.sln

How to run the console app:
1. Open Visual Studio
2. On main toolbar, go to Debug > Start without Debugging OR press on restTest play button 

How to run unit test:
1. Open Visual Studio
2. On main toolbar, go to Test > Run All Tests

Package/software versions:
1. Visual Studio 2022
2. FluentAssertions ver.6.5.1
3. Microsoft.NET.Test.Sdk ver. 17.1.0
4. xunit ver. 2.4.1
5. xunit.runner.visualstudio ver. 2.4.3