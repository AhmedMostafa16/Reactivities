using Application.Activities;
using AutoMapper;
using Domain;

namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Activity, Activity>();
        CreateMap<Activity, ActivityDto>()
            .ForMember(dist => dist.HostUsername, options => options.MapFrom(s => s.Attendees
            .FirstOrDefault(x => x.IsHost).AppUser.UserName));
        CreateMap<ActivityAttendee, Profiles.Profile>()
            .ForMember(dist => dist.DisplayName, options => options.MapFrom(s => s.AppUser.DisplayName))
            .ForMember(dist => dist.Username, options => options.MapFrom(s => s.AppUser.UserName))
            .ForMember(dist => dist.Bio, options => options.MapFrom(s => s.AppUser.Bio));
    }
}