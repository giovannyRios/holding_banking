using System;
using AutoMapper;


public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Client, ClientDTO>()
			.ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
			.ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
			.ForMember(dest => dest.identify, opt => opt.MapFrom(src => src.identify))
			.ReverseMap();

		CreateMap<Account, AccountDTO>()
		.ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
		.ForMember(dest => dest.clientId, opt => opt.MapFrom(src => src.clientId))
		.ForMember(dest => dest.type, opt => opt.MapFrom(src => src.type))
		.ForMember(dest => dest.balance, opt => opt.MapFrom(src => src.balance))
		.ReverseMap();

		CreateMap<AccountMovement, AccountMovementDTO>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.accountId, opt => opt.MapFrom(src => src.accountId))
            .ForMember(dest => dest.type, opt => opt.MapFrom(src => src.type))
            .ForMember(dest => dest.amount, opt => opt.MapFrom(src => src.amount))
            .ForMember(dest => dest.date, opt => opt.MapFrom(src => src.date))
            .ReverseMap();


		CreateMap<Account, AccountModel>()
		.ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
		.ForMember(dest => dest.clientId, opt => opt.MapFrom(src => src.clientId))
		.ForMember(dest => dest.type, opt => opt.MapFrom(src => src.type))
		.ForMember(dest => dest.balance, opt => opt.MapFrom(src => src.balance))
		.ReverseMap();

		CreateMap<AccountDTO, AccountModel>()
		.ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
		.ForMember(dest => dest.clientId, opt => opt.MapFrom(src => src.clientId))
		.ForMember(dest => dest.type, opt => opt.MapFrom(src => src.type))
		.ForMember(dest => dest.balance, opt => opt.MapFrom(src => src.balance))
		.ReverseMap();

		CreateMap<AccountMovement, AccountMovementModel>()
			.ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
			.ForMember(dest => dest.accountId, opt => opt.MapFrom(src => src.accountId))
			.ForMember(dest => dest.type, opt => opt.MapFrom(src => src.type))
			.ForMember(dest => dest.amount, opt => opt.MapFrom(src => src.amount))
			.ForMember(dest => dest.date, opt => opt.MapFrom(src => src.date))
			.ReverseMap();

		CreateMap<AccountMovementDTO, AccountMovementModel>()
			.ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
			.ForMember(dest => dest.accountId, opt => opt.MapFrom(src => src.accountId))
			.ForMember(dest => dest.type, opt => opt.MapFrom(src => src.type))
			.ForMember(dest => dest.amount, opt => opt.MapFrom(src => src.amount))
			.ForMember(dest => dest.date, opt => opt.MapFrom(src => src.date))
			.ReverseMap();



	}
}
