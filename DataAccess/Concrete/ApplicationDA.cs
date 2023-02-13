using Data.Models;
using DataAccess.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class ApplicationDA : IApplicationDA
    {
        private TechnicalTestContext _ttDBContext = new TechnicalTestContext();


        #region Brewery
        public async Task<List<BreweryDTO>> GetBreweries()
        {
            try
            {
                List<BreweryDTO> breweries = new List<BreweryDTO>();
                breweries = await _ttDBContext.Breweries.Select(x => new BreweryDTO
                {
                    BreweryId = x.BreweryId,
                    BreweryName = x.Name
                }).ToListAsync();

                return breweries;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BreweryDTO> GetBrewery(int BreweryId)
        {
            try
            {
                BreweryDTO brewery = new BreweryDTO();
                brewery = await _ttDBContext.Breweries.Where(x => x.BreweryId == BreweryId)
                    .Select(x => new BreweryDTO
                    {
                        BreweryId = x.BreweryId,
                        BreweryName = x.Name
                    }).FirstOrDefaultAsync();

                return brewery;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SaveBrewery(InputDTO breweryInput)
        {
            try
            {
                Brewery brewery = new Brewery();
                brewery.Name = breweryInput.Name;
                _ttDBContext.Add(brewery);
                await _ttDBContext.SaveChangesAsync();
                return "Data Saved Successfully";
            }
            catch (Exception ex)
            {
                return "Data Save Failed";
            }
        }

        public async Task<string> UpdateBrewery(InputDTO breweryInput)
        {
            try
            {
                var existingBrewery = _ttDBContext.Breweries.FirstOrDefault(x => x.BreweryId == breweryInput.Id);

                if (existingBrewery != null)
                {
                    existingBrewery.Name = breweryInput.Name;

                }
                await _ttDBContext.SaveChangesAsync();
                return "Data update Successfully";
            }
            catch (Exception ex)
            {
                return "Data update Failed";
            }
        }
        #endregion

        #region Bar
        public async Task<List<BarDTO>> GetBars()
        {
            try
            {
                List<BarDTO> bars = new List<BarDTO>();
                bars = await _ttDBContext.Bars.Select(x => new BarDTO
                {
                    BarId = x.BarId,
                    BarName = x.Name,
                    Address = x.Address
                }).ToListAsync();

                return bars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BarDTO> GetBar(int BarId)
        {
            try
            {

                BarDTO bars = new BarDTO();
                bars = await _ttDBContext.Bars.Where(x => x.BarId == BarId).Select(x => new BarDTO
                {
                    BarId = x.BarId,
                    BarName = x.Name,
                    Address = x.Address
                }).FirstOrDefaultAsync();

                return bars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SaveBar(InputDTO barInput)
        {
            try
            {
                Bar bar = new Bar();
                bar.Name = barInput.Name;
                bar.Address = barInput.Address;
                _ttDBContext.Add(bar);
                await _ttDBContext.SaveChangesAsync();
                return "Data Saved Successfully";
            }
            catch (Exception ex)
            {
                return "Data Save Failed";
            }
        }

        public async Task<string> UpdateBar(InputDTO barInput)
        {
            try
            {
                var existingBar = _ttDBContext.Bars.FirstOrDefault(x => x.BarId == barInput.Id);

                if (existingBar != null)
                {
                    existingBar.Name = barInput.Name;
                    existingBar.Address = barInput.Address;
                }
                await _ttDBContext.SaveChangesAsync();
                return "Data update Successfully";
            }
            catch (Exception ex)
            {
                return "Data update Failed";
            }
        }
        #endregion

        #region Beer
        public async Task<List<BeerDTO>> GetBeers(double? gtAlocholByVolume, double? ltAlocholByVolume)
        {
            try
            {
                List<BeerDTO> beers = new List<BeerDTO>();
                beers = await _ttDBContext.Beers
                    .Where(x => (gtAlocholByVolume == null || x.PercentageAlcholByVolume > gtAlocholByVolume)
                           && (ltAlocholByVolume == null || x.PercentageAlcholByVolume < ltAlocholByVolume))
                    .Select(x => new BeerDTO
                    {
                        BeerId = x.BeerId,
                        BeerName = x.Name,
                        PercentageAlcholByVolume = x.PercentageAlcholByVolume
                    }).ToListAsync();

                return beers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BeerDTO> GetBeer(int BeerId)
        {
            try
            {

                BeerDTO bars = new BeerDTO();
                bars = await _ttDBContext.Beers.Where(x => x.BeerId == BeerId).Select(x => new BeerDTO
                {
                    BeerId = x.BeerId,
                    BeerName = x.Name,
                    PercentageAlcholByVolume = x.PercentageAlcholByVolume
                }).FirstOrDefaultAsync();

                return bars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SaveBeer(InputDTO beerInput)
        {
            try
            {
                Beer beer = new Beer();
                beer.Name = beerInput.Name;
                beer.PercentageAlcholByVolume = beerInput.PercentageAlcholByVolume;
                _ttDBContext.Add(beer);
                await _ttDBContext.SaveChangesAsync();
                return "Data Saved Successfully";
            }
            catch (Exception ex)
            {
                return "Data Save Failed";
            }
        }

        public async Task<string> UpdateBeer(InputDTO beerInput)
        {
            try
            {
                var existingBeers = _ttDBContext.Beers.FirstOrDefault(x => x.BeerId == beerInput.Id);

                if (existingBeers != null)
                {
                    existingBeers.Name = beerInput.Name;
                    existingBeers.PercentageAlcholByVolume = beerInput.PercentageAlcholByVolume;
                }
                await _ttDBContext.SaveChangesAsync();
                return "Data update Successfully";
            }
            catch (Exception ex)
            {
                return "Data update Failed";
            }
        }
        #endregion

        #region Brewery and  Beer

        public async Task<List<BreweryBeerDTO>> GetBreweryAndBeersById(int breweryId)
        {
            try
            {
                List<BreweryBeerDTO> breweries = new List<BreweryBeerDTO>();
                breweries = await _ttDBContext.Mapping_Brewery_Beers
                                    .Where(x => x.BreweryId == breweryId)
                                     .Select(x => new BreweryBeerDTO
                                     {
                                         BeerId = x.BeerId,
                                         BeerName = x.Beer.Name,
                                         BreweryId = x.BreweryId,
                                         BreweryName = x.Brewery.Name
                                     }).ToListAsync();

                return breweries;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BreweryBeerDTO>> GetBreweryAndBeers()
        {
            try
            {


                List<BreweryBeerDTO> breweries = new List<BreweryBeerDTO>();
                breweries = await _ttDBContext.Mapping_Brewery_Beers
                            .Select(x => new BreweryBeerDTO
                            {
                                BeerId = x.BeerId,
                                BeerName = x.Beer.Name,
                                BreweryId = x.BreweryId,
                                BreweryName = x.Brewery.Name
                            }).ToListAsync();

                return breweries;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SaveBreweryBeer(MappingInputDTO input)
        {
            try
            {
                Mapping_Brewery_Beer brewery = new Mapping_Brewery_Beer();
                brewery.BeerId = input.BeerId;
                brewery.BreweryId = input.BreweryId;
                _ttDBContext.Add(brewery);
                await _ttDBContext.SaveChangesAsync();
                return "Data Saved Successfully";
            }
            catch (Exception ex)
            {
                return "Data Save Failed";
            }
        }


        #endregion


        #region Bar and  Beer



        public async Task<List<BarBeerDTO>> GetBarAndBeersById(int barId)
        {
            try
            {
                List<BarBeerDTO> bars = new List<BarBeerDTO>();
                bars = await _ttDBContext.Mapping_Bar_Beers
                                    .Where(x => x.BarId == barId)
                                     .Select(x => new BarBeerDTO
                                     {
                                         BeerId = x.BeerId,
                                         BeerName = x.Beer.Name,
                                         BarId = x.BarId,
                                         BarName = x.Bar.Name
                                     }).ToListAsync();

                return bars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BarBeerDTO>> GetBarAndBeers()
        {
            try
            {
                List<BarBeerDTO> bars = new List<BarBeerDTO>();
                bars = await _ttDBContext.Mapping_Bar_Beers
                                     .Select(x => new BarBeerDTO
                                     {
                                         BeerId = x.BeerId,
                                         BeerName = x.Beer.Name,
                                         BarId = x.BarId,
                                         BarName = x.Bar.Name
                                     }).ToListAsync();

                return bars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SaveBarBeer(MappingInputDTO input)
        {
            try
            {
                Mapping_Bar_Beer bar = new Mapping_Bar_Beer();
                bar.BeerId = input.BeerId;
                bar.BarId = input.BarId;
                _ttDBContext.Add(bar);
                await _ttDBContext.SaveChangesAsync();
                return "Data Saved Successfully";
            }
            catch (Exception ex)
            {
                return "Data Save Failed";
            }
        }

        #endregion

    }
}
