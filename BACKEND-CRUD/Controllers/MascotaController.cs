using AutoMapper;
using BACKEND_CRUD.Models;
using BACKEND_CRUD.Models.DTO;
using BACKEND_CRUD.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BACKEND_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        //Repository
        private readonly IMascotaRepository _repository;

        //AutoMapper
        private readonly IMapper _mapper;

        public MascotaController(IMapper mapper,IMascotaRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaMascotas = await _repository.GetListMascotas();
                var listaMascotasDto = _mapper.Map<IEnumerable<MascotaDTO>>(listaMascotas);
                return Ok(listaMascotasDto);
            
            }catch(Exception ex) { 
            
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var mascota = await _repository.GetMascota(id);

                if (mascota == null)
                {
                    return NotFound();
                }
                var mascotaDto = _mapper.Map<MascotaDTO>(mascota);
                return Ok(mascotaDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var mascota = await _repository.GetMascota(id);
                if (mascota == null)
                {
                    return NotFound();
                }

                await _repository.DeleteMascota(mascota);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(MascotaDTO mascotaDto)
        {
            try
            {
                var mascota = _mapper.Map<Mascota>(mascotaDto);

                mascota.FechaCreacion = DateTime.Now;

                mascota = await _repository.AddMascota(mascota);

                var mascotaItemDto = _mapper.Map<MascotaDTO>(mascota);
                return CreatedAtAction("Get", new { id = mascotaItemDto.Id }, mascotaItemDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, MascotaDTO mascotaDto)
        {
            try
            {
                var mascota = _mapper.Map<Mascota>(mascotaDto);

                if (id != mascota.Id)
                {
                    return BadRequest();
                }

                var mascotaItem = await _repository.GetMascota(id);

                if (mascotaItem == null)
                {
                    return NotFound();
                }

                await _repository.UpdateMascota(mascota);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
