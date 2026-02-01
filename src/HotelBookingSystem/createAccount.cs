using HotelBookingSystem.Interfaces;

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

abstract class createAccount : ISignUp {

  private String _firstName;
  private String _lastName;
  private int _age;
  private String _emailAddress;
  private String _passWord;
  private String _confirmPassword;

  private const int maxAttempts = 3;

  protected static List<string> firstNames = new List<string>();
  protected static List<string> lastNames = new List<string>();
  protected static List<int> ages = new List<int>();
  protected static List<string> emailAddresses = new List<string>();
  protected static List<string> passWords = new List<string>();

  public static int getRegisteredUserCount() {
    return firstNames.Count;
  }

  public static List<string> getEmailAddresses() {
    return emailAddresses;
  }

  public static List<string> getPassWords() {
    return passWords;
  }

  public createAccount(String firstName, String lastName, int age, String emailAddress, String passWord, String confirmPassword) {


    this._firstName = firstName;
    this._lastName = lastName;
    this._age = age;
    this._emailAddress = emailAddress;
    this._passWord = passWord;
    this._confirmPassword = confirmPassword;

  } 

  public String getFirstName()  {

    return _firstName;
  }

  public String getLastName()  {

    return _lastName;

  }

  public int getAge()  {

    return _age;
  }

  public String getEmailAddress()  {

    return _emailAddress;
  }

  public String getPassword()  {

    return _passWord;
  }

  public String getConfirmPassword()  {

    return _confirmPassword;
  }

  public void setFirstName(String firstName) {

     if (firstName == null || (firstName.Length < 2 || firstName.Length > 20) || !Regex.IsMatch(firstName, @"^[a-zA-Z\s\-]+$")) {
       throw new ArgumentException("First name either empty or way too many/too less characters");
     }

     if (!firstName.All(char.IsLetter)) {

       throw new ArgumentException("Invalid first name (some characters arent letters");
     }

     this._firstName = firstName;
  }

  public void setLastName(String lastName) {

     if (lastName == null || (lastName.Length < 2 || lastName.Length > 20) || !Regex.IsMatch(lastName, @"^[a-zA-Z\s\-]+$")) {
       throw new ArgumentException("Last name either empty or way too many/too less characters");
     }

    if (!lastName.All(char.IsLetter)) {

       throw new ArgumentException("Invalid last name (some characters arent letters");
     }

     this._lastName = lastName;
  }

 public void setAge(String ageInput) {

   if (!int.TryParse(ageInput, out int age)) {

       throw new ArgumentException("Age must be a valid number without spaces or letters.");
   }

   if ((age <= 17 || age >= 99)) {

     throw new ArgumentException("Age either empty or way too many characters");
   } 

   this._age = age;
 }

 public void setEmailAddress(String emailAddress) {


   if (emailAddress == null || !emailAddress.Contains('@') || emailAddress.Length > 35 || (!emailAddress.EndsWith("gmail.com") && !emailAddress.EndsWith("hotmail.com") && !emailAddress.EndsWith("yahoo.com") && !emailAddress.EndsWith("icloud.com") && !emailAddress.EndsWith("outlook.com"))) {

      throw new ArgumentException("Email address is invalid.");
   }


   this._emailAddress = emailAddress;
 }


  public void setPassword(String passWord) {

     if (passWord == null || passWord.Length < 12 ) {

       throw new ArgumentException("Last name either empty or not at least 12 characters.");
     }

     this._passWord = passWord;
  }

  public void setconfirmPassword(String confirmPassword) {


     if (confirmPassword == null || !string.Equals(_passWord, confirmPassword)) {

       throw new ArgumentException("confirm password dont equal password");
     } 

     this._confirmPassword = confirmPassword;
   }

  private static void RemainingAttempts(int attempts, int maxAttempts) {
    Console.WriteLine("You have " + (maxAttempts - attempts) + " attempts left!");
  }

  public void firstName()  {

    int attempts = 0;
    String firstName = "";

    while (attempts < maxAttempts) {

       Console.WriteLine("Please enter your first name which can't be empty and can't be more than 20 characters long (seems unrealistic): ");
      firstName = Console.ReadLine();
      attempts++;

      if (firstName == null  || (firstName.Length < 2 || firstName.Length > 20) || !firstName.All(char.IsLetter) || !Regex.IsMatch(firstName, @"^[a-zA-Z\s\-]+$")) {
          if (attempts == maxAttempts) {
            Console.WriteLine("3 attempts already used up! Sorry, but the process is restarting unfortunately!");
            return;
          }

          RemainingAttempts(attempts, maxAttempts);
          Console.WriteLine("Sorry, either, your username is empty or is out of character length!");
          continue;
        }

        firstNames.Add(firstName);
        this._firstName = firstName;
        break;

      }  
  }

