### Well-Known Text Representation of Spatial Reference Systems 
The WKT Format provides a standard textual representation for spatial reference system information. The definitions of the well-known text representations are modeled after the POSC/EPSG coordinate data.

The following description is from the "[OpenGIS® Simple Features Implementation Specification for OLE/COM version 1.1](http://www.opengeospatial.org/standards/sfo)"

A spatial reference system, also referred to as a coordinate system, is a geographic (latitude-longitude), a projected (X,Y), or a geocentric (X,Y,Z) coordinate system.
The coordinate system is composed of several objects. Each object has a keyword in upper case (for example, DATUM or UNIT) followed by the defining, comma-delimited, parameters of the object in brackets. Some objects are composed of objects so the result is a nested structure. Implementations are free to substitute standard brackets ( ) for square brackets [ ](-) and should be prepared to read both forms of brackets.
The EBNF (Extended Backus Naur Form) definition for the string representation of a coordinate system is as follows, using square brackets:
```
<coordinate system> = <projected cs> | <geographic cs> | <geocentric cs>
<projected cs> = PROJCS["<name>", <geographic cs>, <projection>, {<parameter>,}* <linear unit>](__name__,-_geographic-cs_,-_projection_,-{_parameter_,}_-_linear-unit_)
<projection> = PROJECTION["<name>"](__name__)
<parameter> = PARAMETER["<name>", <value>](__name__,-_value_)
<value> = <number>
```
A data set's coordinate system is identified by the PROJCS keyword if the data are in projected coordinates, by GEOGCS if in geographic coordinates, or by GEOCCS if in geocentric coordinates.
The PROJCS keyword is followed by all of the "pieces" which define the projected coordinate system. The first piece of any object is always the name. Several objects follow the projected coordinate system name: the geographic coordinate system, the map projection, 1 or more parameters, and the linear unit of measure. All projected coordinate systems are based upon a geographic coordinate system so we will describe the pieces specific to a projected coordinate system first. As an example, UTM zone 10N on the NAD83 datum is defined as:
```
PROJCS["NAD_1983_UTM_Zone_10N",
    <geographic cs>,
    PROJECTION["Transverse_Mercator"](_Transverse_Mercator_),
    PARAMETER["False_Easting",500000.0](_False_Easting_,500000.0),
    PARAMETER["False_Northing",0.0](_False_Northing_,0.0),
    PARAMETER["Central_Meridian",-123.0](_Central_Meridian_,-123.0),
    PARAMETER["Scale_Factor",0.9996](_Scale_Factor_,0.9996),
    PARAMETER["Latitude_of_Origin",0.0](_Latitude_of_Origin_,0.0),
    UNIT["Meter",1.0](_Meter_,1.0)
]
```
The name and several objects define the geographic coordinate system object in turn: the datum, the prime meridian, and the angular unit of measure.
```
<geographic cs> = GEOGCS["<name>", <datum>, <prime meridian>, <angular unit>](__name__,-_datum_,-_prime-meridian_,-_angular-unit_)
<datum> = DATUM["<name>", <spheroid>](__name__,-_spheroid_)
<spheroid> = SPHEROID["<name>", <semi-major axis>, <inverse flattening>](__name__,-_semi-major-axis_,-_inverse-flattening_)
<semi-major axis> = <number> NOTE: semi-major axis is measured in meters and must be > 0.
<inverse flattening> = <number>
<prime meridian> = PRIMEM["<name>", <longitude>](__name__,-_longitude_)
<longitude> = <number>
```
The geographic coordinate system string for UTM zone 10 on NAD83 is
```
GEOGCS["GCS_North_American_1983",
    DATUM["D_North_American_1983",
    SPHEROID["GRS_1980",6378137,298.257222101](_GRS_1980_,6378137,298.257222101)],
    PRIMEM["Greenwich",0](_Greenwich_,0),
    UNIT["Degree",0.0174532925199433](_Degree_,0.0174532925199433)]
```
The UNIT object can represent angular or linear unit of measures.
```
<angular unit> = <unit>
<linear unit> = <unit>
<unit> = UNIT["<name>", <conversion factor>](__name__,-_conversion-factor_)
<conversion factor> = <number>
```
<conversion factor> specifies number of meters (for a linear unit) or number of radians (for an angular unit) per unit and must be greater than zero.
So the full string representation of UTM Zone 10N is
```
PROJCS["NAD_1983_UTM_Zone_10N",
    GEOGCS["GCS_North_American_1983",
        DATUM[ "D_North_American_1983",
           SPHEROID["GRS_1980",6378137,298.257222101](_GRS_1980_,6378137,298.257222101)
        ],
        PRIMEM["Greenwich",0](_Greenwich_,0),
        UNIT["Degree",0.0174532925199433](_Degree_,0.0174532925199433)
    ],
    PROJECTION["Transverse_Mercator"](_Transverse_Mercator_),
    PARAMETER["False_Easting",500000.0](_False_Easting_,500000.0),
    PARAMETER["False_Northing",0.0](_False_Northing_,0.0),
    PARAMETER["Central_Meridian",-123.0](_Central_Meridian_,-123.0),
    PARAMETER["Scale_Factor",0.9996](_Scale_Factor_,0.9996),
    PARAMETER["Latitude_of_Origin",0.0](_Latitude_of_Origin_,0.0),
    UNIT["Meter",1.0](_Meter_,1.0)
]
```
A geocentric coordinate system is quite similar to a geographic coordinate system. It is represented by
```
<geocentric cs> = GEOCCS["<name>", <datum>, <prime meridian>, <linear unit>](__name__,-_datum_,-_prime-meridian_,-_linear-unit_)
```



