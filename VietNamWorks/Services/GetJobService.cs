using System.Collections.Generic;
using System.IO;
using VietNamWorks.Entity;

namespace VietNamWorks.Services
{
    public class GetJobService : IGetJobService
    {
        public List<Job> GetList(string path)
        {
            List<Job> jobs = new List<Job>();
            Root root = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(File.ReadAllText(path));
            var results = root.results;

            foreach (var res in results)
            {
                var hits = res.hits;
                foreach (var hit in hits)
                {
                    jobs.Add(new Job(hit));
                }
            }

            return jobs;
        }
    }
}
