# CEP Aberto

[CEP Aberto](htttp://www.cepaberto.com) API wrapper written in C# (.NET).
Implements all V3 features
Fully tested!

[![GitHub license](https://img.shields.io/github/license/guibranco/CEPAberto)](https://github.com/guibranco/CEPAberto)

![CEPAberto](https://raw.githubusercontent.com/guibranco/CEPAberto/master/logo.png)

## CI/CD

| Build status | Last commit | Tests | Coverage | Code Smells | LOC |
|--------------|-------------|-------|----------|-------------|-----|
| [![Build status](https://ci.appveyor.com/api/projects/status/l9cuqk1s1gdppqpn/branch/master?svg=true)](https://ci.appveyor.com/project/guibranco/CEPAberto) | [![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/CEPAberto/master)](https://github.com/guibranco/CEPAberto) | [![AppVeyor tests (branch)](https://img.shields.io/appveyor/tests/guibranco/CEPAberto/master?compact_message)](https://ci.appveyor.com/project/guibranco/CEPAberto) | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=guibranco_CEPAberto&metric=coverage)](https://sonarcloud.io/dashboard?id=guibranco_CEPAberto) | [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=guibranco_CEPAberto&metric=code_smells)](https://sonarcloud.io/dashboard?id=guibranco_CEPAberto) | [![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=guibranco_CEPAberto&metric=ncloc)](https://sonarcloud.io/dashboard?id=guibranco_CEPAberto)

## Code Quality

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/e9fd678b9bfe4d729e8970ed3fb506d9)](https://www.codacy.com/gh/guibranco/CEPAberto/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=guibranco/CEPAberto&amp;utm_campaign=Badge_Grade)
[![Codacy Badge](https://app.codacy.com/project/badge/Coverage/e9fd678b9bfe4d729e8970ed3fb506d9)](https://www.codacy.com/gh/guibranco/CEPAberto/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=guibranco/CEPAberto&amp;utm_campaign=Badge_Grade)
[![codecov](https://codecov.io/gh/guibranco/CEPAberto/branch/master/graph/badge.svg)](https://codecov.io/gh/guibranco/CEPAberto)

[![Maintainability](https://api.codeclimate.com/v1/badges/f12c9899307a319a1cc4/maintainability)](https://codeclimate.com/github/guibranco/CEPAberto/maintainability)
[![Test Coverage](https://api.codeclimate.com/v1/badges/f12c9899307a319a1cc4/test_coverage)](https://codeclimate.com/github/guibranco/CEPAberto/test_coverage)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=guibranco_CEPAberto&metric=alert_status)](https://sonarcloud.io/dashboard?id=guibranco_CEPAberto)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_CEPAberto&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=guibranco_CEPAberto)

[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=guibranco_CEPAberto&metric=sqale_index)](https://sonarcloud.io/dashboard?id=guibranco_CEPAberto)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=guibranco_CEPAberto&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=guibranco_CEPAberto)

[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_CEPAberto&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=guibranco_CEPAberto)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_CEPAberto&metric=security_rating)](https://sonarcloud.io/dashboard?id=guibranco_CEPAberto)

[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=guibranco_CEPAberto&metric=bugs)](https://sonarcloud.io/dashboard?id=guibranco_CEPAberto)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=guibranco_CEPAberto&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=guibranco_CEPAberto)

---

## Installation

### Github Releases

[![GitHub last release](https://img.shields.io/github/release-date/guibranco/CEPAberto.svg?style=flat)](https://github.com/guibranco/CEPAberto) [![Github All Releases](https://img.shields.io/github/downloads/guibranco/CEPAberto/total.svg?style=flat)](https://github.com/guibranco/CEPAberto)

Download the latest zip file from the [Release](https://github.com/GuiBranco/CEPAberto/releases) page.

### Nuget package manager

| Package | Version | Downloads |
|------------------|:-------:|:-------:|
| **CEPAberto** | [![CEPAberto NuGet Version](https://img.shields.io/nuget/v/CEPAberto.svg?style=flat)](https://www.nuget.org/packages/CEPAberto/) | [![CEPAberto NuGet Downloads](https://img.shields.io/nuget/dt/CEPAberto.svg?style=flat)](https://www.nuget.org/packages/CEPAberto/) |

---

## Features

This client supports the following operations/features of the API V3:

1.  Get data based on postal code (CEP).
2.  Get data of a nearest geo location (lat/lon) (Max of 10km).
3.  Get data based on state initials (UF), city, neighborhood and street/address.
4.  Get list of cities of a state based on state initials.
5.  Update the postal code (CEP).

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
