Feature: Validating Contact section in Codafit application

Background: Launching app
Given the user launching the Codafit app

@TestRun
Scenario: Validating all the Contact us link on the Codafit homepage	
	When user click on the ContactUs link at the header
	Then verify the navigation of the ContactUs page
	When user navigate to homePage	
	And user click on the ContactUs link at the bottomPage
	Then verify the navigation of the ContactUs page

	@TestRun
	Scenario: Validating the Title of the Contact Page
	When user click on the ContactUs link at the header
	Then verify the Title of the Contact page

	@TestRun
	Scenario: Validating the error message in the Contact page form	
	When user click on the ContactUs link at the header
	And the user submit the contact form
	Then verify the error message in the contact form