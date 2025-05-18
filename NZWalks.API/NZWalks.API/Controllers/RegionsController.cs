using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper
            )
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            //Get Data From Database - Domain models
            var regionsDomain = await regionRepository.GetAllAsync();


            // Map Domain Models to DTOs
            //var regionsDto = new List<RegionDto>();
            //foreach (var regionDomain in regionsDomain)
            //{
            //    regionsDto.Add(new RegionDto()
            //    {
            //        Id = regionDomain.Id,
            //        Code = regionDomain.Code,
            //        Name = regionDomain.Name,
            //    });
            //}

            // map domain models to dto
            var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);

            // Return DTOs
            return Ok(regionsDto);
        }

        //GET single region
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            // get region domain model from database
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null) {
                return NotFound();
            }

            // map/convert region domain model to region dto

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,

            //};

            // mapper is here
            var regionDto = mapper.Map<RegionDto>(regionDomain);

            //return dto
            return Ok(regionDto);
        }
    

    [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            if(ModelState.IsValid)
            {
                // map or convert dto to domain model
                //var regionDomainModel = new Region
                //{
                //    Code = addRegionRequestDto.Code,
                //    Name = addRegionRequestDto.Name,
                //};


                //mapper is here

                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

                // use domain model to create to dto
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

                // map domain model back to dto
                //var regionDto = new RegionDto
                //{
                //    Id = regionDomainModel.Id,
                //    Code = regionDomainModel.Code,
                //    Name = regionDomainModel.Name,

                //};

                // mapper is here

                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);

            }
            else
            {
                return BadRequest();
            }
            
        }

        //Update region
        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            if (ModelState.IsValid)
            {
                // map to dto to domain model
                //var regionDomainModel = new Region
                //{
                //    Code = updateRegionRequestDto.Code,
                //    Name = updateRegionRequestDto.Name,
                //};

                // mapper is here

                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

                // check if region exist
                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound();
                }


                // convert domain model to dto
                //var regionDto = new RegionDto
                //{
                //    Id = regionDomainModel.Id,
                //    Code = regionDomainModel.Code,
                //    Name = regionDomainModel.Name,
                //};

                // mapper is here

                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                return Ok(regionDto);
            }
            else
            {
                return BadRequest();
            }
            
        }

        //delete region
        [HttpDelete]
        [Route("{id:Guid}")]
        // we add writer and reader both can delete the region. it is not a mistake
        [Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if(regionDomainModel == null)
            {
                return NotFound();
            }

            // map domain model to dto
            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,

            //};

            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }
    }
}
