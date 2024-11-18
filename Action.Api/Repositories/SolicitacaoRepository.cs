
using Action.Api.Enum;
using Action.Api.Models;
using Action.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Action.Api.Repositories
{
    public class SolicitacaoRepository : Repository<Solicitacao>, ISolicitacaoRepository
    {
        public SolicitacaoRepository(DbContext context) : base(context) { }

        public async Task<IEnumerable<Solicitacao>> GetPendenteAprovacao()
        {
            var result = await _dbSet.Where(s => s.Status == StatusSolicitacao.PendenteAprovacao).ToListAsync();
            return result.AsEnumerable();
        }

        public async Task<IEnumerable<Solicitacao>> GetAprovadas()
        {
            var result = await _dbSet.Where(s => s.Status == StatusSolicitacao.Aprovada).ToListAsync();
            return result.AsEnumerable();
        }

        public async Task<IEnumerable<Solicitacao>> GetPendentePublicacao()
        {
            var result = await _dbSet.Where(s => s.Status == StatusSolicitacao.PendentePublicacao).ToListAsync();
            return result.AsEnumerable();
        }

        public async Task<IEnumerable<Solicitacao>> GetPublicadas()
        {
            var result = await _dbSet.Where(s => s.Status == StatusSolicitacao.Publicada).ToListAsync();
            return result.AsEnumerable();
        }

        public async Task<IEnumerable<Solicitacao>> GetRecusadas()
        {
            var result = await _dbSet.Where(s => s.Status == StatusSolicitacao.Recusada).ToListAsync();
            return result.AsEnumerable();
        }

        public async Task<Solicitacao> GetByIdWithActions(int id)
        {
            var solicitacao = await _dbSet.Include(s => s.Actions).FirstOrDefaultAsync(s => s.Id == id);
            if (solicitacao == null)
            {
                throw new KeyNotFoundException($"Solicitação with id {id} not found.");
            }
            return solicitacao;
        }
    }
}