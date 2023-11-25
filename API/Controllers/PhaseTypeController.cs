using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
//[Authorize(Roles = "Empleado, Administrador, Gerente")]
public class PhaseTypeController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PhaseTypeController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<G_PTypeDto>>> Get()
    {
        var PhaseTypes = await _unitOfWork.PhaseTypes.GetAllAsync();
        return _mapper.Map<List<G_PTypeDto>>(PhaseTypes);
    }

    [HttpGet]
    [ApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<G_PTypeDto>>> Get([FromQuery] Params PhaseTypeParams)
    {
        var (totalRegistros, registros) = await _unitOfWork.PhaseTypes.GetAllAsync(PhaseTypeParams.PageIndex,PhaseTypeParams.PageSize,PhaseTypeParams.Search);
        var listaProv = _mapper.Map<List<G_PTypeDto>>(registros);
        return new Pager<G_PTypeDto>(listaProv,totalRegistros,PhaseTypeParams.PageIndex,PhaseTypeParams.PageSize,PhaseTypeParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> Post(Phasetype PhaseType)
    {
        if (PhaseType == null)
        {
            return BadRequest("PhaseType can´t be null!");
        }
        _unitOfWork.PhaseTypes.Add(PhaseType);
        await _unitOfWork.SaveAsync();
        
        return "PhaseType have been successfully created";
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> Put(int id,[FromBody] Phasetype PhaseType)
    {
        if (PhaseType == null|| id != PhaseType.Id)
        {
            return BadRequest("Incorrect PhaseType id");
        }
        var proveedExiste = await _unitOfWork.PhaseTypes.GetByIdAsync(id);

        if (proveedExiste == null)
        {
            return NotFound();
        }
        _mapper.Map(PhaseType, proveedExiste);
        _unitOfWork.PhaseTypes.Update(proveedExiste);
        await _unitOfWork.SaveAsync();

        return $"PhaseType {PhaseType.Id} have been successfully updated";
    }



    [HttpDelete("{id}")]
    //[Authorize(Roles = "Administrador, Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var PhaseType = await _unitOfWork.PhaseTypes.GetByIdAsync(id);
        if (PhaseType == null)
        {
            return NotFound($"PhaseType {PhaseType.Id} haven´t been found");
        }
        _unitOfWork.PhaseTypes.Remove(PhaseType);
        await _unitOfWork.SaveAsync();
        return Ok(new { message = $"The PhaseType {PhaseType.Id} has been successfully removed" });
    }
}