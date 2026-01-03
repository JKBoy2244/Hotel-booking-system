using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program {
  public static void Main (string[] args) {

    confirmCreateAccount user = new confirmCreateAccount("","",0,"","","");
    user.firstName();
    user.lastName();
    user.age();
    user.emailAddress();
    user.passWord();
    user.confirmPassword();
    user.display();
    user.confirm();
    
  }
}
