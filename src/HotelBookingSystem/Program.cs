namespace HotelBookingSystem;

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program {
  public static void Main (string[] args) {

    while (true) {

      Console.WriteLine("Select Login or SignUp!");
      String option = Console.ReadLine();

      if (option.Equals("Login")) {

        if (createAccount.getRegisteredUserCount() == 0) {
          Console.WriteLine("Sorry, no one has registered so not possible to log in!");
          continue;
        }

        login loginObj = new login();
        loginObj.loginUser(createAccount.getEmailAddresses(), createAccount.getPassWords());

        Console.WriteLine("Re-enter email address to check booking: ");
        string email = Console.ReadLine();
        BookingStatus Info = new BookingStatus();
        Info.bookingInformation(email);
        
      }

      else if (option.Equals("SignUp"))  {
      
        confirmCreateAccount user = new confirmCreateAccount("","",0,"","","");
        user.firstName();
        user.lastName();
        user.age();
        user.emailAddress();
        user.passWord();
        user.confirmPassword();
        user.display();
        user.confirm();

        roomBooking book = new confirmBooking("","","","",0);
        book.roomType();
        book.roomNumber();
        book.checkInDate();
        book.checkOutDate();
        book.numberOfPeople();

        if (!DateTime.TryParse(book.getRoomCheckInDate(), out var parsedCheckInDate) ||!DateTime.TryParse(book.getRoomCheckOutDate(), out var parsedCheckOutDate)) {
          Console.WriteLine("Invalid dates. Booking cancelled.");
          continue;
        }
    
        Payment cost = new Payment();
        cost.calculateCost(parsedCheckInDate, parsedCheckOutDate, book.getNumberOfPeople(), book.getRoomType());
    
        confirmPayment confirm = new confirmPayment();
        confirm.confirm();

    }

      else {

         Console.WriteLine("Invalid Option. Please try again!");
         continue;
        
      }
   }
  }
}
