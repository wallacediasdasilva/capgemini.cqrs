using AutoMapper;
using MediatRAPI.Application.AppTeam.Command;
using MediatRAPI.Application.AppTeam.Query.Response;
using MediatRAPI.Domain.Team;

namespace MediatRAPI.CrossCutting.Mapper
{
    public class TeamMappingProfile : Profile
    {
        public TeamMappingProfile()
        {
            #region [ DTO TO DOMAIN ]
            CreateMap<TeamGetResponse, TeamEntity>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                              .ForMember(dest => dest.Modality, opt => opt.MapFrom(src => src.Modality))
                              .ForMember(dest => dest.QtdPlayers, opt => opt.MapFrom(src => src.QtdPlayers));
            CreateMap<TeamCreateCommand, TeamEntity>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dest => dest.Modality, opt => opt.MapFrom(src => src.Modality))
                  .ForMember(dest => dest.QtdPlayers, opt => opt.MapFrom(src => src.QtdPlayers));

            CreateMap<TeamUpdateCommand, TeamEntity>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dest => dest.Modality, opt => opt.MapFrom(src => src.Modality))
                  .ForMember(dest => dest.QtdPlayers, opt => opt.MapFrom(src => src.QtdPlayers));


            CreateMap<TeamDeleteCommand, TeamEntity>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            #endregion

            #region [ DOMAIN TO DTO ]

            CreateMap<TeamEntity, TeamCreateCommand>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                              .ForMember(dest => dest.Modality, opt => opt.MapFrom(src => src.Modality))
                              .ForMember(dest => dest.QtdPlayers, opt => opt.MapFrom(src => src.QtdPlayers));

            CreateMap<TeamEntity, TeamUpdateCommand>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dest => dest.Modality, opt => opt.MapFrom(src => src.Modality))
                  .ForMember(dest => dest.QtdPlayers, opt => opt.MapFrom(src => src.QtdPlayers));

            CreateMap<TeamEntity, TeamDeleteCommand>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<TeamEntity, TeamGetResponse>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dest => dest.Modality, opt => opt.MapFrom(src => src.Modality))
                  .ForMember(dest => dest.QtdPlayers, opt => opt.MapFrom(src => src.QtdPlayers));


            #endregion
        }
    }
}
