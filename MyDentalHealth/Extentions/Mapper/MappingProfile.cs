using AutoMapper;
using Entity.Models.Dto;
using Entity.Models.Dto.Profile;
using Entity.Models.Target;
using Entity.Models.Target.Status;
using Entity.Models.User;

namespace MyDentalHealth.Extentions.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {

            //New User
            CreateMap<NewUserDto, User>().ReverseMap();

            //User Profile Update
            CreateMap<BirthdayDateUpdateDto, User>();
            CreateMap<EmailUpdateDto, User>();
            CreateMap<NameUpdateDto, User>();
            CreateMap<SurnameUpdateDto, User>();
            CreateMap<PasswordUpdateDto, User>();

            //Target Dto
            CreateMap<TargetDto, Target>().ReverseMap();

            //Target Status Dto
            CreateMap<TargetStatusDto, TargetStatus>().ReverseMap();
        }
    }
}
