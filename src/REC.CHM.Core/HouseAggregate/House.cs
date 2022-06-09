using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REC.CHM.SharedKernel;
using REC.CHM.SharedKernel.Interfaces;

namespace REC.CHM.Core.HouseAggregate;
public class House : EntityBase, IAggregateRoot
{
  [NotNull]
  public OfferType   OfferType { get; private set; }
  public int AddressId { get; private set; }
  public Address Address { get; private set; }
  public string ImageId   { get; private set; }
  private House(OfferType offerType,string imageId,string address, string postalCode)
  {
    OfferType = offerType;
    ImageId = imageId;
    Address = Address.Create(address, postalCode, Id);
    AddressId = Address.Id;
  }
  public static House Create(OfferType offerType, string imageId, string address, string postalCode)
  {
    return new House(offerType,imageId,address,postalCode);
  }

}
