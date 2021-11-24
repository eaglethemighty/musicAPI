namespace MusicAPIMVC.Repository.Interfaces
{
    public interface IRepositoryCreate<T>
    {
        public Task AddAsync(T obj);
        public void Add(T obj);
    }
}
