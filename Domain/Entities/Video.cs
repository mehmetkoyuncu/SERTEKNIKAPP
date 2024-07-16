using NArchitecture.Core.Persistence.Repositories;


namespace Domain.Entities;
public class Video : Entity<int> //Videolar Kısmı
{
    public Video()
    {
        VideoUrl = string.Empty;
        VideoType = string.Empty;
    }

    public Video(string videoUrl, string videoType)
    {
        VideoUrl = videoUrl;
        VideoType = videoType;
    }

    public string VideoUrl { get; set; }
    public string VideoType { get; set; }
}
