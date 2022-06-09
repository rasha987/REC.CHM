using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REC.CHM.SharedKernel;
using REC.CHM.SharedKernel.Interfaces;

namespace REC.CHM.Core.CustomerAggregate;
public class Customer :EntityBase, IAggregateRoot
{
  public string FirstName { get;private set; }
  public string LastName { get;private set; }   
  public virtual ICollection<Phone> Phones { get; private set; }

  private Customer(string firstName, string lastName )
  {
    FirstName = firstName;
    LastName = lastName; 
  }
  public static Customer Create(string firstName, string lastName)
  {
    return new Customer(firstName,lastName);
  }
  public void AddPhone(string phoneNumber)
  {
    Phones.Add(Phone.Create(phoneNumber, Id));
  }


}
