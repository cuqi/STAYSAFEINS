using Insurance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insurance.Models;


namespace Insurance.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Agent.Any() || context.Case.Any() || context.Policy.Any() || context.CascoPolicy.Any() || context.TravelPolicy.Any() || context.HealthPolicy.Any() || context.User.Any())
                {
                    return;
                }

                context.Agent.AddRange(
                    new Agent { /* Id = 1 */ AgentNumber = "00001", FirstName = "Венко", LastName = "Филипче", PolicyCount = 1, BirthDate = DateTime.Parse("1990-1-1"), HireDate = DateTime.Parse("2020-1-1"), ProfilePicture = "" },
                    new Agent { /* Id = 2 */ AgentNumber = "00002", FirstName = "Катица", LastName = "Јанева", PolicyCount = 2, BirthDate = DateTime.Parse("1990-1-2"), HireDate = DateTime.Parse("2020-1-2"), ProfilePicture = "" }
                    );
                context.SaveChanges();

                context.User.AddRange(
                    new User { /* Id = 1 */ FirstName = "Владимир", LastName = "Крстиќ", EMBG = "0812998451234", BirthDate = DateTime.Parse("1998-12-8") },
                    new User { /* Id = 2 */ FirstName = "Ненад", LastName = "Човекот", EMBG = "1903998451234", BirthDate = DateTime.Parse("1998-3-19") }
                    );
                context.SaveChanges();

                context.Case.AddRange(
                   new Case
                   { /* Id = 1 */
                       CaseNumber = "1",
                       Description = "I made an accident, dude!",
                       AccidentDate = DateTime.Parse("2020-5-1"),
                       UserId = 2,
                       Picture = ""
                   },
                   new Case
                   { /* Id = 2 */
                       CaseNumber = "2",
                       Description = "I made an accident, dude!",
                       AccidentDate = DateTime.Parse("2020-5-2"),
                       UserId = 1,
                       Picture = ""
                   }
                   );
                context.SaveChanges();

                context.Policy.AddRange(
                    new Policy
                    { /* Id = 1 */
                        PolicyNumber = "A0001",
                        PolicyType = PolicyType.CascoPolicy,
                        OwnerId = 1,
                        AgentId = 2,
                    },
                    new Policy
                    { /* Id = 2 */
                        PolicyNumber = "A0002",
                        PolicyType = PolicyType.TravelPolicy,
                        OwnerId = 2,
                        AgentId = 1,
                    },
                    new Policy
                    { /* Id = 3 */
                        PolicyNumber = "A0003",
                        PolicyType = PolicyType.HealthPolicy,
                        OwnerId = 2,
                        AgentId = 1,
                    },
                    new Policy
                    { /* Id = 4 */
                        PolicyNumber = "A0004",
                        PolicyType = PolicyType.CascoPolicy,
                        OwnerId = 1,
                        AgentId = 2,
                    },
                    new Policy
                    { /* Id = 5 */
                        PolicyNumber = "A0005",
                        PolicyType = PolicyType.TravelPolicy,
                        OwnerId = 2,
                        AgentId = 1,
                    },
                    new Policy
                    { /* Id = 6 */
                        PolicyNumber = "A0006",
                        PolicyType = PolicyType.HealthPolicy,
                        OwnerId = 2,
                        AgentId = 1,
                    }
                    );
                context.SaveChanges();

                context.CascoPolicy.AddRange(
                    new CascoPolicy
                    {
                        /*Id = 1*/
                        Chassis = "CHA0000000001",
                        Registration = "AA1234BB",
                        Power = 50,
                        Volume = 1000,
                        Premium = 200,
                        VehicleColor = "црвена",
                        AgreeDate = DateTime.Parse("2020-2-1"),
                        PolicyId = 1
                    },
                    new CascoPolicy
                    {
                        /*Id = 2*/
                        Chassis = "CHA0000000002",
                        Registration = "AA1234BB",
                        Power = 100,
                        Volume = 1500,
                        Premium = 400,
                        VehicleColor = "сина",
                        AgreeDate = DateTime.Parse("2020-2-2"),
                        PolicyId = 4
                    }
                    );
                context.SaveChanges();

                context.TravelPolicy.AddRange(
                    new TravelPolicy
                    {
                        /*Id = 1*/
                        TypeTravel = "Classic",
                        DayCount = 30,
                        Premium = 100,
                        AgreeDate = DateTime.Parse("2020-2-1"),
                        InsuredId = 1,
                        PolicyId = 2
                    },
                    new TravelPolicy
                    {
                        /*Id = 2*/
                        TypeTravel = "Visa",
                        DayCount = 5,
                        Premium = 100,
                        AgreeDate = DateTime.Parse("2020-2-1"),
                        InsuredId = 1,
                        PolicyId = 3
                    },
                    new TravelPolicy
                    {
                        /*Id = 3*/
                        TypeTravel = "Visa Plus",
                        DayCount = 60,
                        Premium = 300,
                        AgreeDate = DateTime.Parse("2020-2-3"),
                        InsuredId = 1,
                        PolicyId = 5
                    }
                    );
                context.SaveChanges();

                context.HealthPolicy.AddRange(
                    new HealthPolicy
                    {
                        /*Id = 1*/
                        TypeHealth = "A",
                        Premium = 100,
                        AgreeDate = DateTime.Parse("2020-2-1"),
                        InsuredId = 2,
                        PolicyId = 3
                    },
                    new HealthPolicy
                    {
                        /*Id = 2*/
                        TypeHealth = "B",
                        Premium = 200,
                        AgreeDate = DateTime.Parse("2020-2-1"),
                        InsuredId = 2,
                        PolicyId = 6
                    }
                    );
                context.SaveChanges();


            }
        }
    }
}
