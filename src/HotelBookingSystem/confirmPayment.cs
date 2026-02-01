namespace HotelBookingSystem;

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


class confirmPayment : Payment {

  public void confirm() {
    Console.WriteLine("Payment confirmed - Step 3 complete!");
    Console.WriteLine("Thank you for booking with us. Please take a seat and we will call you in a while!");
    Console.WriteLine("Have a good day!");
  }
}
