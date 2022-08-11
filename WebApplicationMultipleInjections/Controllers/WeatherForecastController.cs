using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMultipleInjections.Controllers;

[ApiController, Route("movies")]
public class GetMovieQueryHandler : ControllerBase
{
    [HttpGet(Name = "movies")]
    public IActionResult Get(IEnumerable<IService> _services) => Ok(new
    {
        resp1 = _services.ElementAt(0).DoSomething(),
        resp2 = _services.ElementAt(1).DoSomething(),
        count = _services.Count()
    });
}