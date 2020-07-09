### Constructing a Coordinate System by code
Creating a coordinate system by code is a little more tedious than [constructing it from Well-known text](CreateCSByWKT) or [create it by an SRID](LoadByID).
It also requires you to know all the parameters for the coordinate system, but on the other hand it gives you the power to construct any spatial reference where no WKT or SRID exists.

To create a coordinate system, you first need to create a Coordinate System factory:
{{
CoordinateSystemFactory cFac = new ProjNET.CoordinateSystems.CoordinateSystemFactory();
}}
#### Creating a geographic coordinate system
A geographic coordinate system consists of the following:
* A prime meridian (usually Greenwich)
* A datum
* An ellipsoid (in the datum)
* An angular unit (usually degrees)
* A couple of axis (usually Latitude/Longitude)
{{
//Create Bessel 1840 geographic coordinate system
IEllipsoid ellipsoid = cFac.CreateFlattenedSphere("Bessel 1840", 6377397.155, 299.15281, LinearUnit.Metre);
IHorizontalDatum datum = cFac.CreateHorizontalDatum("Bessel 1840", DatumType.HD_Geocentric, ellipsoid, null);
IGeographicCoordinateSystem gcs = cFac.CreateGeographicCoordinateSystem("Bessel 1840", AngularUnit.Degrees, datum,
	PrimeMeridian.Greenwich, new AxisInfo("Lon", AxisOrientationEnum.East),
	new AxisInfo("Lat", AxisOrientationEnum.North));
}}
The are a number of predefined common geographic coordinate systems you can use. Example:
{{
GeographicCoordinateSystem wgs84 = GeographicCoordinateSystem.WGS84;
}}
#### Creating a projected coordinate system
A projected coordinate system consists of the following:
* A geographic coordinate system
* A projection
* A linear unit
* A set of axes
The projection contains a projection type (see WKT name in "[Supported projections](Supported-projections)") and a set of parameters.
 
{{
//Create World Mercator projected coordinate system
List<ProjectionParameter> parameters = new List<ProjectionParameter>(4);
parameters.Add(new ProjectionParameter("latitude_of_origin", 0));
parameters.Add(new ProjectionParameter("central_meridian", 0));
parameters.Add(new ProjectionParameter("false_easting", 0));
parameters.Add(new ProjectionParameter("false_northing", 0));
IProjection projection = cFac.CreateProjection("Mercator_1SP", "Mercator_1SP", parameters);
IProjectedCoordinateSystem coordsys = cFac.CreateProjectedCoordinateSystem("World Mercator WGS84",
    GeographicCoordinateSystem.WGS84, projection, LinearUnit.Metre,
    new AxisInfo("East", AxisOrientationEnum.East), new AxisInfo("North", AxisOrientationEnum.North));
}}
The projection CS class comes with a helper method for defining a WGS84 based Universal Transverse Mercator (UTM) projection, by specifying a UTM zone and northern/southern hemisphere:
{{
IProjectedCoordinateSystem UTM32N = ProjectedCoordinateSystem.WGS84_UTM(32,true)
}}
#### Converting a coordinate system to a string representation
Once a coordinate system has been created, you can easily convert the projection into a readable Well-known text, by using its WKT property:
{{
string WellKnownText = coordsys.WKT;
}}
Similarly you can get the OGC XML representation using
{{
string csXML = coordsys.XML;
}}