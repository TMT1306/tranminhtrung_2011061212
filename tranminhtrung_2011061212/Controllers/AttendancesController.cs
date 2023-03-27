using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tranminhtrung_2011061212.DTOs;
using tranminhtrung_2011061212.Models;

namespace tranminhtrung_2011061212.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        public ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if(_dbContext.attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId)) {
                return BadRequest("The Attendance already exists!");
            }
            var attendance = new Attendance() 
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = userId
            };
            _dbContext.attendances.Add(attendance);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
