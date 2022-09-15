Feature: BooksPutNegative
	


Scenario: Try to pass integers for title and publisher
	When the user makes a put request to "http://localhost:5000/Books" with integers for title and publisher
	Then the response shoud be 400 Bad Request