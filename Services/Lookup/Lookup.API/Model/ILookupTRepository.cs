using lookup.API.Model;
using Lookup.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FADY.Services.Lookup.API.Model
{
    public interface ILookupTRepository
    {
        Task<LookupItems> GetLookupItemAsync(string LookupName,int Code);
        Task<IEnumerable<LookupItems>> GetLookupItems(string LookupName);
        Task<LookupItems> UpdateLookupItemAsync(string LookupName, int Code, string Name);
        Task<bool> DeleteLookupItemAsync(string LookupName, int Code);
    }
}
