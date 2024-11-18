using Action.Api.DTOs;
using Action.Api.Enum;
using Action.Api.Models;
using AutoMapper;

namespace Action.Api.Profiles
{
    public class SolicitacaoProfile : Profile
    {
        public SolicitacaoProfile()
        {
            CreateMap<Solicitacao, SolicitacaoDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<SolicitacaoDTO, Solicitacao>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => System.Enum.Parse<StatusSolicitacao>(src.Status)));
        }
    }
}