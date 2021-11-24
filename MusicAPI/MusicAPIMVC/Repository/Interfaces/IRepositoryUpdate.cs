namespace MusicAPIMVC.Repository.Interfaces
{
    public interface IRepositoryUpdate<T>
    {
        Task UpdateAsync(T obj);
        void Update(T obj);

    }
}
