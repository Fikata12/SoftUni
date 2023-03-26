using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<P11_CarDto, Car>();
            CreateMap<P11_PartCarDto, PartCar>();
        }
    }
}
