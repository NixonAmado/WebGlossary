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
public class PhaseVerbalTenseController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PhaseVerbalTenseController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<G_PVerbalTenseDto>>> Get()
    {
        var PhaseVerbalTenses = await _unitOfWork.PhaseVerbalTenses.GetAllAsync();
        return _mapper.Map<List<G_PVerbalTenseDto>>(PhaseVerbalTenses);
    }

    [HttpGet]
    [ApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<G_PVerbalTenseDto>>> Get([FromQuery] Params PhaseVerbalTenseParams)
    {
        var (totalRegistros, registros) = await _unitOfWork.PhaseVerbalTenses.GetAllAsync(PhaseVerbalTenseParams.PageIndex,PhaseVerbalTenseParams.PageSize,PhaseVerbalTenseParams.Search);
        var listaProv = _mapper.Map<List<G_PVerbalTenseDto>>(registros);
        return new Pager<G_PVerbalTenseDto>(listaProv,totalRegistros,PhaseVerbalTenseParams.PageIndex,PhaseVerbalTenseParams.PageSize,PhaseVerbalTenseParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> Post(Phaseverbaltense PhaseVerbalTense)
    {
         if (PhaseVerbalTense == null)
        {
            return BadRequest("PhaseVerbalTense can´t be null!");
        }
        _unitOfWork.PhaseVerbalTenses.Add(PhaseVerbalTense);
        await _unitOfWork.SaveAsync();
       
        return "PhaseVerbalTense have been successfully created";
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> Put(int id,[FromBody] Phaseverbaltense PhaseVerbalTense)
    {
        if (PhaseVerbalTense == null|| id != PhaseVerbalTense.Id)
        {
            return BadRequest("Incorrect PhaseVerbalTense id");
        }
        var proveedExiste = await _unitOfWork.PhaseVerbalTenses.GetByIdAsync(id);

        if (proveedExiste == null)
        {
            return NotFound();
        }
        _mapper.Map(PhaseVerbalTense, proveedExiste);
        _unitOfWork.PhaseVerbalTenses.Update(proveedExiste);
        await _unitOfWork.SaveAsync();

        return $"PhaseVerbalTense {PhaseVerbalTense.Id} have been successfully updated ";
    }



    [HttpDelete("{id}")]
    //[Authorize(Roles = "Administrador, Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var PhaseVerbalTense = await _unitOfWork.PhaseVerbalTenses.GetByIdAsync(id);
        if (PhaseVerbalTense == null)
        {
            return NotFound($"PhaseVerbalTense {PhaseVerbalTense.Id} haven´t been found");
        }
        _unitOfWork.PhaseVerbalTenses.Remove(PhaseVerbalTense);
        await _unitOfWork.SaveAsync();
        return Ok(new { message = $"The PhaseVerbalTense {PhaseVerbalTense.Id} has been successfully removed" });
    }
}