using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;

    TareasContext dbcontext;

    public HelloWorldController(IHelloWorldService helloWorld, TareasContext db)
    {
        /*
            Recibimos la instancia y la guardamos dentro de la interfaz
        */
        helloWorldService = helloWorld;
        dbcontext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("Createdb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();
        return Ok();
    }
}