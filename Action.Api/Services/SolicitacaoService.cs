using Action.Api.Data;
using Action.Api.DTOs;
using Action.Api.Models;
using Action.Api.Repositories.Interfaces;
using Action.Api.Services.Interfaces;
using AutoMapper;

namespace Action.Api.Services
{
    public class SolicitacaoService : ISolicitacaoService
    {

        private readonly IMapper _mapper;
        private readonly ISolicitacaoRepository _solicitacaoRepository;
        private readonly AppDbContext _context;

        public SolicitacaoService(AppDbContext context, IMapper mapper, ISolicitacaoRepository solicitacaoRepository)
        {
            _context = context;
            _mapper = mapper;
            _solicitacaoRepository = solicitacaoRepository;
        }

        public async Task<IEnumerable<SolicitacaoDTO>> GetAllSolicitacoes()
        {
            var solicitacoes = await _solicitacaoRepository.GetAll();
            return _mapper.Map<IEnumerable<SolicitacaoDTO>>(solicitacoes);
        }

        public async Task<SolicitacaoDTO> CreateSolicitacao(SolicitacaoDTO solicitacaoDTO)
        {
            var solicitacao = _mapper.Map<Solicitacao>(solicitacaoDTO);
            var solicitacaoCreated = await _solicitacaoRepository.Add(solicitacao);
            return _mapper.Map<SolicitacaoDTO>(solicitacaoCreated);
        }

        public async Task<SolicitacaoDTO> GetSolicitacaoById(int id)
        {
            var solicitacao = await _solicitacaoRepository.GetById(id);
            return _mapper.Map<SolicitacaoDTO>(solicitacao);
        }

        public async Task<SolicitacaoDTO> UpdateSolicitacao(int id, SolicitacaoDTO solicitacaoDTO)
        {

            var solicitacao = await _solicitacaoRepository.GetById(id);
            solicitacao = _mapper.Map(solicitacaoDTO, solicitacao);
            var solicitacaoUpdated = await _solicitacaoRepository.Update(solicitacao);
            return _mapper.Map<SolicitacaoDTO>(solicitacaoUpdated);
        }

        public async Task DeleteSolicitacao(int id)
        {
            await _solicitacaoRepository.Delete(id);
        }
    }
}