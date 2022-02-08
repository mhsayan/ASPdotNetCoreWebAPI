using Application.Api.Models;
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
    [HttpGet("{id:guid}", Name = "GetStudent")]
    public async Task<ActionResult<GetStudentModel>> Get(Guid id)
    {
        var model = _scope.Resolve<GetStudentModel>();
        model.Resolve(_scope);

        model.GetStudent(id);

        return Ok(model);
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
    public async Task<IActionResult> Post([FromBody] CreateStudentModel model)
    {
        // model validation 
        if (model == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            // return 422 - Not Processable Entity when validation fails
            return new UnprocessableEntityObjectResult(ModelState);
        }

        model.Resolve(_scope);
        model.CreateStudent();

        //return CreatedAtRoute("GetStudent",
        //    new { id = movieEntity.Id },
        //    _mapper.Map<Models.Movie>(movieEntity));

        return Ok();
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateStudentModel model)
    {
        // model validation 
        if (model == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            // return 422 - Not Processable Entity when validation fails
            return new UnprocessableEntityObjectResult(ModelState);
        }

        model.Resolve(_scope);
        model.UpdateStudent(id);

        //return CreatedAtRoute("GetStudent",
        //    new { id = movieEntity.Id },
        //    _mapper.Map<Models.Movie>(movieEntity));

        return Ok();
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var model = _scope.Resolve<GetStudentModel>();
        model.Resolve(_scope);

        model.DeleteStudent(id);

        return Ok();
    }
}