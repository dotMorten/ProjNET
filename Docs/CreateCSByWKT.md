### Constructing a Coordinate System (CS) by Well-known Text (WKT)
```cs
string wkt = "GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137,298.257223563](__GCS_WGS_1984__,DATUM[__D_WGS_1984__,SPHEROID[__WGS_1984__,6378137,298.257223563)],PRIMEM[\"Greenwich\",0](__Greenwich__,0),UNIT[\"Degree\",0.0174532925199433](__Degree__,0.0174532925199433)]";
ICoordinateSystem cs = ProjNET.Converters.WellKnownText.CoordinateSystemWktReader.Parse(wkt) as ICoordinateSystem;
```
If you know that the WKT is for instance a geographic coordinate system as above, you can instead cast it to that if necessary:
```cs
IGeographicCoordinateSystem gcs = CoordinateSystemWktReader.Parse(wkt_geo) as IGeographicCoordinateSystem;
```
and similar for a projected coordinate system:
```cs
IProjectedCoordinateSystem pcs = CoordinateSystemWktReader.Parse(wkt_proj) as IProjectedCoordinateSystem;
```