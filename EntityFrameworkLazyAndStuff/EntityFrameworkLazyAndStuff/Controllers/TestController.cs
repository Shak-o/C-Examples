using EntityFrameworkLazyAndStuff.Infrastructure.Context;
using EntityFrameworkLazyAndStuff.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLazyAndStuff.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly LocalDbContext _context;

        public TestController(LocalDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllMaTests")]
        public async Task<List<MaTestModel>> GetAllAsync()
        {
            var result = await _context.MaTestModels.ToListAsync();
            return result;
        }

        [HttpGet("GetAllOtherTests")]
        public async Task<List<OtherTestModel>> GetAllOtherTestAsync()
        {
            return await _context.OtherTestModels.Include(x => x.MaTest).ToListAsync();
        }

        [HttpPost("MaTest")]
        public async Task AddMaTestModel(MaTestModel model)
        {
            _context.MaTestModels.Add(model);
            await _context.SaveChangesAsync();
        }

        [HttpPost("OtherTest")]
        public async Task AddOtherTest(OtherTestModel model)
        {
            _context.OtherTestModels.Add(model);
            await _context.SaveChangesAsync();
        }

        [HttpGet("Testt")]
        public async Task Nothing()
        {
            var result = await _context.OtherTestModels.Include(x => x.MaTest).Where(x => x.Name == "bb").FirstAsync();
            var something = "";
            var test = result.MaTest;
        }

        [HttpGet("ThirdTestt")]
        public async Task NothingThird()
        {
            var result = await _context.ThirdTestModels.Include(x => x.MaTestModel).Where(x => x.Name == "bb").FirstAsync();
            var something = "";
            var test = result.MaTestModel;
        }

    }
}
