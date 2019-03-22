using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAcc.Models
{
    public class User
    {
       [Key]
       public int UserId {get; set;}

       [Required]
       [MinLength(2, ErrorMessage="First name must be atleast 2 characters")]
       [Display(Name = "First Name")]
       public string FirstName {get; set;}

       [Required]
       [MinLength(2, ErrorMessage="Last name must be atleast 2 characters")]
       [Display(Name = "Last Name")]
       public string LastName {get; set;}

       [Required]
       [DataType(DataType.EmailAddress, ErrorMessage="Invalid Email Address")]
       public string Email {get; set;}

       [Required]
       [MinLength(8, ErrorMessage="Password must be atleast 8 character long")]
       [DataType(DataType.Password)]
       public string Password {get; set;}

       public DateTime CreatedAt {get; set;} = DateTime.Now;
       public DateTime UpdatedAt {get; set;} = DateTime.Now;
       public List<Transaction> UserTransactions {get; set;}

       [NotMapped]
       [Compare("Password", ErrorMessage="Passwords does not match")]
       [DataType(DataType.Password)]
       [Display(Name = "Confirm Password")]
       public string Confirm {get; set;}
    }

    public class Transaction
    {
        [Key]
        public int TransactionId {get; set;}

        [Display(Name = "Deposit/Withdraw")]   
        [Required (ErrorMessage="Enter an Amount")]
        public decimal? Amount {get; set;} 
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        public int UserId {get; set;}
        public User Initiator {get; set;}
    }

    public class myUser
    {
       [Required]
       [DataType(DataType.EmailAddress, ErrorMessage="Invalid Email Address")]
       public string Email {get; set;}

       [Required]
       [MinLength(8, ErrorMessage="Password must be atleast 8 character long")]
       [DataType(DataType.Password)]
       public string Password {get; set;}
    }

    public class ViewModel
    {
        public Transaction Trans {get; set;}
        public User thisUser {get; set;}
    }

}