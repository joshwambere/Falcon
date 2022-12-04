using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Searching.Infrastructure.Extensions;

public static class Extensions
{
    public static bool TestConnection(this DbContext context)
    {
        DbConnection conn = context.Database.GetDbConnection();
        
        try
        {
            conn.Open();  
            conn.Close();// Check the database connection

            return true;
        }
        catch
        {
            return false;
        }
    }
}

