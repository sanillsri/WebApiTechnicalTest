using Business.Interface;
using DataAccess.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class Application : IApplication
    {
        IApplicationDA _applicationDA;
        public Application(IApplicationDA applicationDA)
        {
            _applicationDA = applicationDA;
        }

        #region Brewery
        public async Task<BreweryDTO> GetBrewery(int BreweryId)
        {
            return await _applicationDA.GetBrewery(BreweryId);
        }

        public async Task<List<BreweryDTO>> GetBreweries()
        {
            return await _applicationDA.GetBreweries();
        }

        public async Task<string> SaveBrewery(InputDTO brewery)
        {
            return await _applicationDA.SaveBrewery(brewery);
        }

        public async Task<string> UpdateBrewery(InputDTO brewery)
        {
            return await _applicationDA.UpdateBrewery(brewery);
        }
        #endregion

        #region Bar
        public async Task<BarDTO> GetBar(int BarId)
        {
            return await _applicationDA.GetBar(BarId);
        }

        public async Task<List<BarDTO>> GetBars()
        {
            return await _applicationDA.GetBars();
        }

        public async Task<string> SaveBar(InputDTO barInput)
        {
            return await _applicationDA.SaveBar(barInput);
        }

        public async Task<string> UpdateBar(InputDTO barInput)
        {
            return await _applicationDA.UpdateBar(barInput);
        }


        #endregion

        #region Beer
        public async Task<BeerDTO> GetBeer(int BeerId)
        {
            return await _applicationDA.GetBeer(BeerId);
        }

        public async Task<List<BeerDTO>> GetBeers(double? gtAlocholByVolume, double? ltAlocholByVolume)
        {
            return await _applicationDA.GetBeers(gtAlocholByVolume,ltAlocholByVolume);
        }

        public async Task<string> SaveBeer(InputDTO beerInput)
        {
            return await _applicationDA.SaveBeer(beerInput);
        }

        public async Task<string> UpdateBeer(InputDTO beerInput)
        {
            return await _applicationDA.UpdateBeer(beerInput);
        }


        #endregion

        #region Brewery and  Beer

        public async Task<List<BreweryBeerDTO>> GetBreweryAndBeersById(int breweryId)
        {
            return await _applicationDA.GetBreweryAndBeersById(breweryId);
        }

        public async Task<List<BreweryBeerDTO>> GetBreweryAndBeers()
        {
            return await _applicationDA.GetBreweryAndBeers();
        }

        public async Task<string> SaveBreweryBeer(MappingInputDTO input)
        {
            return await _applicationDA.SaveBreweryBeer(input);
        }


        #endregion

        #region Bar and  Beer



        public async Task<List<BarBeerDTO>> GetBarAndBeersById(int barId)
        {
            return await _applicationDA.GetBarAndBeersById(barId);
        }

        public async Task<List<BarBeerDTO>> GetBarAndBeers()
        {
            return await _applicationDA.GetBarAndBeers();
        }

        public async Task<string> SaveBarBeer(MappingInputDTO input)
        {
            return await _applicationDA.SaveBarBeer(input);
        }

        #endregion

    }
}
