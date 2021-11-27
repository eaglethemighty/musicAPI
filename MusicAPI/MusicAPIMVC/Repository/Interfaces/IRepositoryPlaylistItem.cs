using MusicAPIMVC.Models;

namespace MusicAPIMVC.Repository.Interfaces
{
    public interface IRepositoryPlaylistItem : IRepositoryCreate<PlaylistItem>, IRepositoryRead<PlaylistItem>, IRepositoryDelete<PlaylistItem>
    {
    }
}
