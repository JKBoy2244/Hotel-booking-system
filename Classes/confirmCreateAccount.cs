class confirmCreateAccount : createAccount {
   

   public confirmCreateAccount(String firstName, String lastName, int age, String emailAddress, String passWord, String confirmPassword) 
    : base(firstName, lastName, age, emailAddress, passWord, confirmPassword) { }


   public void display() {

       for (int i = 0; i < firstNames.Count; i++) {
  
           Console.WriteLine($"{firstNames[i]} {lastNames[i]} {emailAddresses[i]} {ages[i]} {passWords[i]}");
       }
     }

   public override void confirm() {
      Console.WriteLine("Account confirmed!");
    }
   
   }
