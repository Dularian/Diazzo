namespace Diazzo.SQLite.DBAccess;

public class RoundDatabase
{
    private SQLiteAsyncConnection? Database { get; set; }

    public async Task Init()
    {
        if (Database != null)
        {
            return;
        }

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        await Database.CreateTableAsync<Round>();
    }

    public async Task<List<Round>>? GetRoundsAsync()
    {
        await Init();
        var result = await Database!.Table<Round>().Where(x => x.IsDeleted == false).OrderByDescending(x => x.RoundDate).ToListAsync();
        if (result.Count > 0)
        {
            return result;
        }
        return null!;
    }

    public async Task<Round> GetRoundAsync(int id)
    {
        await Init();
        return await Database!.Table<Round>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(Round item)
    {
        await Init();
        int result;
        if (item.Id != 0)
        {
            result = await Database!.UpdateAsync(item);
        }
        else
        {
            result = await Database!.InsertAsync(item);
        }

        return result;
    }

    public async Task<int> DeleteItemAsync(Round item)
    {
        await Init();
        return await Database!.DeleteAsync(item);
    }
}
