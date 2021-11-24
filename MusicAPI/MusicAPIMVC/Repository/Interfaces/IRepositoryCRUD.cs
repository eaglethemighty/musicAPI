namespace MusicAPIMVC.Repository.Interfaces
{
    public interface IRepositoryCRUD<T> : IRepositoryCreate<T>, IRepositoryRead<T>, IRepositoryUpdate<T> ,IRepositoryDelete<T>
    {
    }
}
