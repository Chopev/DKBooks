Feature:BooksDeleteNegative
	

Scenario: Try to delete a book using an invalid ID
	
	
	When the users makes a delete request to "http://localhost:5000/Books" with an invalid ID
	Then the response should be 400 Bad Request