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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Enrollment enrollment)
    {
        var createdEnrollment = _enrollmentService.CreateEnrollment(enrollment);
        return Ok(enrollment);
    }
}