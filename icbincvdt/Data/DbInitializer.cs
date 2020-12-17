using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using icbincvdt.Data;
using icbincvdt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace icbincvdt.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context, UserManager<ApplicationUser> um, bool development)
        {
            // Run migrations if we're not in development mode
            if (!development)
            {
                context.Database.Migrate();
                return;
            }
            
            // If we are in development mode the code below is run.
            
            context.Database.EnsureDeleted(); // For debugging, comment out before deployment.
            
            context.Database.EnsureCreated();

            // Check if there are any CVs
            if (context.Users.Any())
            {
                Console.Write("DB already seeded. \n");
                return; // DB has been seeded
            }

            // User Initialization
            var usr0 = new ApplicationUser
            {
                UserName = "ola@uia.no",
                Email = "ola@uia.no",
                EmailConfirmed = true
            };
            um.CreateAsync(usr0, "Password1.").Wait();
            
            var usr1 = new ApplicationUser
            {
                UserName = "kari@uia.no",
                Email = "kari@uia.no",
                EmailConfirmed = true
            };
            um.CreateAsync(usr1, "Password1.").Wait();
            
            var usr2 = new ApplicationUser
            {
                UserName = "per@uia.no",
                Email = "per@uia.no",
                EmailConfirmed = true
            };
            um.CreateAsync(usr2, "Password1.").Wait();
            
            var usr3 = new ApplicationUser
            {
                UserName = "knut@uia.no",
                Email = "knut@uia.no",
                EmailConfirmed = true
            };
            um.CreateAsync(usr3, "Password1.").Wait();

            context.SaveChanges();

            /*string getUsersAsync(UserManager<ApplicationUser> um)
            {
                var userList = um.Users.ToListAsync();
                var userOne = userList.ToString();

                return userOne;
            }

            var userList = um.Users.ToList();
            var userOne = userList.ToString();
            userList.ForEach(i => Console.Write("{0}\t", i));*/
            /*var userOneId = userOne;
            Console.Write("userOne: \n");
            Console.Write(userOne[0]);
            Console.Write("\n");*/

            /*async Task<List<ApplicationUser>> GetUserAsync()
            {
                using (um)
                {
                    return await um.Users.ToListAsync();
                }
            }
            
            var userIdList = GetUserAsync();
            userIdList[0];
            

            Console.Write(".");*/
            
            // CV Initialization
            var cvs = new CV[]
            {
                new CV {Summary = "Little School, lotsa experience."},
                new CV {Summary = "ICT Major doing Random Stuff for fun."},
                new CV {Summary = "My life is school and so should yours be."},
                new CV {Summary = "I'm empty on the inside."}
            };
            
            context.CVs.AddRange(cvs);
            context.SaveChanges();

            // Education Initialization
            var educations = new Education[]
            {
                new Education
                {
                    CVID = 1,
                    EducationTitle = "High School Gumbary",
                    EducationText = "studiespess",
                    EducationDateBegin = DateTime.Parse("2010-01-02"),
                    EducationDateEnd = DateTime.Parse("2011-02-03")
                },
                new Education
                {
                    CVID = 2,
                    EducationTitle = "High School Lwow",
                    EducationText = "General Education",
                    EducationDateBegin = DateTime.Parse("2012-03-04"),
                    EducationDateEnd = DateTime.Parse("2013-04-05")
                },
                new Education
                {
                    CVID = 2,
                    EducationTitle = "University of Agder",
                    EducationText = "Doctorate of ICT",
                    EducationDateBegin = DateTime.Parse("2010-08-05"),
                    EducationDateEnd = DateTime.Parse("2017-07-01")
                },
                new Education
                {
                    CVID = 3,
                    EducationTitle = "Gressex High School",
                    EducationText = "STEM Focus",
                    EducationDateBegin = DateTime.Parse("2014-05-06"),
                    EducationDateEnd = DateTime.Parse("2015-06-07")
                },
                new Education
                {
                    CVID = 3,
                    EducationTitle = "University of Eire",
                    EducationText = "Master in GB Studies",
                    EducationDateBegin = DateTime.Parse("2016-07-08"),
                    EducationDateEnd = DateTime.Parse("2017-08-09")
                },
                new Education
                {
                    CVID = 3,
                    EducationTitle = "University of McRudough",
                    EducationText = "Phd. in BE Studies",
                    EducationDateBegin = DateTime.Parse("2018-09-10"),
                    EducationDateEnd = DateTime.Parse("2019-10-11")
                }
            };
            
            context.Educations.AddRange(educations);
            context.SaveChanges();

            // Experience Initialization
            var experiences = new Experience[]
            {
                new Experience
                {
                    CVID = 1,
                    ExperienceTitle = "Janitor",
                    ExperienceText = "Janitorial Services ASA",
                    ExperienceDateBegin = DateTime.Parse("2011-02-04"),
                    ExperienceDateEnd = DateTime.Parse("2013-06-15")
                },
                new Experience
                {
                    CVID = 1,
                    ExperienceTitle = "Receptionist",
                    ExperienceText = "RecptCo",
                    ExperienceDateBegin = DateTime.Parse("2013-05-25"),
                    ExperienceDateEnd = DateTime.Parse("2017-03-12")
                },
                new Experience
                {
                    CVID = 1,
                    ExperienceTitle = "Manager",
                    ExperienceText = "Vitue Valaris Ghmb.",
                    ExperienceDateBegin = DateTime.Parse("2017-03-12"),
                    ExperienceDateEnd = DateTime.Parse("2020-12-12")
                },
                new Experience
                {
                    CVID = 2,
                    ExperienceTitle = "Programmer",
                    ExperienceText = "Pear Inc",
                    ExperienceDateBegin = DateTime.Parse("2015-06-07"),
                    ExperienceDateEnd = DateTime.Parse("2020-12-12")
                },
                new Experience
                {
                    CVID = 3,
                    ExperienceTitle = "Teacher Assistant",
                    ExperienceText = "Univeristy of Eire",
                    ExperienceDateBegin = DateTime.Parse("2016-08-05"),
                    ExperienceDateEnd = DateTime.Parse("2017-02-01")
                }
            };
            
            context.Experiences.AddRange(experiences);
            context.SaveChanges();

            // Skill Initialitzation
            var skills = new Skill[]
            {
                new Skill
                {
                    CVID = 1,
                    SkillTitle = "Intelligence",
                    SkillText = "int",
                    SkillRating = 67
                },
                new Skill
                {
                    CVID = 1,
                    SkillTitle = "Social",
                    SkillText = "soc",
                    SkillRating = 53
                },
                new Skill
                {
                    CVID = 1,
                    SkillTitle = "Perception",
                    SkillText = "per",
                    SkillRating = 87
                },
                new Skill
                {
                    CVID = 2,
                    SkillTitle = "Luck",
                    SkillText = "",
                    SkillRating = 1
                },
                new Skill
                {
                    CVID = 2,
                    SkillTitle = "Strength",
                    SkillText = "",
                    SkillRating = 87
                },
                new Skill
                {
                    CVID = 2,
                    SkillTitle = "Cunning",
                    SkillText = "",
                    SkillRating = 49
                },
                new Skill
                {
                    CVID = 3,
                    SkillTitle = "Endurance",
                    SkillText = "",
                    SkillRating = 19
                },
                new Skill
                {
                    CVID = 3,
                    SkillTitle = "Charisma",
                    SkillText = "",
                    SkillRating = 5
                },
                new Skill
                {
                    CVID = 3,
                    SkillTitle = "Agility",
                    SkillText = "",
                    SkillRating = 84
                },
                new Skill
                {
                    CVID = 4,
                    SkillTitle = "Cool",
                    SkillText = "",
                    SkillRating = 69
                }
            };
            
            context.Skills.AddRange(skills);
            context.SaveChanges();

            // Reference Initialitzation
            var references = new Reference[]
            {
                new Reference
                {
                    CVID = 1,
                    ReferenceName = "Sarah Cullin with Janitorial Services ASA",
                    ReferencePhoneNumber = 04873920
                },
                new Reference
                {
                    CVID = 1,
                    ReferenceName = "CEO Roger DeBares with Vitue Valaris Ghmb.",
                    ReferencePhoneNumber = 85029610
                },
                new Reference
                {
                    CVID = 2,
                    ReferenceName = "Jack Pear with Pear Inc",
                    ReferencePhoneNumber = 92091265
                },
                new Reference
                {
                    CVID = 3,
                    ReferenceName = "Prof. Brendan O'Connor",
                    ReferencePhoneNumber = 89909192
                },
                new Reference
                {
                    CVID = 4,
                    ReferenceName = "Christopher Kulenheim",
                    ReferencePhoneNumber = 56116367
                },
            };
            
            context.References.AddRange(references);
            context.SaveChanges();
            
            Console.Write("DB seeded! \n");
        }
    }
}