using AutoMapper;
using Url_Shortener.UrlShortener.Core.Models;
using Url_Shortener.UrlShortener.Web.Entities;

namespace Url_Shortener.UrlShortener.Web.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateRequest, User>();
        CreateMap<UpdateRequest, User>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop is string arg3 && string.IsNullOrEmpty(arg3)) return false;

                    // ignore null role
                    if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                    return true;
                }
            ));
    }
}