//cria Solicitacao.DTO.cs

using Action.Api.Enum;

namespace Action.Api.DTOs
{
    public class SolicitacaoDTO
    {
        public int Id { get; set; }
        public required string EmailSolicitante { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string Status { get; set; }
        public required string Aprovador { get; set; }
        public ICollection<DataActionDTO> Actions { get; set; }
    }
}