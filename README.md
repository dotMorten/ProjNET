## Not maintained
This project was previously hosted on CodePlex - I merely moved this to GitHub and made sure it'll build with latest Visual Studio.
Beyond that, this project isn't currently maintained.

## .NET Spatial Reference and Projection Engine
Proj.NET performs point-to-point coordinate conversions between geodetic coordinate systems for use in fx. Geographic Information Systems (GIS) or GPS applications. The spatial reference model used adheres to the [Simple Features specification](http://www.opengeospatial.org/standards/sfo).

* [Read the FAQ](FAQ) for common questions.
* [Popular Well-Known Text representations for Spatial Reference Systems](CommonWellKnownText)

### Supports
* Datum transformations
* Geographic, Geocentric, and Projected coordinate systems
* .NET Standard 1.0, so will run with any .NET Standard 1.0 complaint framework (ie all of them!)
* Converts coordinate systems to/from [Well-Known Text](Well-Known-Text) (WKT) and to XML

### Projection types currently supported
* Mercator
* Transverse Mercator
* Albers
* Lambert Conformal
* Krovak
See [Supported projections](Supported-projections) for details.

### Nuget
There's also a package available in the Nuget Gallery, created by Mathieu Cartoixa [Proj.NET 1.2](https://nuget.org/packages/ProjNet)

### Resources
For an introduction to spatial reference systems [see here](https://www.xaml.dev/post/Spatial-references2c-coordinate-systems2c-projections2c-datums2c-ellipsoids-e28093-confusing)

If you're working with Google/Bing/OpenLayers, maybe this blog post can help you: [The Google Maps / Bing Maps Spherical Mercator Projection](http://alastaira.wordpress.com/2011/01/23/the-google-maps-bing-maps-spherical-mercator-projection)

