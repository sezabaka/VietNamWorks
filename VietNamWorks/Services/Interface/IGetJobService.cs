using System.Collections.Generic;
using VietNamWorks.Entity;

namespace VietNamWorks.Services
{
    public interface IGetJobService
    {
        List<Job> GetList(string path);
    }
}
