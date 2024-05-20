namespace Repo.Entities
{
    public class EntityFactory : IEntityFactory
    {
        public HttpContextAccessor HttpContextAccessor;
        public EntityFactory(HttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public T CreateEntity<T>() where T : BaseEntity
        {
            throw new NotImplementedException();
        }
        //public T CreateEntity<T>() where T : BaseEntity
        //{
        //    var language  = HttpContextAccessor.HttpContext?.Request.Headers["Accept-Language"];
        //}
    }
}
