// cria interface ISolicitacaoService.cs

using System.Collections.Generic;
using System.Threading.Tasks;
using Action.Api.DTOs;

namespace Action.Api.Services.Interfaces
{
    public interface ISolicitacaoService
    {
        Task<IEnumerable<SolicitacaoDTO>> GetAllSolicitacoes();
        Task<SolicitacaoDTO> CreateSolicitacao(SolicitacaoDTO solicitacaoDTO);
        Task<SolicitacaoDTO> GetSolicitacaoById(int id);
        Task<SolicitacaoDTO> UpdateSolicitacao(int id, SolicitacaoDTO solicitacaoDTO);
        Task DeleteSolicitacao(int id);
    }
}