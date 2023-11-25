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
public class PhaseStructureController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PhaseStructureController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<G_PStructureDto>>> Get()
    {
        var PhaseStructures = await _unitOfWork.PhaseStructures.GetAllAsync();
        return _mapper.Map<List<G_PStructureDto>>(PhaseStructures);
    }

    [HttpGet]
    [ApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<G_PStructureDto>>> Get([FromQuery] Params PhaseStructureParams)
    {
        var (totalRegistros, registros) = await _unitOfWork.PhaseStructures.GetAllAsync(PhaseStructureParams.PageIndex,PhaseStructureParams.PageSize,PhaseStructureParams.Search);
        var listaProv = _mapper.Map<List<G_PStructureDto>>(registros);
        return new Pager<G_PStructureDto>(listaProv,totalRegistros,PhaseStructureParams.PageIndex,PhaseStructureParams.PageSize,PhaseStructureParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> Post(Phasestructure PhaseStructure)
    {
         if (PhaseStructure == null)
        {
            return BadRequest("PhaseStructure can´t be null!");
        }
        _unitOfWork.PhaseStructures.Add(PhaseStructure);
        await _unitOfWork.SaveAsync();
       
        return "PhaseStructure have been successfully created";
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> Put(int id,[FromBody] Phasestructure PhaseStructure)
    {
        if (PhaseStructure == null|| id != PhaseStructure.Id)
        {
            return BadRequest("Incorrect PhaseStructure id");
        }
        var proveedExiste = await _unitOfWork.PhaseStructures.GetByIdAsync(id);

        if (proveedExiste == null)
        {
            return NotFound();
        }
        _mapper.Map(PhaseStructure, proveedExiste);
        _unitOfWork.PhaseStructures.Update(proveedExiste);
        await _unitOfWork.SaveAsync();

        return $"PhaseStructure {PhaseStructure.Id} have been successfully updated ";
    }



    [HttpDelete("{id}")]
    //[Authorize(Roles = "Administrador, Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var PhaseStructure = await _unitOfWork.PhaseStructures.GetByIdAsync(id);
        if (PhaseStructure == null)
        {
            return NotFound($"PhaseStructure {PhaseStructure.Id} haven´t been found");
        }
        _unitOfWork.PhaseStructures.Remove(PhaseStructure);
        await _unitOfWork.SaveAsync();
        return Ok(new { message = $"The PhaseStructure {PhaseStructure.Id} has been successfully removed" });
    }
}