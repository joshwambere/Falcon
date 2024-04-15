using Searching.Domain.Entities;
using Searching.Infrastructure.Data;
using Searching.Management.Api.Attributes;
using Searching.Management.Api.DTOs;

namespace Searching.Management.Api.Services;

[ScoppedService]
public class OtpService : BaseService
{
    public OtpService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<SavedResponse> SaveOtp(User user, Otp otp)
    {
        var repository = UnitOfWork.AsyncRepository<Otp>();
        otp.User = user;
        await repository.AddAsync(otp);
        await UnitOfWork.SaveChangesAsync();

        return await Task.FromResult(new SavedResponse
        {
            message = "Otp Saved successful",
            success = true
        });
    }
}