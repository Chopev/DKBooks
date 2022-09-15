Feature: BooksGet

Scenario: Get a list of available books

	When the user makes a get request to "http://localhost:5000/Books"		
	Then the response returns a list of available books 