Feature: BooksGetNegative
	
Scenario: Try to get a list of books from an author while passing an integer for AuthorFirstName
	
	When the user enters an integer for a parameter
	Then The response code is 400