  public void lastName()  {

    int attempts = 0;
    String lastName = "";

    while (attempts < maxAttempts) {

       Console.WriteLine("Please enter your last name which can't be empty and can't be more than 20 characters long (seems unrealistic): ");
      lastName = Console.ReadLine();
      attempts++;

      if (lastName == null  || (lastName.Length < 2 || lastName.Length > 20) || !lastName.All(char.IsLetter) || !Regex.IsMatch(lastName, @"^[a-zA-Z\s\-]+$")) {
          if (attempts == maxAttempts) {
            Console.WriteLine("3 attempts already used up! Sorry, but the process is restarting unfortunately!");
            return;
          }

          RemainingAttempts(attempts, maxAttempts);
          Console.WriteLine("Sorry, either, your username is empty or is out of character length!");
          continue;
        }

        lastNames.Add(lastName);
        this._lastName = lastName;
        break;

      }  
   }

  public void age() {

    int attempts = 0;

    while (attempts < maxAttempts) {

        Console.WriteLine("Enter your age which can't be empty (You need to be at least 16 to create an account here: ");
        String ageInput = Console.ReadLine();
        attempts++;

        if (!int.TryParse(ageInput, out int age) || (age < 16 || age > 100)) {
          if (attempts == maxAttempts) {
          Console.WriteLine("3 attempts already used up! Sorry, but the process is restarting unfortunately!");
          return;
        }
          
        RemainingAttempts(attempts, maxAttempts);
        Console.WriteLine("Sorry, your age is empty!");
        continue;
        }  

       ages.Add(age);
       this._age = age;
       break;
    }
  }

  public void emailAddress() {

     int attempts = 0;
     String emailAddress = "";

     while (attempts < maxAttempts) {

       Console.WriteLine("Please enter your email address which can't be empty and correct structure!");
       emailAddress = Console.ReadLine()?.Trim().ToLower();
       attempts++;

       if (emailAddress == null || !emailAddress.Contains('@') || (emailAddress.Length < 16 || emailAddress.Length > 35) || (!emailAddress.EndsWith("gmail.com") && !emailAddress.EndsWith("hotmail.com") && !emailAddress.EndsWith("yahoo.com") && !emailAddress.EndsWith("icloud.com") && !emailAddress.EndsWith("outlook.com"))) {
         if (attempts == maxAttempts) {
           Console.WriteLine("3 attempts already used up! Sorry, but the process is restarting unfortunately!");
           return;
         }
         RemainingAttempts(attempts, maxAttempts);
         Console.WriteLine("Sorry, your email address is empty or invalid!");
         continue;
      }

         if (emailAddresses.Contains(emailAddress)) {

           if (attempts == maxAttempts) {
                Console.WriteLine("3 attempts already used up! Sorry, but the process is restarting unfortunately!");
                return;
              }
              RemainingAttempts(attempts, maxAttempts);
              Console.WriteLine("Sorry, that email address is already taken!");
              continue;
           }

       emailAddresses.Add(emailAddress);
       this._emailAddress = emailAddress;
       break;
   }
  }

 public void passWord()  {

   int attempts = 0;
   String passWord = "";

   while (attempts < maxAttempts) {

    Console.WriteLine("Please enter your password which can't be empty and at least 12 characters long!");
    passWord = Console.ReadLine();
    attempts++;

    if (passWord == null || passWord.Length < 12 ) {
      if (attempts == maxAttempts) {
           Console.WriteLine("3 attempts already used up! Sorry, but the process is restarting unfortunately!");
           return;
         }
         RemainingAttempts(attempts, maxAttempts);
         Console.WriteLine("Sorry, your email address is empty or invalid!");
         continue;
      }

     passWords.Add(passWord);
     this._passWord = passWord;
     break;
   }
 }

   public void confirmPassword()  {

      int attempts = 0;
      String confirmPassword = "";

      while (attempts < maxAttempts) {

       Console.WriteLine("Please re-confirm your password!");
       confirmPassword = Console.ReadLine();
       attempts++;

       if (confirmPassword != this._passWord) {
         if (attempts == maxAttempts) {
              Console.WriteLine("3 attempts already used up! Sorry, but the process is restarting unfortunately!");
              return;
            }
            RemainingAttempts(attempts, maxAttempts);
            Console.WriteLine("Sorry confirm password doesn't match your original password");
            continue;
         }

        this._confirmPassword = confirmPassword;
        break;
    }
  }

  public abstract void confirm();
}
