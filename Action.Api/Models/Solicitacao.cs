
using Action.Api.Enum;

namespace Action.Api.Models
{
    public class Solicitacao
    {
        public int Id { get; private set; }
        public required string EmailSolicitante { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public DateTime DataSolicitacao { get; private set; } = DateTime.Now;
        public string? Aprovador { get; set; }
        public StatusSolicitacao Status { get; private set; } = StatusSolicitacao.PendenteAprovacao;

        public required ICollection<DataAction> Actions { get; set; }

        protected Solicitacao(ICollection<DataAction> actions, string emailSolicitante)
        {
            if (actions == null || !actions.Any())
                throw new ArgumentException("A solicitação deve conter pelo menos uma Action.");

            Actions = actions;
            EmailSolicitante = emailSolicitante;
        }

        public void Aprovar(string aprovador)
        {
            if (Status != StatusSolicitacao.PendenteAprovacao)
                throw new InvalidOperationException("A solicitação não pode ser aprovada.");

            Aprovador = aprovador;
            Status = StatusSolicitacao.Aprovada;
        }


        public void PublicarSolicitacao()
        {
            if (Status != StatusSolicitacao.Aprovada)
                throw new InvalidOperationException("A solicitação não pode ser publicada.");

            Status = StatusSolicitacao.Publicada;
            DataPublicacao = DateTime.Now;
        }
        public void AdicionarAction(DataAction action)
        {
            if (Actions.Any(a => a.Action == action.Action))
                throw new ArgumentException($"A Action '{action.Action}' já foi adicionada à solicitação.");

            Actions.Add(action);
        }

    }
}