using HotelBookingSystem.Interfaces;

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class login : ILogin {

  public void loginUser(List<string> emailAddresses, List<string> passWords) {
    
    Console.WriteLine("Email address: ");
    String email = Console.ReadLine();
    Console.WriteLine("Password: ");
    String password = Console.ReadLine();

    bool found = false;
    for (int i = 0; i < emailAddresses.Count; i++) {
      if (email != null && password != null && emailAddresses[i].Equals(email) && passWords[i].Equals(password)) {
        found = true;
        break;
      }
    }

    if (!found) {
      Console.WriteLine("Sorry that's incorrect, try again!");
      return;
    }

    Console.WriteLine("Login successful!");
  }
}
