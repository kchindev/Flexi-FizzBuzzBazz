# Flexi-FizzBuzzBazz

### Description
Flexi-FizzBuzzBazz is a web app that generates a list of items representing the consecutive sequence of integers from **Start** to **End**.  When the integer is a multiple of **Fizz**, the string "Fizz" is added instead. Likewise, for multiples of **Buzz**, "Buzz" is added. For multiples of both **Fizz** and **Buzz**, "FizzBuzz" is added.

If the optional **Bazz** value is given, then "FizzBuzz" becomes "FizzBuzzBazz" for items that meet the optional condition.

The web page automatically scales for mobile display, and offers both mobile and desktop experience.

### Language and Tools
Flexi-FizzBuzzBazz is a Web Forms app written in C# using Visual Studio 2015 and hosted on Microsoft Azure  https://flexifizzbuzzbazz.azurewebsites.net/ to explore the following:
* Bootstrap Jumbotron
* CSS
* Javascript
* C#
* Web Forms
* Azure

### C# and Web Forms specific items such as
* asp:**_CompareValidator_** and asp:**_RequiredFieldValidator_** for user input validation
* C# **_Interface_**

### Code hightlights
- Default.aspx
  - User input validation using **_RequiredFieldValidator_**, **_CompareValidator_**, **_RequiredFieldValidator_**
  - Javascript function **_OnRunButtonPressed()_** for handling button press
- Default.aspx.cs
  - Illustrates the use of C# **_Predicate_** and **_lambda expression_**.  Given a selected “Bazz” option, the **_Predicate_** returns a **_True_** or **_False_** value depending on the outcome of the associated **_lambda expression_**, for instance ```x => x < bazzValue``` will result in **_True_** when ```x``` is less than the given value of _Bazz_.  For example, if ```x``` is 4 and _Bazz_ value is 6, then we’d expect a **_True_**, whereas if ```x``` is 10 while _Bazz_ is 6, then the result is **_False_**.
- GoFizzBuzz.cs
  - C# Interface usage **_IFizzBuzzBazz_**
  - **_FizzBuzzBazz_** logic implementation

### References for publishing to Microsoft Azure
* https://docs.microsoft.com/en-us/azure/app-service-web/web-sites-dotnet-get-started
* https://docs.microsoft.com/en-us/aspnet/core/publishing/azure-continuous-deployment
* https://docs.microsoft.com/en-us/azure/app-service-web/web-sites-deploy

### Sample screenshot
![flex-fizzbuzzbazz screenshot](https://user-images.githubusercontent.com/19395671/34316956-fe754906-e757-11e7-8939-60a6c41ab389.png)
