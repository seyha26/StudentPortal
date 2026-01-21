using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Service;

namespace StudentPartal.Controllers;

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _studentService.GetAllStudents());
    }

    [HttpPost]
    public async Task<IActionResult> Create(Student student)
    {
        var createdStudent = await _studentService.CreateStudent(student);
        return Ok(createdStudent);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetStudentById(string id)
    {
        var student = await _studentService.GetStudentById(id);
        return Ok(student);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Student student)
    {
        _studentService.DeleteStudent(student);
        return Ok(student);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Student student)
    {
        return Ok(await _studentService.UpdateStudent(student));
    }

}