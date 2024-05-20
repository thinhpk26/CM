using MySqlConnector;
using System.Data.Common;

namespace Repo.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _config;
        private readonly string _cnnstring;
        public UnitOfWork(IConfiguration config)
        {
            _config = config;
            _cnnstring = _config.GetConnectionString("Mysql")!;
        }
        private DbConnection? Cnn;
        private DbTransaction? Tran;

        public void DisposeConnection()
        {
            Cnn?.Dispose();
        }

        public DbConnection GetConnection(string cnnString = null)
        {
            if(cnnString != null)
            {
                Cnn = new MySqlConnection(cnnString);
            }
            if (Cnn == null)
            {
                Cnn = new MySqlConnection(cnnString ?? _cnnstring);
            }
            return Cnn;
        }

        public DbTransaction? BeginTransation()
        {
            Tran = Cnn?.BeginTransaction();
            return Tran;
        }

        public void Commit()
        {
            Tran?.Commit();
            Tran?.Dispose();
            Tran = null;
        }

        public void Close()
        {
            Cnn?.Close();
        }

        public void Open()
        {
            Cnn?.Open();
        }

        public async Task<DbTransaction> BeginTransationAsync()
        {
            if(Cnn != null)
            {
                Tran = null;
                Tran = await Cnn.BeginTransactionAsync();
            }
            return Tran; 
        }

        public async Task CommitAsync()
        {
            if(Tran != null)
            {
                await Tran.CommitAsync();
                await Tran.DisposeAsync();
                Tran = null;
            }
        }

        public async Task CloseAsync()
        {
            if(Cnn != null)
            {
                await Cnn.CloseAsync();
            }
        }

        public async Task OpenAsync()
        {
            if(Cnn != null)
            {
                await Cnn.OpenAsync();
                return;
            }
            Cnn = new MySqlConnection(_cnnstring);
            await Cnn.OpenAsync();
        }

        public async Task DisposeConnectionAsync()
        {
            if(Cnn != null)
            {
                await Cnn.DisposeAsync();
            }
        }

        public DbTransaction? GetTransaction()
        {
            return Tran;
        }

        public void RollBack()
        {
            Tran?.Rollback();
            Tran?.Dispose();
            Tran = null;
        }

        public async Task RollBackAsync()
        {
            if(Tran != null)
            {
                await Tran.RollbackAsync();
                await Tran.DisposeAsync();
                Tran = null;
            }
        }

        public DbConnection CreateNewConnection(string cnn = null)
        {
            if(cnn == null)
            {
                return new MySqlConnection(_cnnstring);
            }
            return new MySqlConnection(cnn);
        }

        public string BuildCnnString(string dbSave)
        {
            return $"server=127.0.0.1;port=3306;database={dbSave};uid=nvthinh1;password=Thinh&thinhhj1;Allow User Variables=True";
        }
    }
}
