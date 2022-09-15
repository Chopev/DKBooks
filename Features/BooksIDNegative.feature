Feature: BooksIDNegative


Scenario: Make a request to "http://localhost:5000/Books/1" without providing a token

	When the user makes a request to "http://localhost:5000/Books/1" without a token
	Then the result should be a response 401 Unauthorized