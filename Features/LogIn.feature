Feature: Log in
	

Scenario: Log in and receive a valid token
	
	When the user logs in
	Then the user receives a valid token