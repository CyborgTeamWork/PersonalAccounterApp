using System;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Windows.Storage;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;

namespace PersonalAccounter.Models
{
    public class DbContext
    {

        public DbContext()
        {
            this.InitAsync();
        }

        public SQLiteAsyncConnection GetDbConnectionAsync()
        {
            var dbFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "accounterDb.sqlite");

            var connectionFactory =
                new Func<SQLiteConnectionWithLock>(
                    () =>
                    new SQLiteConnectionWithLock(
                        new SQLitePlatformWinRT(),
                        new SQLiteConnectionString(dbFilePath, storeDateTimeAsTicks: false)));

            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);

            return asyncConnection;
        }

        public async void InitAsync()
        {
            var connection = this.GetDbConnectionAsync();
            await connection.CreateTablesAsync<User, Expense, Wishlist>();
        }
    }
}
