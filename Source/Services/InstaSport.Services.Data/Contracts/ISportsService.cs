namespace InstaSport.Services.Data
{
    using System.Linq;

    using InstaSport.Data.Models;

    public interface ISportsService
    {
        IQueryable<Sport> GetAll();

        int GetCount();
    }
}
