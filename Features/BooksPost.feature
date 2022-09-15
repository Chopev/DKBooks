Feature:BooksPost

Scenario: Add new book to the list
	When the user makes a post request to "http://localhost:5000/Books"
	Then the user successfully adds a new book to the list