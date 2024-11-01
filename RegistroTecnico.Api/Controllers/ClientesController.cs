﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tecnicos.Abstractions;
using Tecnicos.Data.Context;
using Tecnicos.Data.Models;
using Tecnicos.Domain.DTO;

namespace RegistroTecnico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

	public class ClientesController(IClientesService clientesService) : ControllerBase
	{
		// GET: api/Clientes
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ClientesDto>>> GetClientes()
		{
			return await clientesService.Listar(p => true);
		}

		// GET: api/Clientes/5
		[HttpGet("{id}")]
		public async Task<ActionResult<ClientesDto>> GetClientes(int id)
		{
			return await clientesService.Buscar(id);
		}

		// PUT: api/Clientes/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutClientes(int id, ClientesDto clienteDto)
		{
			if (id != clienteDto.ClienteId)
			{
				return BadRequest();
			}

			await clientesService.Guardar(clienteDto);

			return NoContent();
		}

		// POST: api/Clientes
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Clientes>> PostClientes(ClientesDto clienteDto)
		{
			await clientesService.Guardar(clienteDto);

			return CreatedAtAction("GetClientes", new { id = clienteDto.ClienteId }, clienteDto);
		}

		// DELETE: api/Clientes/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteClientes(int id)
		{
			await clientesService.Eliminar(id);

			return NoContent();
		}
	}
}