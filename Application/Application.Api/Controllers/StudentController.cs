using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace Application.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly ILifetimeScope _scope;
    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger, ILifetimeScope scope)
    {
        _logger = logger;
        _scope = scope;
    }
    
    // // GET: api/<ValuesController>
    // [HttpGet]
    // public object Get()
    // {
    //     var dataTablesModel = new DataTablesAjaxRequestModel(Request);
    //         
    //     var model = new CourseListModel();
    //     model.ResolveDependency(_scope);
    //         
    //     var data = model.GetCourses(dataTablesModel);
    //     return data;
    // }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // [HttpGet("GetData")]
    // public object GetData()
    // {
    //     var model = new CourseListModel();
    //     model.ResolveDependency(_scope);
    //     return model.GetCourses();
    // }

    // POST api/<ValuesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {

    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
            
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}