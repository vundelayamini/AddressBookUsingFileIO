﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookFileIO
{
    class AddressBook : IContact
    {
        private Dictionary<string, Contact> addressBook = new Dictionary<string, Contact>();//create dictionary
        private Dictionary<string, AddressBook> addressBookDictionary = new Dictionary<string, AddressBook>();//create dictionary for addressbookdictionary   
        private Dictionary<Contact, string> cityDictionary = new Dictionary<Contact, string>();//create dictionary for city
        private Dictionary<Contact, string> stateDictionary = new Dictionary<Contact, string>();//create dicionay for state
        public void AddContact(string firstName, string lastName, string address, string city, string state, string email, int zip, long phoneNumber, string bookName)//constructor
        {
            Contact contact = new Contact(firstName, lastName, address, city, state, email, zip, phoneNumber);
            addressBookDictionary[bookName].addressBook.Add(contact.FirstName + " " + contact.LastName, contact);
            Console.WriteLine("\nAdded Succesfully. \n");
        }
        /// <summary>
        /// UC1-Create contacts
        /// </summary>
        /// <param name="name"></param>
        /// <param name="bookName"></param>
        public void ViewContact(string name, string bookName)
        {
            foreach (KeyValuePair<string, Contact> item in addressBookDictionary[bookName].addressBook)
            {
                if (item.Key.Equals(name))
                {
                    Console.WriteLine("First Name : " + item.Value.FirstName);
                    Console.WriteLine("Last Name : " + item.Value.LastName);
                    Console.WriteLine("Address : " + item.Value.Address);
                    Console.WriteLine("City : " + item.Value.City);
                    Console.WriteLine("State : " + item.Value.State);
                    Console.WriteLine("Email : " + item.Value.Email);
                    Console.WriteLine("Zip : " + item.Value.Zip);
                    Console.WriteLine("Phone Number : " + item.Value.PhoneNumber + "\n");
                }
            }
        }
        /// <summary>
        /// UC2-Ability to edit  existing contact person using their name
        /// </summary>
        /// <param name="bookName"></param>
        public void ViewContact(string bookName)
        {
            foreach (KeyValuePair<string, Contact> item in addressBookDictionary[bookName].addressBook)
            {
                Console.WriteLine("First Name : " + item.Value.FirstName);
                Console.WriteLine("Last Name : " + item.Value.LastName);
                Console.WriteLine("Address : " + item.Value.Address);
                Console.WriteLine("City : " + item.Value.City);
                Console.WriteLine("State : " + item.Value.State);
                Console.WriteLine("Email : " + item.Value.Email);
                Console.WriteLine("Zip : " + item.Value.Zip);
                Console.WriteLine("Phone Number : " + item.Value.PhoneNumber + "\n");
            }
        }
        /// <summary>
        ///UC3-Ability to edit existing contact person using their name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="bookName"></param>
        public void EditContact(string name, string bookName)//Edit the existing contact details
        {
            foreach (KeyValuePair<string, Contact> item in addressBookDictionary[bookName].addressBook)
            {
                if (item.Key.Equals(name))
                {
                    Console.WriteLine("Choose What to Edit \n1.First Name \n2.Last Name \n3.Address \n4.City \n5.State \n6.Email \n7.Zip \n8.Phone Number");//print the values
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter New First Name :");//Take input from the user
                            item.Value.FirstName = Console.ReadLine();//store the value
                            break;
                        case 2:
                            Console.WriteLine("Enter New Last Name :");
                            item.Value.LastName = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter New Address :");
                            item.Value.Address = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter New City :");
                            item.Value.City = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Enter New State :");
                            item.Value.State = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Enter New Email :");
                            item.Value.Email = Console.ReadLine();
                            break;
                        case 7:
                            Console.WriteLine("Enter New Zip :");
                            item.Value.Zip = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 8:
                            Console.WriteLine("Enter New Phone Number :");
                            item.Value.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                            break;
                    }
                    Console.WriteLine("\nEdited Successfully.\n");
                }
            }
        }
        /// <summary>
        ///UC4- Ability to delete person using person's name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="bookName"></param>
        public void DeleteContact(string name, string bookName)//Delete a person using name
        {
            {
                if (addressBookDictionary[bookName].addressBook.ContainsKey(name))
                {
                    addressBookDictionary[bookName].addressBook.Remove(name);
                    Console.WriteLine("\nDeleted Succesfully.\n");
                }
                else
                {
                    Console.WriteLine("\nNot Found, Try Again.\n");
                }
            }
        }
            /// <summary>
            ///UC5-add multiple Address Book to the System.
            /// </summary>
            /// <param name="bookName"></param>
            public void AddAddressBook(string bookName)
            {
                AddressBook addressBook = new AddressBook();
                addressBookDictionary.Add(bookName, addressBook);
                Console.WriteLine("AddressBook Created.");
            }
            /// <summary>
            ///UC6-Add Multiple addressbook
            /// </summary>
            /// <returns></returns>
            public Dictionary<string, AddressBook> GetAddressBook()
            {
                return addressBookDictionary;
            }
            public List<Contact> GetListOfDictctionaryValues(string bookName)
            {
                List<Contact> book = new List<Contact>();
                foreach (var value in addressBookDictionary[bookName].addressBook.Values)
                {
                    book.Add(value);
                }
                return book;
            }
            public List<Contact> GetListOfDictctionaryKeys(Dictionary<Contact, string> d)
            {
                List<Contact> book = new List<Contact>();
                foreach (var value in d.Keys)
                {
                    book.Add(value);
                }
                return book;
            }
            /// <summary>
            ///UC7-Duplicate Entry of the same Person
            /// </summary>
            /// <param name="c"></param>
            /// <param name="bookName"></param>
            /// <returns></returns>
            public bool CheckDuplicateEntry(Contact c, string bookName)
            {
                List<Contact> book = GetListOfDictctionaryValues(bookName);
                if (book.Any(b => b.Equals(c)))
                {
                    Console.WriteLine("Name already Exists.");
                    return true;
                }
                return false;
            }
            /// <summary>
            ///UC8-search Personin a City or State across
            /// </summary>
            /// <param name="city"></param>
            public void SearchPersonByCity(string city)
            {
                foreach (AddressBook addressbookobj in addressBookDictionary.Values)
                {
                    CreateCityDictionary();
                    List<Contact> contactList = GetListOfDictctionaryKeys(addressbookobj.cityDictionary);
                    foreach (Contact contact in contactList.FindAll(c => c.City.Equals(city)).ToList())
                    {
                        Console.WriteLine(contact.ToString());
                    }
                }
            }
            /// <summary>
            /// Search person in state
            /// </summary>
            /// <param name="state"></param>
            public void SearchPersonByState(string state)
            {
                foreach (AddressBook addressbookobj in addressBookDictionary.Values)
                {
                    CreateStateDictionary();
                    List<Contact> contactList = GetListOfDictctionaryKeys(addressbookobj.stateDictionary);
                    foreach (Contact contact in contactList.FindAll(c => c.State.Equals(state)).ToList())
                    {
                        Console.WriteLine(contact.ToString());
                    }
                }
            }
            /// <summary>
            ///UC9-View person in city using dictionary
            /// </summary>
            public void CreateCityDictionary()
            {
                foreach (AddressBook addressBookObj in addressBookDictionary.Values)
                {
                    foreach (Contact contact in addressBookObj.addressBook.Values)
                    {
                        addressBookObj.cityDictionary.TryAdd(contact, contact.City);
                    }
                }
            }
            /// <summary>
            ///View persons in state
            /// </summary>
            public void CreateStateDictionary()
            {
                foreach (AddressBook addressBookObj in addressBookDictionary.Values)
                {
                    foreach (Contact contact in addressBookObj.addressBook.Values)
                    {
                        addressBookObj.stateDictionary.TryAdd(contact, contact.State);
                    }

                }
            }
            /// <summary>
            /// UC10-Display count by city or state 
            /// </summary>
            public void DisplayCountByCityandState()
            {
                CreateCityDictionary();
                CreateStateDictionary();
                Dictionary<string, int> countByCity = new Dictionary<string, int>();
                Dictionary<string, int> countByState = new Dictionary<string, int>();
                foreach (var obj in addressBookDictionary.Values)
                {
                    foreach (var person in obj.cityDictionary)
                    {
                        countByCity.TryAdd(person.Value, 0);
                        countByCity[person.Value]++;
                    }
                }
                Console.WriteLine("City wise count :");
                foreach (var person in countByCity)
                {
                    Console.WriteLine(person.Key + ":" + person.Value);
                }
                foreach (var obj in addressBookDictionary.Values)
                {
                    foreach (var person in obj.stateDictionary)
                    {
                        countByState.TryAdd(person.Value, 0);
                        countByState[person.Value]++;
                    }
                }
                Console.WriteLine("State wise count :");
                foreach (var person in countByState)
                {
                    Console.WriteLine(person.Key + ":" + person.Value);
                }
            }
            /// <summary>
            /// UC11-Sort by name alphabetically
            /// </summary>
            public void SortByName()
            {
                foreach (AddressBook addressBookobj in addressBookDictionary.Values)
                {
                    List<string> list = addressBookobj.addressBook.Keys.ToList();
                    list.Sort();
                    foreach (string name in list)
                    {
                        Console.WriteLine(addressBookobj.addressBook[name].ToString());
                    }
                }
            }

        
    }

}




