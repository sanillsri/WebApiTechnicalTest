using Business.Interface;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTechnicalTest.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        IApplication _application;

        public ApplicationController(IApplication application)
        {
            _application = application;
        }


        #region Brewery

        [HttpGet]
        public async Task<List<BreweryDTO>> GetBreweries()
        {
            return await _application.GetBreweries();
        }

        [HttpGet]
        public async Task<BreweryDTO> GetBrewery(int BreweryId)
        {
            return await _application.GetBrewery(BreweryId);
        }

        [HttpPost]
        public async Task<string> SaveBrewery(InputDTO brewery)
        {
            return await _application.SaveBrewery(brewery);
        }

        [HttpPut]
        public async Task<string> UpdateBrewery(InputDTO brewery)
        {
            return await _application.UpdateBrewery(brewery);
        }

        #endregion

        #region BAR

        [HttpGet]
        public async Task<List<BarDTO>> GetBars()
        {
            return await _application.GetBars();
        }

        [HttpGet]
        public async Task<BarDTO> GetBar(int BarId)
        {
            return await _application.GetBar(BarId);
        }

        [HttpPost]
        public async Task<string> SaveBar(InputDTO barInput)
        {
            return await _application.SaveBar(barInput);
        }

        [HttpPut]
        public async Task<string> UpdateBar(InputDTO barInput)
        {
            return await _application.UpdateBar(barInput);
        }
        #endregion

        #region BEER

        [HttpGet]
        public async Task<List<BeerDTO>> GetBeers(double? gtAlocholByVolume, double? ltAlocholByVolume)
        {
            return await _application.GetBeers(gtAlocholByVolume,ltAlocholByVolume);
        }

        [HttpGet]
        public async Task<BeerDTO> GetBeer(int beerId)
        {
            return await _application.GetBeer(beerId);
        }

        [HttpPost]
        public async Task<string> SaveBeer(InputDTO beerInput)
        {
            return await _application.SaveBeer(beerInput);
        }

        [HttpPut]
        public async Task<string> UpdateBeer(InputDTO beerInput)
        {
            return await _application.UpdateBeer(beerInput);
        }
        #endregion

        #region Brewery and  Beer
        [HttpGet]
        public async Task<List<BreweryBeerDTO>> GetBreweryAndBeersById(int breweryId)
        {
            return await _application.GetBreweryAndBeersById(breweryId);
        }
        [HttpGet]
        public async Task<List<BreweryBeerDTO>> GetBreweryAndBeers()
        {
            return await _application.GetBreweryAndBeers();
        }

        [HttpPost]
        public async Task<string> SaveBreweryBeer(MappingInputDTO input)
        {
            return await _application.SaveBreweryBeer(input);
        }


        #endregion

       
        #region Bar and  Beer

        public async Task<List<BarBeerDTO>> GetBarAndBeersById(int barId)
        {
            return await _application.GetBarAndBeersById(barId);
        }

        public async Task<List<BarBeerDTO>> GetBarAndBeers()
        {
            return await _application.GetBarAndBeers();
        }

        public async Task<string> SaveBarBeer(MappingInputDTO input)
        {
            return await _application.SaveBarBeer(input);
        }
        #endregion
    }

}
