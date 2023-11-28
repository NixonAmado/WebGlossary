using Domain.Interfaces;

namespace API.Services;
public class OpenAIService
{
    private readonly IUnitOfWork _unitOfWork;
    

    public OpenAIService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    

}
