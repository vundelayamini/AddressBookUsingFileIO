﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookFileIO
{
    class Contact
    {

        public string FirstName { get; set; }//get and set method
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public int Zip { get; set; }
        public long PhoneNumber { get; set; }
        public Contact(string firstName, string lastName, string address, string city, string state, string email, int zip, long phoneNumber)//Constructor
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Email = email;
            Zip = zip;
            PhoneNumber = phoneNumber;
        }
        public override bool Equals(object obj)//Override method
        {
            Contact contact = (Contact)obj;
            if (contact == null)
                return false;
            else
                return FirstName.Equals(contact.FirstName) && LastName.Equals(contact.LastName);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }
        public override string ToString()
        {
            return "First Name :" + FirstName + "\nLast Name : " + LastName + "\nCity : " + City + "\nState : " + State + "\nEmail : " + Email + "\nZip : " + Zip + "\nPhone Number : " + PhoneNumber + "\n";
        }
    }
}

