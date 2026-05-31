using StarWarsPlanetsStats.Converters;
using StarWarsPlanetsStats.Data;
using StarWarsPlanetsStats.Extensions;
using StarWarsPlanetsStats.Models;
using StarWarsPlanetsStats.UI;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Text.Json;

namespace StarWarsPlanetsStats.App;

public class StarWarsApp : IApp
{
    private List<Planet> Planets { get; init; } = [];
    private Dictionary<string, PropertyInfo> UserOptions { get; init; }

    private readonly IUserInteractor _userInteractor;
    private readonly IApiCaller _apiCaller;
    private readonly IPlanetsFetcher _planetsFetcher;
    private readonly IOutput _output;

    public StarWarsApp(IUserInteractor userInteractor,
        IApiCaller apiCaller,
        IPlanetsFetcher planetsFetcher,
        IOutput output
        )
    {
        _userInteractor = userInteractor;
        _apiCaller = apiCaller;
        _planetsFetcher = planetsFetcher;
        _output = output;

        UserOptions = new Dictionary<string, PropertyInfo>() {
            { "population", typeof(Planet).GetProperty(nameof(Planet.Population))! },
            { "diameter", typeof(Planet).GetProperty(nameof(Planet.Diameter))! },
            { "surface water", typeof(Planet).GetProperty(nameof(Planet.SurfaceWaterPercentage))! }
        };
    }

    public async Task RunAsync()
    {
        var newPlanets = await _planetsFetcher.GetFromJsonAsync(await _apiCaller.GetAsync("planets"));
        if (newPlanets is not null && newPlanets.Count > 0)
        {
            Planets.AddRange(newPlanets);
        }

        // display
        _output.DisplayTable(Planets);

        // take user input
        string? input = TakeChoiceFromUser();


        // handle user input 
        UserOptions.TryGetValue(input!, out PropertyInfo? selectedOption);
        if(selectedOption is not null)
        {
            GetMinMaxStatOfPlanet(selectedOption);
        }
        else
        {
            throw new InvalidOperationException("The selected option couldn't be executed.");
        }
    }

    private void DisplayUserOptions(string[] options)
    {
        _userInteractor.WriteLine("The statistics of which property would you like to see?");
        _userInteractor.WriteLine(string.Join(Environment.NewLine, options));
    }
    private string? TakeChoiceFromUser()
    {
        string? input;
        bool userInputIsCorrect;
        do
        {
            // stats selector
            DisplayUserOptions(UserOptions.Keys.ToArray());

            input = _userInteractor.ReadLine();

            userInputIsCorrect = input is not null && UserOptions.ContainsKey(input);

            if (input is not null)
            {
                input = input.ToLower();
            }

            if (!userInputIsCorrect)
            {
                _userInteractor.WriteLine("Invalid choice.\n---------------");
            }
        }
        while (!userInputIsCorrect);
        return input;
    }

    private void GetMinMaxStatOfPlanet(PropertyInfo? property)
    {
        if (property is not null && typeof(Planet).GetProperty(property.Name) is not null)
        {
            var minStat = Planets.MinBy(planet => planet?.GetType()?.GetProperty(property.Name)?.GetValue(planet));
            var maxStat = Planets.MaxBy(planet => planet?.GetType()?.GetProperty(property.Name)?.GetValue(planet));
            if (minStat is not null && maxStat is not null)
            {
                _userInteractor.Write($"Max {property.GetDisplayNameValue().ToLower()} is {maxStat.GetType()?.GetProperty(property.Name)?.GetValue(maxStat)} (planet: {maxStat.Name}), ");
                _userInteractor.Write($"min {property.GetDisplayNameValue().ToLower()} is {minStat.GetType()?.GetProperty(property.Name)?.GetValue(minStat)} (planet: {minStat.Name})");
            }
        }
        else
        {
            throw new InvalidOperationException("Invalid property has been passed.");
        }

    }
}