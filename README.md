# CEP Aberto

[CEP Aberto](htttp://www.cepaberto.com) API wrapper written in C# (.NET).
Implements all V3 features
Fully tested!

[![Build status](https://ci.appveyor.com/api/projects/status/l9cuqk1s1gdppqpn/branch/master?svg=true)](https://ci.appveyor.com/project/guibranco/cepaberto/branch/master)
[![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/CEPAberto/master)](https://github.com/guibranco/CEPAberto)
[![GitHub last release](https://img.shields.io/github/release-date/guibranco/CEPAberto.svg?style=flat)](https://github.com/guibranco/CEPAbertot)
[![GitHub license](https://img.shields.io/github/license/guibranco/CEPAberto)](https://github.com/guibranco/CEPAberto)
[![time tracker](https://wakatime.com/badge/github/guibranco/CEPAberto.svg)](https://wakatime.com/badge/github/guibranco/CEPAberto)

---

## Installation

[![CEPAberto NuGet Version](https://img.shields.io/nuget/v/CepAberto.svg?style=flat)](https://www.nuget.org/packages/CEPAberto/)
[![CEPAberto NuGet Downloads](https://img.shields.io/nuget/dt/CEPAberto.svg?style=flat)](https://www.nuget.org/packages/CEPAberto/)
[![Github All Releases](https://img.shields.io/github/downloads/guibranco/CEPAberto/total.svg?style=flat)](https://github.com/guibranco/CEPAberto)

Download the latest zip file from the [Release pages](https://github.com/guibranco/CEPAberto/releases) or simple install from [NuGet](https://www.nuget.org/packages/CEPAberto) package manager.

NuGet URL: [https://www.nuget.org/packages/CEPAberto](https://www.nuget.org/packages/CEPAberto)

NuGet installation via *Package Manager Console*:

```ps

Install-Package CEPAberto

```

---

## Features

This client supports the following operations/features of the API V3:

 1. Get data based on postal code (CEP).
 2. Get data of a nearest geo location (lat/lon) (Max of 10km).
 3. Get data based on state initials (UF), city, neighborhood and street/address.
 4. Get list of cities of a state based on state initials.
 5. Update the postal code (CEP).

 ---

## Setup the CEPAbertoClient

Initializes a new instance of **CEPAbertoClient** class.
The API token can be found at [http://www.cepaberto.com/api_key](http://www.cepaberto.com/api_key) (A free registration is required!)

```cs

var client = new CEPAbertoClient("my API token");
//var postalData = client.GetData("00000000");
//var cities = client.GetCities("SP");

```

## Get data based on postal code (CEP)

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
    Console.WriteLine("No data for the zip code {0} available", postalCode);

```

### Get data of a nearest geo location (lat/lon) (Max of 10km)

Searches for the first postal code closest to the requested coordinates, limited to 10km (API limit, not library)

 ```cs

var client = new CEPAbertoClient("my API key");
var result = client.GetData("-20.55", "-43.63");

if(result.Success)
    Console.WriteLine("Postal code found: {0}", result.PostalCode);
else
    Console.WriteLine("Unable to find a postal data for the coordinates supplied!");

```

## Get data based on state initials (UF), city, neighborhood and street/address

Searches for a postal code data for the address supplied. Neighborhood and Street/Address are optional!

```cs

var client = new CEPAbertoClient("my API key");
var result = client.GetData("SP","Ubatuba");

if(result.Success)
    Console.WriteLine("Postal code found: {0}", result.PostalCode);
else
    Console.WriteLine("Cannot find postal code for Ubatuba/SP");

```

## Get list of cities of a state based on state initials

Get a list of cities for a given state (use state initials aka UF)

```cs

var client = new CEPAbertoClient("my API key");
var result = client.GetCities("AM");

if(result.Success)
    foreach(var city in result.Cities)
        Console.WriteLine("Found city {0} in Amazonas (AM)", city.Name);

```

## Update the postal code (CEP)

Request an update on postal codes that may be outdated or not registered.
Accepts upon 100 postal codes (CEP)

```cs

var client = new CEPAbertoClient("my API key");
var result = client.Update("03177010");

if(result.Success)
    Console.WriteLine("Success on request update on postal code 03177-010");

```
