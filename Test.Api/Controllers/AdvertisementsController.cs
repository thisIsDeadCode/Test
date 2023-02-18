﻿using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Api.Data;
using Test.Api.Data.Models;
using Test.Api.Services;
using Test.Api.View.Extensions;
using Test.Api.View.Models.Requests;
using Test.Api.View.Models.Responses;

namespace Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementsController : ControllerBase
    {
        private readonly TestApiContext _context;
        public AdvertisementsController(TestApiContext context)
        {
            _context = context;
        }

        // GET: api/Advertisements
        [HttpGet]
        public async Task<ActionResult<CollectionResponse<AdvertisementResponse>>> GetAdvertisements(bool isActualDate = true, string? title = null, int pageNumber =  1, int pageSize = 20)
        {
            if (_context.Advertisements == null)
            {
                return NotFound();
            }
            var advertisements = await _context.Advertisements.Include(x => x.Author).OrderBy(x => x.Id).ToListAsync();
            if(isActualDate)
            {
                advertisements = advertisements.Where(x => x.FinishedDate > DateTime.UtcNow).ToList();

            }
            if (title != null)
            {
                advertisements =  advertisements.Where(x => x.Title.Contains(title)).ToList();
            }
            var _paginationService = new PaginationService<Advertisement>(advertisements, pageNumber, pageSize);
            var resultAdvertisements = _paginationService.GetItems().ToAdvertisementResponse();

            var res = new CollectionResponse<AdvertisementResponse>(resultAdvertisements, _paginationService.PageInfo);

            return res;
        }

        // GET: api/Advertisements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdvertisementResponse>> GetAdvertisement(int id)
        {
            if (_context.Advertisements == null)
            {
                return NotFound();
            }
            var advertisement = await _context.Advertisements
                .Include(x => x.Author)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (advertisement == null)
            {
                return NotFound();
            }

            return advertisement.ToAdvertisementResponse();
        }

        // PUT: api/Advertisements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdvertisement(int id, AdvertisementRequest advertisement)
        {
            if (id != advertisement.Id)
            {
                return BadRequest();
            }

            _context.Entry(advertisement.ToAdvertisementModel()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertisementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Advertisements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdvertisementResponse>> PostAdvertisement(AdvertisementRequest advertisement)
        {
            if (_context.Advertisements == null)
            {
                return Problem("Entity set 'TestApiContext.Advertisements'  is null.");
            }
            var advertisementModel = advertisement.ToAdvertisementModel();

            _context.Advertisements.Add(advertisementModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAdvertisement", new { id = advertisementModel.Id }, advertisementModel.ToAdvertisementResponse());
        }

        // DELETE: api/Advertisements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvertisement(int id)
        {
            if (_context.Advertisements == null)
            {
                return NotFound();
            }
            var advertisement = await _context.Advertisements.FindAsync(id);
            if (advertisement == null)
            {
                return NotFound();
            }

            _context.Advertisements.Remove(advertisement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdvertisementExists(int id)
        {
            return (_context.Advertisements?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
