namespace Diazzo.SQLite.DBAccess;

public class RoundDatabase
{

    public static async Task Init()
    {
        var Connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        try
        {

/*            await Connection.DropTableAsync<Course>();
            await Connection.DropTableAsync<Disc>();*/

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
        }
        catch (Exception ex)
        {
             throw new Exception(ex.Message);
        }
        finally
        {
            await Connection.CloseAsync();
        }
    }

    private static async Task<string> ReadResourceFile(string resourceName)
    {

        var Connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        try
        {
            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(resourceName);
            using StreamReader reader = new(fileStream);
            return await reader.ReadToEndAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            await Connection.CloseAsync();
        }
    }

    public static async Task<List<Round>>? GetRoundsAsync()
    {
        var Connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        try
        {
            var result = await Connection!.Table<Round>().Where(x => x.IsDeleted == false).OrderByDescending(x => x.RoundDate).ToListAsync();
            await Connection.CloseAsync();
            if (result.Count > 0)
            {
                return result;
            }
            return null!;
        }
        catch(Exception ex)
        {
            throw new Exception (ex.Message);
        }
        finally
        {
            await Connection.CloseAsync(); 
        }
    }

    public static async Task<List<Course>>? GetCoursesAsync()
    {
        var Connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        try
        {
            var result = await Connection!.Table<Course>().Where(x => x.IsDeleted == false).ToListAsync();
            await Connection.CloseAsync();
            if (result.Count > 0)
            {
                return result;
            }
            return null!;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            await Connection.CloseAsync();
        }
    }

    public static async Task<Round> GetRoundAsync(int id)
    {
        var Connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        try
        {
            var round = await Connection!.Table<Round>().Where(i => i.Id == id).FirstOrDefaultAsync();
            await Connection.CloseAsync();
            return round;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            await Connection.CloseAsync();
        }
    }

    //make this generic
    public static async Task<int> SaveItemAsync(Round item)
    {
        var Connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        try
        {
            int result;
            if (item.Id != 0)
            {
                result = await Connection!.UpdateAsync(item);
            }
            else
            {
                result = await Connection!.InsertAsync(item);
            }
            await Connection.CloseAsync();
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            await Connection.CloseAsync();
        }
    }

    public static async Task<int> DeleteItemAsync(Round item)
    {
        var Connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        return await Connection!.DeleteAsync(item);
    }
}
