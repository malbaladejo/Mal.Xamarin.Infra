namespace Mal.Xamarin.Infra.DevApp.OpenFoodFacts.Services.Data
{
    public class Additive
    {
        public Additive(string code, string name, AdditiveToxicity toxicity)
        {
            Code = code;
            Name = name;
            Toxicity = toxicity;
        }

        public string Code { get; }
        public string Name { get; }
        public AdditiveToxicity Toxicity { get; }
    }
}