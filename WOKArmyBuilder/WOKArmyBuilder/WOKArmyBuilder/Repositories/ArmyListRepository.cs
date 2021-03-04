using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WOKArmyBuilder.Models;
using SQLite;
using System.IO;

namespace WOKArmyBuilder.Repositories
{
    public class ArmyListRepository : IArmyListRepository
    {
        private SQLiteAsyncConnection connection;

        public event EventHandler<ArmyList> OnListAdded;
        public event EventHandler<ArmyList> OnListUpdated;
        public event EventHandler<ArmyList> OnListDeleted;

        public async Task DeleteList(ArmyList list)
        {
            await CreateConnection();
            await connection.DeleteAsync(list);
            OnListDeleted?.Invoke(this, list);
        }

        public async Task<List<ArmyList>> GetArmyLists()
        {
            await CreateConnection();
            return await connection.Table<ArmyList>().ToListAsync();
        }

        public async Task<List<Unit>> GetUnits()
        {
            await CreateConnection();
            return await connection.Table<Unit>().ToListAsync();
        }

        public async Task NewList(ArmyList list)
        {
            await CreateConnection();
            await connection.InsertAsync(list);
            OnListAdded?.Invoke(this, list);
        }

        public async Task UpdateList(ArmyList list)
        {
            await CreateConnection();
            await connection.UpdateAsync(list);
            OnListUpdated?.Invoke(this, list);
        }

        private async Task CreateConnection()
        {
            if (connection != null)
            {
                return;
            }
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var databasePath = Path.Combine(documentPath, "WOKArmyLists.db");

            connection = new SQLiteAsyncConnection(databasePath);
            await connection.CreateTableAsync<ArmyList>();

            if (await connection.Table<ArmyList>().CountAsync() == 0)
            {
                await connection.InsertAsync(new ArmyList()
                {
                    Name = "New Army List",
                    Faction = "Nassier",
                    ArmyPoints = 16,
                    ArmySize = "Intro"
                });
            }

            // must find a way to populate this
            await connection.CreateTableAsync<Unit>();
        }
    }
}
