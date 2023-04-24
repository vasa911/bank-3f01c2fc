using AutoMapper;
using BankSystem.Application.Models;
using BankSystem.Domain.Aggregates.User;

namespace BankSystem.Application.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Account, UserAccount>();
        }
    }
}
