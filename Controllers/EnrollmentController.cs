using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Service;

namespace StudentPartal.Controllers;

[ApiController]
[Route("api/enrollments")]
public class EnrollmentController : ControllerBase
{
    private readonly IEnrollmentService _enrollmentService;
    public EnrollmentController(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _enrollmentService.GetAllEnrollments());
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var enrollment = await _enrollmentService.GetEnrollmentById(id);
        return Ok(enrollment);
    }

    [HttpGet]
    [Route("student/{id}")]
    public async Task<IActionResult> GetByStudentId(string id)
    {
        var enrollment = await _enrollmentService.GetEnrollmentsByStudentId(id);
        return Ok(enrollment);
    }

    [HttpGet]
    [Route("course/{id}")]
    public async Task<IActionResult> GetByCouseId(string id)
    {
        var enrollment = await _enrollmentService.GetEnrollmentsByCourseId(id);
        return Ok(enrollment);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Enrollment enrollment)
    {
        await _enrollmentService.CreateEnrollment(enrollment);
        return Ok(enrollment);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Enrollment enrollment)
    {
        await _enrollmentService.UpdateEnrollment(enrollment);
        return Ok(enrollment);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] Enrollment enrollment)
    {
        await _enrollmentService.DeleteEnrollment(enrollment);
        return Ok(enrollment);
    }
}