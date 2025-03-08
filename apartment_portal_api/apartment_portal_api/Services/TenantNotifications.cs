using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using apartment_portal_api.DTOs;
using apartment_portal_api.Abstractions;
using apartment_portal_api.Models.Statuses;
using AutoMapper;

namespace apartment_portal_api.Services;

[ApiController]
[Route("api/notifications")]
public class TenantNotifications : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TenantNotifications(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    [Authorize]
    [HttpGet("latest/{userId}")]
    public async Task<ActionResult> GetLatestNotifications(int userId)
    {
        var userUnits = await _unitOfWork.UnitUserRepository.GetAsync(uu => uu.UserId == userId);
        var userUnit = userUnits.FirstOrDefault();
        if (userUnit is null) return NotFound("User is not associated with any units.");
        
        // int userUnitId = userUnit.First().UnitId;
            
        var packageList = await _unitOfWork.PackageRepository.GetAsync(p => p.UnitId == userUnit.UnitId && p.Status.Name == "Arrived");
        var packages = packageList.Select(p => new NotificationDTO
            {
                Type = "Package",
                Message = "You have a new package at the front desk.",
                Date = DateTime.UtcNow
            })
            .ToList();

        var issueList = await _unitOfWork.IssueRepository.GetAsync(i => i.UserId == userId && i.Status.Name != "Resolved");
        var issues = issueList
            .OrderByDescending(i => i.CreatedOn)
            .Select(i => new NotificationDTO
            {
                Type = "Issue",
                Message = $"Issue: {i.Description}",
                Date = i.CreatedOn
            })
            .ToList();
        
        var users = await _unitOfWork.UserRepository.GetAsync(u => u.Id == userId);
        var user = users.FirstOrDefault();

        var leaseNotification = new List<NotificationDTO>();
        if (user != null)
        {
            DateTime leaseExpiration = user.CreatedOn.AddYears(1);
            var daysUntilExpiration = (leaseExpiration - DateTime.UtcNow).TotalDays;
            if (daysUntilExpiration <= 30)
            {
                leaseNotification.Add(new NotificationDTO
                {
                    Type = "Lease",
                    Message = $"Reminder: Your lease expires on {leaseExpiration:MMMM dd, yyyy}.",
                    Date = leaseExpiration
                });
            }
        }
        
        var notifications = packages
            .Concat(issues)
            .Concat(leaseNotification)
            .OrderByDescending(n => n.Date)
            .Take(10) 
            .ToList();

        return Ok(notifications);
    }
}