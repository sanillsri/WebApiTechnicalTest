using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IApplication
    {
        #region Brewery
        Task<string> SaveBrewery(InputDTO brewery);

        Task<List<BreweryDTO>> GetBreweries();

        Task<BreweryDTO> GetBrewery(int BreweryId);

        Task<string> UpdateBrewery(InputDTO brewery);

        #endregion

        #region Bar
        Task<string> SaveBar(InputDTO barInput);

        Task<List<BarDTO>> GetBars();

        Task<BarDTO> GetBar(int BarId);

        Task<string> UpdateBar(InputDTO barInput);

        #endregion

        #region Beer
        Task<string> SaveBeer(InputDTO beerInput);

        Task<List<BeerDTO>> GetBeers(double? gtAlocholByVolume, double? ltAlocholByVolume);

        Task<BeerDTO> GetBeer(int BeerId);

        Task<string> UpdateBeer(InputDTO beerInput);

        #endregion


        #region Brewery and  Beer
        Task<string> SaveBreweryBeer(MappingInputDTO input);

        Task<List<BreweryBeerDTO>> GetBreweryAndBeersById(int breweryId);

        Task<List<BreweryBeerDTO>> GetBreweryAndBeers();


        #endregion

        #region Bar and  Beer
        Task<string> SaveBarBeer(MappingInputDTO input);

        Task<List<BarBeerDTO>> GetBarAndBeersById(int barId);

        Task<List<BarBeerDTO>> GetBarAndBeers();


        #endregion

    }
}
