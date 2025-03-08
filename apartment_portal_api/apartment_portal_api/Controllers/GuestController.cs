using apartment_portal_api.Abstractions;
using apartment_portal_api.Models;
using apartment_portal_api.Models.Users;
using apartment_portal_api.DTOs;
using apartment_portal_api.Models.Guests;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace apartment_portal_api.Controllers;

[ApiController]
[Route("[controller]")]
public class GuestController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GuestController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GuestDTO>> GetGuestById(int id)
    {
        
        var guest = await _unitOfWork.GuestRepository.GetAsync(id);
        
        if (guest == null)
            return NotFound();

       var guestDTO = _mapper.Map<GuestDTO>(guest);
        return Ok(guestDTO);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GuestDTO>>> GetGuests()
    {
        var guests = await _unitOfWork.GuestRepository.GetAsync();
        
        var guestDTOs = _mapper.Map<IEnumerable<GuestDTO>>(guests);
        return Ok(guestDTOs);
    }

    [HttpPost("register-guest")]
    public async Task<ActionResult<GuestDTO>> CreateGuest(GuestCreateDTO request)
    {
        
        var newGuest = _mapper.Map<Guest>(request);
        newGuest.CreatedOn = DateTime.UtcNow;

        
        await _unitOfWork.GuestRepository.AddAsync(newGuest);
        await _unitOfWork.SaveAsync();

        
        var guestDTO = _mapper.Map<GuestDTO>(newGuest);
        
        return CreatedAtAction(nameof(GetGuestById), new { id = newGuest.Id }, guestDTO);
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<GuestDTO>> EditGuest(int id, GuestPatchDTO patchData)
    {
        if (id != patchData.Id) return BadRequest();

        var guestToPatch = await _unitOfWork.GuestRepository.GetAsync(id);
        if (guestToPatch is null) return NotFound();

        _mapper.Map(patchData, guestToPatch);
        await _unitOfWork.SaveAsync();

        var editedGuestDTO = _mapper.Map<GuestDTO>(guestToPatch);
        return Ok(editedGuestDTO);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<GuestDTO>> UpdateGuest(int id, GuestDTO putData)
    {
        if (id != putData.Id) return BadRequest();

        var guestToUpdate = await _unitOfWork.GuestRepository.GetAsync(id);
        if (guestToUpdate is null) return NotFound();

        _mapper.Map(putData, guestToUpdate);
        await _unitOfWork.SaveAsync();

        var updatedGuestDTO = _mapper.Map<GuestDTO>(guestToUpdate);
        return Ok(guestToUpdate);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<GuestDTO>> DeleteGuest(int id)
    {
        var guestToDelete = await _unitOfWork.GuestRepository.GetAsync(id);
        if (guestToDelete is null) return NotFound();

        _unitOfWork.GuestRepository.Delete(guestToDelete);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id:int}/parking-permits")]
    public async Task<ActionResult<ParkingPermitDTO>> GetGuestParkingPermits(int id)
    {
        var guests = await _unitOfWork.GuestRepository.GetAsync(p => p.Id == id, includeProperties: nameof(Guest.ParkingPermits));
        var guest = guests.FirstOrDefault();
        if (guest is null) return NotFound();
    
        var permitDTOs = _mapper.Map<IEnumerable<ParkingPermitDTO>>(guest.ParkingPermits);

        return Ok(permitDTOs);
    }

    [HttpPatch("{id:int}/parking-permits/{permitId:int}")]
    public async Task<ActionResult<ParkingPermitDTO>> EditGuestParkingPermits(int id, ParkingPermitPatchDTO patchData)
    {
        if (id != patchData.Id) return BadRequest();

        var parkingPermitToPatch = await _unitOfWork.ParkingPermitRepository.GetAsync(id);
        if (parkingPermitToPatch is null) return NotFound();

        _mapper.Map(patchData, parkingPermitToPatch);
        await _unitOfWork.SaveAsync();

        var editedParkingPermitDTO = _mapper.Map<ParkingPermitDTO>(parkingPermitToPatch);
        return Ok(editedParkingPermitDTO);
    }

    [HttpDelete("{id:int}/parking-permits/{permitId:int}")]
    public async Task<ActionResult<ParkingPermitDTO>> DeleteGuestParkingPermits(int id)
    {
        var parkingPermitToDelete = await _unitOfWork.ParkingPermitRepository.GetAsync(id);
        if (parkingPermitToDelete is null) return NotFound();

        _unitOfWork.ParkingPermitRepository.Delete(parkingPermitToDelete);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}

