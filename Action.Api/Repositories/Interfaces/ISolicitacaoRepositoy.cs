
using Action.Api.Models;

namespace Action.Api.Repositories.Interfaces
{
    public interface ISolicitacaoRepository : IRepository<Solicitacao>
    {
        Task<IEnumerable<Solicitacao>> GetPendenteAprovacao(); // Solicitações pendentes
        Task<IEnumerable<Solicitacao>> GetAprovadas(); // Solicitações aprovadas
        Task<IEnumerable<Solicitacao>> GetPendentePublicacao(); // Solicitações pendentes de publicação
        Task<IEnumerable<Solicitacao>> GetPublicadas(); // Solicitações publicadas
        Task<IEnumerable<Solicitacao>> GetRecusadas(); // Solicitações recusadas
        Task<Solicitacao> GetByIdWithActions(int id);  // Solicitação com as ações carregadas
    }
}