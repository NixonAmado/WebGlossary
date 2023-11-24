using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
//[Authorize(Roles = "Empleado, Administrador, Gerente")]
public class PhaseController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PhaseController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<G_PhaseDto>>> Get()
    {
        var Phases = await _unitOfWork.Phases.GetAllAsync();
         if (Phases == null)
        {
            return BadRequest("Phase can´t be null!");
        }
        return _mapper.Map<List<G_PhaseDto>>(Phases);
    }

    // [HttpGet]
    // [ApiVersion("1.1")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<Pager<G_PhaseDto>>> Get([FromQuery] Params PhaseParams)
    // {
    //     var (totalRegistros, registros) = await _unitOfWork.Phases.GetAllAsync(PhaseParams.PageIndex,PhaseParams.PageSize,PhaseParams.Search);
    //     var listaProv = _mapper.Map<List<G_PhaseDto>>(registros);
    //     return new Pager<G_PhaseDto>(listaProv,totalRegistros,PhaseParams.PageIndex,PhaseParams.PageSize,PhaseParams.Search);
    // }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> Post(Phase Phase)
    {
         if (Phase == null)
        {
            return BadRequest("Phase can´t be null!");
        }
        _unitOfWork.Phases.Add(Phase);
        await _unitOfWork.SaveAsync();
       
        return "Phase have been successfully created";
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> Put(int id,[FromBody] Phase Phase)
    {
        if (Phase == null|| id != Phase.Id)
        {
            return BadRequest("Incorrect phase id");
        }
        var proveedExiste = await _unitOfWork.Phases.GetByIdAsync(id);

        if (proveedExiste == null)
        {
            return NotFound();
        }
        _mapper.Map(Phase, proveedExiste);
        _unitOfWork.Phases.Update(proveedExiste);
        await _unitOfWork.SaveAsync();

        return $"Phase {Phase.Id} have been successfully updated ";
    }



    [HttpDelete("{id}")]
    //[Authorize(Roles = "Administrador, Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var Phase = await _unitOfWork.Phases.GetByIdAsync(id);
        if (Phase == null)
        {
            return NotFound($"Phase {Phase.Id} haven´t been found");
        }
        _unitOfWork.Phases.Remove(Phase);
        await _unitOfWork.SaveAsync();
        return Ok(new { message = $"The Phase {Phase.Id} has been successfully removed" });
    }
}