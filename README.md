# CEP Aberto

[CEP Aberto](htttp://www.cepaberto.com) API wrapper written in C# (.NET).
Implements all V3 features
Fully tested!

[![Build status](https://ci.appveyor.com/api/projects/status/l9cuqk1s1gdppqpn?svg=true)](https://ci.appveyor.com/project/guibranco/cepaberto)
[![CEPAberto NuGet Version](https://img.shields.io/nuget/v/CEPAberto.svg)](https://www.nuget.org/packages/CEPAberto/)
[![CEPAberto NuGet Downloads](https://img.shields.io/nuget/dt/CEPAberto.svg)](https://www.nuget.org/packages/CEPAberto/)
[![Github All Releases](https://img.shields.io/github/downloads/guibranco/CEPAberto/total.svg?style=plastic)](https://github.com/guibranco/CEPAberto)

----------

NuGet package: https://www.nuget.org/packages/CEPAberto

```ps
Install-Package CEPAberto
```

## Features ##

This client supports the following operations/features of the API V3:
 1. Get data based on postal code (CEP).
 2. Get data of a nearest geolocation (lat/lon) (Max of 10km).
 3. Get data based on state initials (UF), city, neighborhood and street/address.
 4. Get list of cities of a state based on state initials.
 
 -----

 ### Setup the CEPAbertoClient ###
 
Initializes a new instance of **CEPAbertoClient** class.
The API token can be found at http://www.cepaberto.com/api_key (A free registration is required!)

```cs
var client = new CEPAbertoClient("my API token");
//var postalData = client.GetData("00000000");
//var cities = client.GetCities("SP");
```

### Get data based on postal code (CEP) ###

Searches for a postal code data based on postal code

 ```cs
var client = new CEPAbertoClient("my API key");
var postalCode = "40010000";
var result = client.GetData(postalCode);

if(result.Success)
{
    Console.WriteLine("Postal data for the zip code {0} found!", postalCode);
    Console.WriteLine("Lat: {0} | Lon: {1}", result.Latitude, result.Longitude);
}
else
    Console.Writeline("No data for the zip code {0} available", postalCode);
```

### Get data of a nearest geolocation (lat/lon) (Max of 10km) ###

Searches for the first postal code closest to the requested coordinates, limited to 10km (API limit, not library)

 ```cs
var client = new CEPAbertoClient("my API key");
var result = client.GetData("-20.55", "-43.63");

if(result.Success)
    Console.WriteLine("Postal code found: {0}", result.PostalCode);
else 
    Console.WriteLine("Unable to find a postal data for the coordinates supplied!");
```

### Get data based on state initials (UF), city, neighborhood and street/address ###

Searchs for a postal code data for the address supplied. Neighborhood and Street/Address are optional!

```cs
var client = new CEPAbertoClient("my API key");
var result = client.GetData("SP","Ubatuba");

if(result.Success)
    Console.WriteLine("Postal code found: {0}", result.PostalCode);
else
    Console.WriteLine("Cannot find postal code for Ubatuba/SP");
```

### Get list of cities of a state based on state initials ###

Get a list of cities for a given state (use state initias aka UF)

```cs
var client = new CEPAbertoClient("my API key");
var result = client.GetCities("AM");

if(result.Success)
    foreach(var city in result.Cities)
        Console.WriteLine("Found city {0} in Amazonas (AM)", city.Name);
```