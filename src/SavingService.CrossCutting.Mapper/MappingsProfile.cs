using AutoMapper;
using SavingService.Application.DTO;
using SavingService.Domain.Entity;
using System;

namespace SavingService.CrossCutting.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Customers, CustomersDto>().ReverseMap();


            //CreateMap<Customers, CustomersDto>().ReverseMap()
            //    .ForMember(destination => destination.Customer_Id, source => source.MapFrom(src => src.Customer_Id))
            //    .ForMember(destination => destination.User_Access, source => source.MapFrom(src => src.User_Access))
            //    .ForMember(destination => destination.Sucursal_Id, source => source.MapFrom(src => src.Sucursal_Id))
            //    .ForMember(destination => destination.Nombre, source => source.MapFrom(src => src.Nombre))
            //    .ForMember(destination => destination.Apellidos, source => source.MapFrom(src => src.Apellidos))
            //    .ForMember(destination => destination.Correo, source => source.MapFrom(src => src.Correo))
            //    .ForMember(destination => destination.Tel_1, source => source.MapFrom(src => src.Tel_1))
            //    .ForMember(destination => destination.C_Credito, source => source.MapFrom(src => src.C_Credito))
            //    .ForMember(destination => destination.C_Ahorro, source => source.MapFrom(src => src.C_Ahorro))
            //    .ForMember(destination => destination.Fh_Registro, source => source.MapFrom(src => src.Fh_Registro))
            //    .ForMember(destination => destination.Fh_Modificacion, source => source.MapFrom(src => src.Fh_Modificacion))
            //    .ForMember(destination => destination.Fh_Autorizacion, source => source.MapFrom(src => src.Fh_Autorizacion))
            //    .ForMember(destination => destination.Usr_Registra_Id, source => source.MapFrom(src => src.Usr_Registra_Id))
            //    .ForMember(destination => destination.Usr_Modifica_Id, source => source.MapFrom(src => src.Usr_Modifica_Id))
            //    .ForMember(destination => destination.Usr_Autoriza_Id, source => source.MapFrom(src => src.Usr_Autoriza_Id))
            //    .ReverseMap();


            CreateMap<Roles, RolesDto>().ReverseMap();
            CreateMap<Users, UsersDto>().ReverseMap();
            //CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<TransactionCredit, TransactionCreditDto>().ReverseMap();
            CreateMap<TransactionSaving, TransactionSavingDto>().ReverseMap();
            CreateMap<Tower, TowerDto>().ReverseMap();
            //CreateMap<CreditAccount, CreditAccountDto>().ReverseMap();
            //CreateMap<SavingAccount, SavingAccountDto>().ReverseMap();
        }
    }
}
