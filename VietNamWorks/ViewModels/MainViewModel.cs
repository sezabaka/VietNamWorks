using System.Collections.Generic;
using System.Linq;
using VietNamWorks.Data;
using VietNamWorks.Data.Models;
using VietNamWorks.Services;

namespace VietNamWorks.ViewModels
{
    public class MainViewModel
    {
        private readonly IGetJobService _getJobService;
        private readonly JobContext _context;
        public MainViewModel(IGetJobService getJobService, JobContext context)
        {
            _getJobService = getJobService;
            _context = context;

            _context.Database.EnsureCreated();
            var jobs = _getJobService.GetList("");

            foreach (var job in jobs)
            {
                JobLevel jobLevel = new JobLevel { Name = job.jobLevelVI };
                Company company = new Company { Name = job.company };

                if (!_context.JobLevels.Any(x => x.Name == jobLevel.Name))
                {
                    _context.JobLevels.Add(jobLevel);
                }
                else
                {
                    jobLevel.JobLevelId = _context.JobLevels.First(x => x.Name == jobLevel.Name).JobLevelId;
                }

                if (!_context.Companies.Any(x => x.Name == company.Name))
                {
                    _context.Companies.Add(company);
                }
                else
                {
                    company.CompanyId = _context.Companies.First(x => x.Name == company.Name).CompanyId;
                }
                _context.SaveChanges();

                Location location = new Location
                {
                    City = job.locationVIs,
                    Address = job.jobLocations,
                    Lat = job.lat,
                    Lon = job.lon,
                    CompanyId = company.CompanyId
                };

                if (!_context.Locations.Any(x => x.City == location.City && x.Address == location.Address
                     && x.Lat == location.Lat && x.Lon == location.Lon && x.CompanyId == location.CompanyId))
                {
                    _context.Locations.Add(location);
                }
                else
                {
                    location.LocationId = _context.Locations.First(x => x.City == location.City && x.Address == location.Address
                     && x.Lat == location.Lat && x.Lon == location.Lon && x.CompanyId == location.CompanyId).LocationId;
                }

                List<string> skills = job.skills.Split(';').ToList();
                List<Skill> skills1 = new List<Skill>();

                foreach (var skill in skills)
                {
                    Skill skill1 = new Skill { SkillName = skill };
                    if (!_context.Skills.Any(x => x.SkillName == skill1.SkillName))
                    {
                        _context.Skills.Add(skill1);
                    }
                    else
                    {
                        skill1.SkillId = _context.Skills.First(x => x.SkillName == skill1.SkillName).SkillId;
                    }
                    skills1.Add(skill1);
                }
                _context.SaveChanges();
                skills.Sort();

                string jobName = string.Join(";", skills);
                bool hasSkillJob = false;

                SkillJob skillJob = new SkillJob { JobName = jobName };
                if (!_context.SkillJobs.Any(x => x.JobName == skillJob.JobName))
                {
                    _context.SkillJobs.Add(skillJob);
                    hasSkillJob = true;
                }
                else
                {
                    skillJob.SkillJobId = _context.SkillJobs.First(x => x.JobName == skillJob.JobName).SkillJobId;
                }
                _context.SaveChanges();

                if (hasSkillJob)
                {
                    foreach (var skill in skills1)
                    {
                        SkillNeed skillNeed = new SkillNeed
                        {
                            SkillId = skill.SkillId,
                            SkillJobId = skillJob.SkillJobId
                        };
                        _context.SkillNeeds.Add(skillNeed);
                    }
                    _context.SaveChanges();
                }

                JobDetail jobDetail = new JobDetail
                {
                    JobTitle = job.jobTitle,
                    SalaryMin = job.salaryMin,
                    SalaryMax = job.salaryMax,
                    JobLevelId = jobLevel.JobLevelId,
                    LocationId = location.LocationId,
                    SkillJobId = skillJob.SkillJobId
                };

                if (!_context.JobDetails.Any(x => x.JobTitle == jobDetail.JobTitle && x.SalaryMin == jobDetail.SalaryMin
                     && x.SalaryMax == jobDetail.SalaryMax && x.JobLevelId == jobDetail.JobLevelId
                     && x.LocationId == jobDetail.LocationId && x.SkillJobId == jobDetail.SkillJobId))
                {
                    _context.SkillJobs.Add(skillJob);
                }

                _context.SaveChanges();
            }
        }


    }
}
