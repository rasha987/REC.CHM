using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REC.CHM.SharedKernel;

namespace REC.CHM.Core.CustomerAggregate;
public class Phone: EntityBase
{
  public string PhoneNumber { get;private set; }
  public int CustomerID { get; private set; }
  public virtual Customer Customer { get; private set; }
  private Phone(string phoneNumber, int customerId)
  {
    PhoneNumber = phoneNumber;
  }
  public static Phone Create(string phoneNumber, int customerId)
  {
    return new Phone(phoneNumber, customerId);
  }
}
