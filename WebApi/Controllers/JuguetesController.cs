using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTOs;
using WebApi.Models;
using WebApi.Repository;
using WebApi.Utilidades;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuguetesController : ControllerBase
    {
        private readonly IRepository<Juguete> _repository;
        private readonly IAlmacenadorImagenesLocal _almacenadorImagenes;

        public JuguetesController(IRepository<Juguete> repository, IAlmacenadorImagenesLocal almacenadorImagenes)
        {
            this._repository = repository;
            this._almacenadorImagenes = almacenadorImagenes;
        }

        //end-point que solo se ejecuta al llamado de launchSettings.json
        //cuando se este ejecutando IIS de manera (local)
        [Route("test")]
        public ActionResult Test()
        {
            return Ok("success");
        }

        //Obtener todos los registros
        [HttpGet]
        public async Task<IEnumerable<Juguete>> Get()
        {
            IEnumerable<Juguete> juguetes = await _repository.GetAllAsync();
            return juguetes;
        }

        //Crear un registro en la base de datos
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] JugueteCrearDto model)
        {
            try
            {
                Juguete juguete = new Juguete();
                juguete.Nombre = model.Nombre;
                juguete.Descripcion = model.Descripcion;
                juguete.RestriccionEdad = model.RestriccionEdad;
                juguete.Precio = model.Precio;
                juguete.Compania = model.Compania;
                juguete.Precio = model.Precio;
                if (model.Imagen != null)
                {
                    juguete.Imagen = await _almacenadorImagenes.SaveImage("Imagenes", model.Imagen);
                }
                _repository.Add(juguete);
                _repository.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        //Actualizar un registro
        [HttpPut]
        public async Task<ActionResult> Put([FromForm] JugueteActualizarDto model)
        {
            try
            {
                var juguete = await _repository.GetElementAsync(model.Id);
                if(juguete == null)
                {
                    return NotFound();
                }
                juguete.Nombre = model.Nombre;
                juguete.Descripcion = model.Descripcion;
                juguete.RestriccionEdad = model.RestriccionEdad;
                juguete.Precio = model.Precio;
                juguete.Compania = model.Compania;
                juguete.Precio = model.Precio;
                if (model.Imagen != null)
                {
                    juguete.Imagen = await _almacenadorImagenes.EditImage("Imagenes", juguete.Imagen, model.Imagen);
                }
                _repository.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        //Eliminar un registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var juguete = await _repository.GetElementAsync(id);
                if (juguete == null)
                {
                    return NotFound();
                }

                if (!string.IsNullOrEmpty(juguete.Imagen))
                {
                    await _almacenadorImagenes.DeleteImage("Imagenes", juguete.Imagen);
                }

                _repository.Delete(juguete);
                _repository.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }

        //Fin del controlador
    }
}
