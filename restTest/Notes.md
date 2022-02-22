restTest
Getting Started

Welcome to the Bench Rest Test. The purpose of this exercise is to demonstrate your ability to reason about rudimentary APIs and data transformation. You can use any language you feel comfortable with.

We would like you to write an app that we can run from the command line, which:

    1. Connects to a REST API documented below and fetches all pages of financial transactions.

    2. Calculates running daily balances and prints them to the console. For example, given the following transactions:

    [
      {
        "Date": "2013-12-12",
        "Ledger": "Office Expense",
        "Amount": "-25.05",
        "Company": "AA OFFICE SUPPLIES"
      },
      {
        "Date": "2013-12-12",
        "Ledger": "Insurance Expense",
        "Amount": "-20",
        "Company": "AA OFFICE SUPPLIES"
      },
      {
        "Date": "2013-12-13",
        "Ledger": "Business Meals & Entertainment Expense",
        "Amount": "-10.5",
        "Company": "MCDONALDS RESTAURANT"
      },
      {
        "Date": "2013-12-14",
        "Ledger": "Credit Card - 1234",
        "Amount": "25",
        "Company": "PAYMENT - THANK YOU"
      }
    ]

    The running daily balances would be:

    2013-12-12 -45.05
    2013-12-13 -55.55
    2013-12-14 -30.55

Include unit tests for this application.

To submit your work, create a git repository on GitHub and send send us the link in an email.
API Documentation

This API provides access to all the transactions in an imaginary bank account. This is a REST API, providing JSON-formatted data over HTTP.

There is a limit to how many transactions that can be returned in a single request, so the transactions are split into "pages". You will have to download all the pages to get all the data.
Endpoint

GET https://resttest.bench.co/transactions/{page}.json

Responses

200 OK

{
  "totalCount": 32, // Integer, total number of transactions across all pages
  "page": 1, // Integer, current page
  "transactions": [
    {
      "Date": "2013-12-22", // String, date of transaction
      "Ledger": "Phone & Internet Expense", // String, ledger name
      "Amount": "-110.71", // String, amount
      "Company": "SHAW CABLESYSTEMS CALGARY AB" // String, company name
    },
    ...
  ]
}

404 NOT FOUND

No response body

Considerations

    Approach this problem as you would in the real-world. 
    Consider errors that may occur when fetching data from the API such as non-200 http responses. 
    When structuring and organizing your code, treat it as if it were a real-world application
    Consider scalability when picking data abstractions and algorithms;
    what would happen if the transaction list was considerably larger?
    Coding style matters. Ensure your code is consistent and easy to follow. 
    Leave comments where appropriate and use meaningful methods and variables.
    Avoid overly complex code. The complexity of the solution should make sense for the problems you're solving.
    Include a README explaining how to install and/or run your software.
    Please include package/software versions if applicable. Some additional question to consider that you may want to address in the README: what are the the limitations, assumptions, shortcuts, and trade-offs of your code (if applicable)? Do you have any stretch goals for this application? What was not done? What could be better?

