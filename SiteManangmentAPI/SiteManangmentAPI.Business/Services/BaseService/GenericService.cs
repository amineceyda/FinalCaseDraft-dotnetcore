using Serilog;
using AutoMapper;
using SiteManangmentAPI.Base.BaseEntities;
using SiteManangmentAPI.Base.Response;
using SiteManangmentAPI.Data.UnitOfWork;

namespace SiteManangmentAPI.Business.Services;


public class GenericService<TEntity, TRequest, TResponse> : IGenericService<TEntity, TRequest, TResponse> where TEntity : BaseEntity
{
    protected readonly IMapper _mapper;
    protected readonly IUnitOfWork _unitOfWork;

    public GenericService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public virtual ApiResponse Delete(int Id)
    {
        try
        {
            var entity = _unitOfWork.DynamicRepository<TEntity>().GetById(Id);
            if (entity == null)
            {
                return new ApiResponse("Record not found!");
            }

            _unitOfWork.DynamicRepository<TEntity>().DeleteById(Id);
            _unitOfWork.Complete();
            return new ApiResponse();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "GenericService.Delete");
            return new ApiResponse(ex.Message);
        }
    }

    public virtual ApiResponse<List<TResponse>> GetAll()
    {
        try
        {
            var entity = _unitOfWork.DynamicRepository<TEntity>().GetAll();
            var mapped = _mapper.Map<List<TEntity>, List<TResponse>>(entity);
            return new ApiResponse<List<TResponse>>(mapped);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "GenericService.GetAll");
            return new ApiResponse<List<TResponse>>(ex.Message);
        }
    }

    public virtual ApiResponse<TResponse> GetById(int id)
    {
        try
        {
            var entity = _unitOfWork.DynamicRepository<TEntity>().GetById(id);
            var mapped = _mapper.Map<TEntity, TResponse>(entity);
            return new ApiResponse<TResponse>(mapped);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "GenericService.GetById");
            return new ApiResponse<TResponse>(ex.Message);
        }
    }

    public virtual ApiResponse Insert(TRequest request)
    {
        try
        {
            var entity = _mapper.Map<TRequest, TEntity>(request);
            entity.InsertTime = DateTime.Now;
           

            _unitOfWork.DynamicRepository<TEntity>().Insert(entity);
            _unitOfWork.DynamicRepository<TEntity>().Save();

            return new ApiResponse();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "GenericService.Insert");
            return new ApiResponse(ex.Message);
        }
    }

    public virtual ApiResponse Update(int Id, TRequest request)
    {
        try
        {
            var exist = _unitOfWork.DynamicRepository<TEntity>().GetById(Id);
            if (exist == null)
            {
                return new ApiResponse("Record not found!");
            }

            var entity = _mapper.Map<TRequest, TEntity>(request);
            _unitOfWork.DynamicRepository<TEntity>().Update(entity);
            _unitOfWork.DynamicRepository<TEntity>().Save();

            return new ApiResponse();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "GenericService.Update");
            return new ApiResponse(ex.Message);
        }
    }
}
