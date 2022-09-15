Feature: BooksDelete


Scenario: Delete a book
	When the user makes delete request to "http://localhost:5000/Books"
	Then the book should be deleted