using System.Data.Common;

namespace Repo.UnitOfWork
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Lấy connection
        /// </summary>
        public DbConnection GetConnection(string cnnString = null);

        /// <summary>
        /// Tạo ra connection mới
        /// </summary>
        /// <returns></returns>
        public DbConnection CreateNewConnection(string cnn = null);

        /// <summary>
        /// Mở transaction
        /// </summary>
        /// <returns></returns>
        public DbTransaction BeginTransation();

        /// <summary>
        /// Mở transaction
        /// </summary>
        /// <returns></returns>
        public Task<DbTransaction> BeginTransationAsync();

        /// <summary>
        /// Rollback lại
        /// </summary>
        /// <returns></returns>
        public void RollBack();

        /// <summary>
        /// Rollback lại
        /// </summary>
        /// <returns></returns>
        public Task RollBackAsync();

        /// <summary>
        /// Commit
        /// </summary>
        public void Commit();

        /// <summary>
        /// Commit
        /// </summary>
        public Task CommitAsync();

        /// <summary>
        /// Đóng connection
        /// </summary>
        public void Close();

        /// <summary>
        /// Đóng connection
        /// </summary>
        public Task CloseAsync();

        /// <summary>
        /// Mở connection
        /// </summary>
        public void Open();

        /// <summary>
        /// Mở connection
        /// </summary>
        public Task OpenAsync();

        /// <summary>
        /// Hủy connection
        /// </summary>
        public void DisposeConnection();

        /// <summary>
        /// Hủy connection
        /// </summary>
        public Task DisposeConnectionAsync();

        /// <summary>
        /// Lấy transaction hiện tại
        /// </summary>
        /// <returns></returns>
        public DbTransaction? GetTransaction();

        /// <summary>
        /// build connection string
        /// </summary>
        /// <param name="dbSave"></param>
        /// <returns></returns>
        public string BuildCnnString(string dbSave);
    }
}
