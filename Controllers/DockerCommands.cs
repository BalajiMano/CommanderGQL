using BenchmarkDotNet.Attributes;
using CommanderGQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace   CommanderGQL.Controllers
{
    [ApiController]
    [Route("/[Controller]")]
    public class DockerCommandsController : ControllerBase
    {
        private ICommands _commandsservice;

    public DockerCommandsController(ICommands commands)
    {
        _commandsservice=commands;
    }
      
      [Benchmark(Baseline=true)]
      [HttpGet("/Query")]
      public ActionResult<IEnumerable<Platform>> GetQueryCommands()
      {
        var CommandsList=_commandsservice.GetCommands().Count();


          return Ok(CommandsList);
      } 

       
      [Benchmark(Baseline=true)]
      [HttpGet("/Enum")]
      public ActionResult<IQueryable<Platform>> GetEnumCommands()
      {
        var CommandsList=_commandsservice.GetCommands().Count();


          return Ok(CommandsList);
      } 

      
      [HttpGet("/Add")]
      public ActionResult<string> AddCommands()
      {
        List<Platform>? Listplatform=new();
       Random random=new();
        Parallel.For(5, 1000,(i)=>{
       Listplatform.Add(new Platform(){Id=i,  Name="Docker", LicenseKey="862528"});}
       );
       _commandsservice.AddCommands(Listplatform);
       _commandsservice.SaveChanges();
        return Ok();
        }

         
      } 
}
