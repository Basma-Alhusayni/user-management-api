using AutoMapper;
using UserManagementApi.Models;
using UserManagementApi.Dtos.User;
using UserManagementApi.Dtos.Profile;

namespace UserManagementApi.Config.Mapper
{
    public class MappingProfiler : AutoMapper.Profile
    {
        public MappingProfiler()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();

            CreateMap<Models.Profile, ProfileDto>();
            CreateMap<ProfileCreateDto, Models.Profile>();
            CreateMap<ProfileUpdateDto, Models.Profile>();
        }
    }
}
