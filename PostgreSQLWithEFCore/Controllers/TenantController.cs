using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostgreSQLWithEFCore.Entities;

namespace PostgreSQLWithEFCore.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TenantController : ControllerBase
    {
        private readonly DatabaseContext databaseContext;
        private static readonly string[] entity = ["Tag1", "Tag2"];

        public TenantController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await databaseContext.Users.AddAsync(new User
            {
                Email = "test@gmail.com",
                FirstName = "ss",
                LastName = "sss",
                Address = new Address
                {
                    City = "sss"
                },
                Tags = entity
            });

            await databaseContext.SaveChangesAsync();

            return Ok(databaseContext.Users);
        }

        [HttpGet("search-user")]
        public async Task<IActionResult> SearchUser([FromQuery] string searchTerm)
        {
            var users = await databaseContext.Users.Where(x => x.SearchVector.Matches(searchTerm)).Take(10)
                .Select(x => new
                {
                    x.FirstName,
                    x.Email,
                    x.Description,
                    x.Metadata
                })
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet("generate-users")]
        public async Task<IActionResult> GenerateUses()
        {
            var addressFaker = new Faker<Address>()
                                  .RuleFor(a => a.City, f => f.Address.City());

            var userFaker = new Faker<User>()
                            .RuleFor(u => u.UserName, f => f.Internet.UserName())
                            .RuleFor(u => u.Email, f => f.Internet.Email())
                            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                            .RuleFor(u => u.LastName, f => f.Name.LastName())
                            .RuleFor(u => u.Address, f => addressFaker.Generate())
                            .RuleFor(u => u.Tags, f => f.Lorem.Words(3).ToArray())
                            .RuleFor(u => u.Description, f => f.Lorem.Sentence())
                            .RuleFor(u => u.Metadata, f => f.Lorem.Paragraph());

            for (int i = 0; i < 1000000; i++)
            {
                var users = userFaker.Generate(100000);

                await databaseContext.AddRangeAsync(users);

                await databaseContext.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
