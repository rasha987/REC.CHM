
using Ardalis.Result;
using REC.CHM.Core.HouseAggregate;

namespace REC.CHM.Core.Interfaces;
public interface IHouseService
{
  Task<Result<House>> AddNewHouse(OfferType offerType, string address, string postalCode);
}

