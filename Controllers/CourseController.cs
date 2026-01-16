using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Service;

namespace StudentPartal.Controllers;
[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;
    public CourseController (ICourseService courseService)
    {
        _courseService = courseService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allProduct = await _courseService.GetAllCourses();
        return Ok(allProduct);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Course course)
    {
        var created = await _courseService.CreateCourse(course);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = created.Id}, created);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        var course = await _courseService.GetCourseById(id);
        if (course == null)
            return NotFound();
        return Ok(course);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCourse([FromBody] Course course)
    {
        var newCourse = await _courseService.UpdateCourse(course);
        return Ok(newCourse);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCourse([FromBody] Course course)
    {
        await _courseService.DeleteCourse(course);
        return Ok("Course deleted successfully.");
    }
    
}