# Task1
This is a solution for proposed task, from Tranzact.
Required testcase code can be seen on Task1.cs, on NewAccountRegistration() method.


Task to be resolved
======================================================
Create automated tests using the following test case:
Sign in

Preconditions
* Generated customer with all customer data

Test steps
* Open [Home page](http://automationpractice.com/index.php)
* Click *Sign in* button
* Fill *Email address* to create an account
* Click *Create an account*
* Fill all fields with correct data
* Click *Register* button

Assertions
* My account page(?controller=my-account) is opened
* Proper username is shown in the header
* Log out action is available.

How to Execute
======================================================
Open MyStore.sln with Visual Studio 2019
Open "Test Explorer" and navigate/execute following testcase:
My Store > MyStore.Testcases > Task1 > NewAccountRegistration
