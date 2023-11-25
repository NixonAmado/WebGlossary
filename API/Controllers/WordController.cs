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
public class WordController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public WordController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<G_WordDto>>> Get()
    {
        var Words = await _unitOfWork.Words.GetAllAsync();
        return _mapper.Map<List<G_WordDto>>(Words);
    }

    [HttpGet]
    [ApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<G_WordDto>>> Get([FromQuery] Params WordParams)
    {
        var (totalRegistros, registros) = await _unitOfWork.Words.GetAllAsync(WordParams.PageIndex,WordParams.PageSize,WordParams.Search);
        var listaProv = _mapper.Map<List<G_WordDto>>(registros);
        return new Pager<G_WordDto>(listaProv,totalRegistros,WordParams.PageIndex,WordParams.PageSize,WordParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> Post(Word Word)
    {
        if (Word == null)
        {
            return BadRequest("Word can´t be null!");
        }
        _unitOfWork.Words.Add(Word);
        await _unitOfWork.SaveAsync();
        
        return "Word have been successfully created";
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> Put(int id,[FromBody] Word Word)
    {
        if (Word == null|| id != Word.Id)
        {
            return BadRequest("Incorrect Word id");
        }
        var proveedExiste = await _unitOfWork.Words.GetByIdAsync(id);

        if (proveedExiste == null)
        {
            return NotFound();
        }
        _mapper.Map(Word, proveedExiste);
        _unitOfWork.Words.Update(proveedExiste);
        await _unitOfWork.SaveAsync();

        return $"Word {Word.Id} have been successfully updated";
    }



    [HttpDelete("{id}")]
    //[Authorize(Roles = "Administrador, Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var Word = await _unitOfWork.Words.GetByIdAsync(id);
        if (Word == null)
        {
            return NotFound($"Word {Word.Id} haven´t been found");
        }
        _unitOfWork.Words.Remove(Word);
        await _unitOfWork.SaveAsync();
        return Ok(new { message = $"The Word {Word.Id} has been successfully removed" });
    }
}