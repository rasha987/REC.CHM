using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REC.CHM.SharedKernel;

namespace REC.CHM.Core.HouseAggregate;
public class Address:EntityBase
{
  [NotNull]
  public string Street { get;private set; }
  [NotNull]
  public string PostalCode { get;private set; }
  public int HousId { get;private set; }
  public virtual House House { get;private set; }
  public int CustomerID { get;private set; }

  private Address(string address , string postalCode,int houseId)
  {
    Street = address;
    PostalCode = postalCode;  
    houseId = houseId;
  }
  public static Address Create(string address, string postalCode, int houseId)
  {
    return new Address(address , postalCode, houseId);
  }
}
