namespace VietNamWorks.Entity
{
    public class Job
    {
        public string jobTitle { get; set; }
        public int salaryMin { get; set; }
        public int salaryMax { get; set; }
        public string company { get; set; }
        public string skills { get; set; }
        public string jobLevelVI { get; set; }
        public string locationVIs { get; set; }
        public string jobLocations { get; set; }
        public double distance { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }

        public Job(Hit hit)
        {
            jobTitle = hit.jobTitle;
            salaryMin = hit.salaryMin;
            salaryMax = hit.salaryMax;
            company = hit.company;
            skills = string.Join(";", hit.skills);
            jobLevelVI = hit.jobLevelVI;
            locationVIs = string.Join(";", hit.locationVIs);
            jobLocations = string.Join(";", hit.jobLocations);
            distance = 0;
            lat = hit._geoloc.lat;
            lon = hit._geoloc.lng;
        }
    }
}
