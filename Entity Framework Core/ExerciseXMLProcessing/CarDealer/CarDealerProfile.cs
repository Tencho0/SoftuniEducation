using System.Globalization;
using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();
            this.CreateMap<ImportPartDto, Part>()
                .ForMember(d => d.SupplierId,
                    opt => opt.MapFrom(s => s.SupplierId.Value));
            this.CreateMap<Part, ExportPartDto>();

            this.CreateMap<Car, ExportCarWithPartsDto>()
                .ForMember(d => d.Parts,
                    opt => opt.MapFrom(s => s.PartsCars
                                                        .Select(pc => pc.Part)
                                                        .OrderByDescending(p => p.Price)
                                                        .ToArray()));
            this.CreateMap<Car, ExportCarDto>();
            this.CreateMap<Car, ExportCarBMWDto>();
            this.CreateMap<ImportCarDto, Car>()
                .ForSourceMember(s => s.Parts, opt => opt.DoNotValidate());
            //.ForMember(d => d.PartsCars,
            //    opt => opt
            //                    .MapFrom(s => s.Parts
            //                                                            .Select(p =>
            //                                                                new PartCar() { PartId = p.PartId })));

            this.CreateMap<ImportCustomerDto, Customer>();
            //.ForMember(d => d.BirthDate,
            //    opt =>
            //        opt.MapFrom(s =>
            //            DateTime.Parse(s.BirthDate, CultureInfo.InvariantCulture)));
            this.CreateMap<ImportSaleDto, Sale>();
        }
    }
}