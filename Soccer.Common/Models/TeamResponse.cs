namespace Soccer.Common.Models
{
    public class TeamResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LogoPath { get; set; }

        public string LogoFullPath => string.IsNullOrEmpty(LogoPath)
                            ? "https://soccerwebcarolinalopera.azurewebsites.net//images/noimage.png"
                            : $"https://soccerwebcarolinalopera.azurewebsites.net{LogoPath.Substring(1)}";
    }
}

