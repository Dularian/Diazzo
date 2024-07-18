namespace Diazzo.SQLite.DBAccess;

public class RoundDatabase
{

    public async Task Init()
    {
        try
        {
            var Connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Connection.CreateTableAsync<Round>();
            
            var courseResult = await Connection.CreateTableAsync<Course>();
            var discResult = await Connection.CreateTableAsync<Disc>();


            if (courseResult == CreateTableResult.Created)
            {
                string courseJson = await ReadResourceFile("courses.json");
                List<Course>? courses = JsonSerializer.Deserialize<List<Course>>(courseJson);
                await Connection.InsertAllAsync(courses);
            }

            if (discResult == CreateTableResult.Created)
            {
                string discJson = await ReadResourceFile("discs.json");
                List<Disc>? discs = JsonSerializer.Deserialize<List<Disc>>(discJson);
                await Connection.InsertAllAsync(discs);
            }

            await Connection.CloseAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private static async Task<string> ReadResourceFile(string resourceName)
    {

        var Connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(resourceName);
        using StreamReader reader = new StreamReader(fileStream);
        return await reader.ReadToEndAsync();
    }

    public async Task<List<Round>>? GetRoundsAsync()
    {
        var Connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Connection!.Table<Round>().Where(x => x.IsDeleted == false).OrderByDescending(x => x.RoundDate).ToListAsync();
        if (result.Count > 0)
        {
            return result;
        }
        return null!;
    }

    public async Task<Round> GetRoundAsync(int id)
    {
        var Connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        return await Connection!.Table<Round>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(Round item)
    {
        var Connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        int result;
        if (item.Id != 0)
        {
            result = await Connection!.UpdateAsync(item);
        }
        else
        {
            result = await Connection!.InsertAsync(item);
        }

        return result;
    }

    public async Task<int> DeleteItemAsync(Round item)
    {
        var Connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        return await Connection!.DeleteAsync(item);
    }
}
