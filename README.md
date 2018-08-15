# CEP Aberto
Wrapper da API (V3) do site [CEP Aberto](http://www.cepaberto.com/) escrita em C#/.NET

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
 4. Get list of cities of a state based on state initials
 
 -----

 ### Setup the CEPAbertoClient ###
 
 Initializes a new instance of **CEPAbertoClient** class.

 Example:

 ```cs
 //Get your API token in the following page after registration: http://www.cepaberto.com/api_key
  var client = new CEPAbertoClient("my API token");
 //use the methods availables in the client variable
 ```

 ### Get data based on postal code (CEP) ###

 ```cs
 var client = new CEPABertoClient("my API key");
 var postalCode = "00000000"; //Only numbers
 var data = client.GetData(postalCode);
 if(!data.Success)
 {
    Console.WriteLine("The postal code {0} can't be found on CEP Aberto API", postalCode);
    return;
 }
 Console.WriteLine("Lat: {0} | Lon: {1}", data.Latitude, data.Longitude);

```

