//cria ActionDTO.cs
namespace Action.Api.DTOs
{
    public class DataActionDTO
    {
        public int Id { get; }
        public string Nome { get; set; }
        public string Business { get; set; }
        public string BusinessChannel { get; set;}
        public string Environment { get; set;}
        public string CustomPath { get; set; }
        public bool InteractionStudio { get; set; }
        public bool FullStory { get; set; }
        
    }
}