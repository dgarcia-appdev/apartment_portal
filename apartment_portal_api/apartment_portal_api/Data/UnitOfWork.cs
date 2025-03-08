using apartment_portal_api.Abstractions;
using apartment_portal_api.Models;
using apartment_portal_api.Models.Guests;
using apartment_portal_api.Models.ParkingPermits;
using apartment_portal_api.Models.Issues;
using apartment_portal_api.Models.Packages;
using apartment_portal_api.Models.Statuses;
using apartment_portal_api.Models.Users;
using apartment_portal_api.Models.UnitUsers;

namespace apartment_portal_api.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly PostgresContext _context;
    private IRepository<Guest>? _guestRepository;
    private IRepository<ParkingPermit>? _parkingPermitRepository;
    private IRepository<Issue>? _issueRepository;
    private IRepository<Package>? _packageRepository;
    private IRepository<Status>? _statusRepository;
    private IRepository<Unit>? _unitRepository;
    private IRepository<ApplicationUser>? _userRepository;
    private IRepository<UnitUser>? _unitUserRepository;

    public UnitOfWork(PostgresContext context)
    {
        _context = context;
    }

    public IRepository<Guest> GuestRepository
    {
        get
        {
            _guestRepository ??= new Repository<Guest>(_context);
            return _guestRepository;
        }
    }    
    public IRepository<ParkingPermit> ParkingPermitRepository
    {
        get
        {
            _parkingPermitRepository ??= new Repository<ParkingPermit>(_context);
            return _parkingPermitRepository;
        }
    }

    public IRepository<Issue> IssueRepository
    {
        get
        {
            _issueRepository ??= new Repository<Issue>(_context);
            return _issueRepository;
        }
    }

    public IRepository<Package> PackageRepository
    {
        get
        {
            _packageRepository ??= new Repository<Package>(_context);
            return _packageRepository;
        }
    }

    public IRepository<Status> StatusRepository
    {
        get
        {
            _statusRepository ??= new Repository<Status>(_context);
            return _statusRepository;
        }
    }

    public IRepository<Unit> UnitRepository
    {
        get
        {
            _unitRepository ??= new Repository<Unit>(_context);
            return _unitRepository;
        }
    }

    public IRepository<ApplicationUser> UserRepository
    {
        get
        {
            _userRepository ??= new Repository<ApplicationUser>(_context);
            return _userRepository;
        }
    }
    public IRepository<UnitUser> UnitUserRepository
    {
        get
        {
            _unitUserRepository ??= new Repository<UnitUser>(_context); 
            return _unitUserRepository;
        }
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}