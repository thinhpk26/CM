namespace Repo.Entities
{
    public interface IEntityFactory
    {
        /// <summary>
        /// Tạo ra entity tương ứng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T CreateEntity<T>() where T : BaseEntity;
    }
}
