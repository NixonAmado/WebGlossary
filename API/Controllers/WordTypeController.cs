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
public class WordTypesController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public WordTypesController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<G_WTypeDto>>> Get()
    {
        var WordTypes = await _unitOfWork.WordTypes.GetAllAsync();
        return _mapper.Map<List<G_WTypeDto>>(WordTypes);
    }

    [HttpGet]
    [ApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<G_WTypeDto>>> Get([FromQuery] Params WordTypesParams)
    {
        var (totalRegistros, registros) = await _unitOfWork.WordTypes.GetAllAsync(WordTypesParams.PageIndex,WordTypesParams.PageSize,WordTypesParams.Search);
        var listaProv = _mapper.Map<List<G_WTypeDto>>(registros);
        return new Pager<G_WTypeDto>(listaProv,totalRegistros,WordTypesParams.PageIndex,WordTypesParams.PageSize,WordTypesParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> Post(Wordtype WordTypes)
    {
        if (WordTypes == null)
        {
            return BadRequest("WordType can´t be null!");
        }
        _unitOfWork.WordTypes.Add(WordTypes);
        await _unitOfWork.SaveAsync();
        
        return "WordType have been successfully created";
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> Put(int id,[FromBody] Wordtype WordTypes)
    {
        if (WordTypes == null|| id != WordTypes.Id)
        {
            return BadRequest("Incorrect WordType id");
        }
        var proveedExiste = await _unitOfWork.WordTypes.GetByIdAsync(id);

        if (proveedExiste == null)
        {
            return NotFound();
        }
        _mapper.Map(WordTypes, proveedExiste);
        _unitOfWork.WordTypes.Update(proveedExiste);
        await _unitOfWork.SaveAsync();

        return $"WordType {WordTypes.Id} have been successfully updated";
    }



    [HttpDelete("{id}")]
    //[Authorize(Roles = "Administrador, Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var WordTypes = await _unitOfWork.WordTypes.GetByIdAsync(id);
        if (WordTypes == null)
        {
            return NotFound($"WordType {WordTypes.Id} haven´t been found");
        }
        _unitOfWork.WordTypes.Remove(WordTypes);
        await _unitOfWork.SaveAsync();
        return Ok(new { message = $"The WordType {WordTypes.Id} has been successfully removed" });
    }
}