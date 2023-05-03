using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BioBooker.WebApi.Ctl.Controllers;

public class IdentityController : ControllerBase
{
    [Route("identity")]
    [Authorize]
    public IActionResult Get()
    {
        return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
    }



    











}
