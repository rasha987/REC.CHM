using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using REC.CHM.Core.HouseAggregate;
using REC.CHM.Core.Interfaces;
using REC.CHM.SharedKernel.Interfaces;

namespace REC.CHM.Core.Services;
public class HouseService: IHouseService
{
  private readonly IRepository<House> _houseRepository;
  public HouseService(IRepository<House> houseRepository)
  {
    _houseRepository = houseRepository;

  }

  public async Task<Result<House>> AddNewHouse(OfferType offerType, string address, string postalCode)
  {
    var result= House.Create(offerType, address, postalCode);
    return new Result<House>(result);    
  }
}
