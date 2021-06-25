<h1>This is automated Unit test (MSTest) C# Selenium WebDriver Example
Demonstrates how you can register new user. Based on Page Object Model</h1>

This Code Demonstrates how you can automate the registration of a new user on http://automationpractice.com/ The Automation test will try to register a new user, who's name is hardcoded into the app.config file. If such a user already exists, the Automation Test will add extra characters to the email string and will try to register again. After successful registration, the Automation test will try to log in with a previously registered username and password. If login is successful, Automation Test will Assert whether the logged user's first name and the last name are equals to hardcoded first name and last name in the Automated Test If they equal the assert will pass.
See it in action:
https://www.youtube.com/watch?v=_CJw_QGQk5Q&feature=youtu.be
