using Microsoft.AspNetCore.Mvc;
using UserApiBL;
using UserApiDAL;

namespace UserWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        // GET: api/<UserController>
       [HttpGet("getAllCandidates")]
        public async Task<ActionResult<List<Candidates>>>? GetAll()
        {
            var res = await userBL.GetAll();
            return res;
        }
        [HttpGet("getAllLanguagess")]
        public async Task<ActionResult<List<Language>>>? GetAllLanguages()
        {
            var res = await userBL.GetAllLanguages();
            return res;
        }
        //// POST api/<UserController>

        [HttpPost("insertCandidates")]
        public async Task<ActionResult<bool>>? InsertAll([FromBody] Candidates value)
        {
            var res = await userBL.insertCandidates(value);
            return res;
        }
        [HttpPost("insertLanguage")]
        public async Task<ActionResult<bool>>? InsertLanguage([FromBody] Language value)
        {
            var res = await userBL.insertLanguage(value);
            return res;
        }



    }
}
