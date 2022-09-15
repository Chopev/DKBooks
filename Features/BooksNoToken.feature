Feature: BooksNoToken
	


Scenario: Try to add a new book without a token
	Given the user does no have a token
	When the user sends post request to "http://localhost:5000/Books"
	Then the user gets response 401