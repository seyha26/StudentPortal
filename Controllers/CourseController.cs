using Microsoft.AspNetCore.Mvc;
using StudentPartal.Dto;
using StudentPortal.Models;
using StudentPortal.Service;

namespace StudentPartal.Controllers;
[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;
    private MessageResponse _messageResponse;
    public CourseController (ICourseService courseService)
    {
        _courseService = courseService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _courseService.GetAllCourses());
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Course course)
    {
        try
        {
            _messageResponse = new MessageResponse();
            var created = await _courseService.CreateCourse(course);
            _messageResponse.GetDataSuccess(created);
        } catch(Exception ex)
        {
            _messageResponse.SetErrorMessage(ex.Message);
        }
        return Ok(_messageResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        try
        {
            _messageResponse = new MessageResponse();
            var course = await _courseService.GetCourseById(id);
            _messageResponse.GetDataSuccess(course);
        }
        catch (System.Exception ex)
        {
            _messageResponse.SetErrorMessage(ex.Message);
        }
       
        return Ok(_messageResponse);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCourse([FromBody] Course course)
    {
        await _courseService.UpdateCourse(course);
        return Ok(course);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCourse([FromBody] Course course)
    {
        await _courseService.DeleteCourse(course);
        return Ok("Course deleted successfully.");
    }
    
}