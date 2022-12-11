using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CountryController
{
    private readonly CountryService _countryService;
    public CountryController(CountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet("GetCountries")]
    public async Task<Response<List<GetCountriesDto>>> GetCountries()
    {
        return await _countryService.GetCountries();
    }

    [HttpPost("InsertNewCountry")]
    public async Task<Response<AddCountriesDto>> AddCountry(AddCountriesDto country)
    {
        return await _countryService.AddCountry(country);
    }

    [HttpPut("UpdateCountries")]
    public async Task<Response<AddCountriesDto>> UpdateCountries(AddCountriesDto country)
    {
        return await _countryService.UpdateCountry(country);
    }

    [HttpDelete("DeleteCountries")]
    public async Task<Response<string>> DeleteCountry(int id)
    {
        return await _countryService.DeleteCountry(id);
    }

    // Get Full Informations
    [HttpGet("GetFullInfo")]
    public async Task<Response<List<GetRegionCountryLocation>>> GetFullInformation()
    {
        return await _countryService.GetFullInformation();
    }
}
