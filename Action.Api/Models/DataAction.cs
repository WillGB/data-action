
namespace Action.Api.Models
{
    public class DataAction
    {
        public int Id { get; private set;}
        public string Action => $"{BusinessChannel}/{Environment}/{Business}/{CustomPath}";
        public string Business { get; private set; }
        public string BusinessChannel { get; private set;}
        public string Environment { get; private set;}
        public string CustomPath { get; private set; }
        public bool GA4 { get; private set; } = true;
        public bool DualTagging { get; private set; } = true;
        public bool InteractionStudio { get; private set; }
        public bool FullStory { get; private set; }

        public DataAction() { }

        protected DataAction(string businessChannel, string environment, string business, string customPath, bool interactionStudio, bool fullStory)
        {
            BusinessChannel = businessChannel;
            Environment = environment;
            Business = business;
            CustomPath = customPath;
            InteractionStudio = interactionStudio;
            FullStory = fullStory;
        }

        //valida se CustomPath tem / no inicio, se tiver, remove
        public void SetCustomPath(string customPath)
        {
            if (customPath.StartsWith("/"))
            {
                CustomPath = customPath.Substring(1);
            }
            else
            {
                CustomPath = customPath;
            }
        }

        public void AtivarInteractionStudio() => InteractionStudio = true;

        public void DesativarInteractionStudio() => InteractionStudio = false;

        public void AtivarFullStory() => FullStory = true;

        public void DesativarFullStory() => FullStory = false;

    }
}