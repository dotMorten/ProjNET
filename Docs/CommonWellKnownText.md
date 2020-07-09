### Popular Well-Known Text representations of Spatial Reference Systems

Here a some of the most common WKTs. See SRID.CSV in the release for more,

#### WGS 84 geographic coordinate system
{{
GEOGCS["GCS_WGS_1984",
     DATUM["D_WGS_1984",SPHEROID["WGS_1984",6378137,298.257223563](_D_WGS_1984_,SPHEROID[_WGS_1984_,6378137,298.257223563)],
     PRIMEM["Greenwich",0](_Greenwich_,0),
     UNIT["Degree",0.0174532925199433](_Degree_,0.0174532925199433)
]
}}

#### Universal Transverse Mercator - WGS84 based
This sample includes Authority numbers. These are not strictly necessary but good practice to include.
{{
PROJCS["WGS 84 / UTM zone 32N",
     GEOGCS["WGS 84",
          DATUM["WGS_1984",
               SPHEROID["WGS 84",6378137,298.257223563,AUTHORITY["EPSG","7030"](_WGS-84_,6378137,298.257223563,AUTHORITY[_EPSG_,_7030_)],
               AUTHORITY["EPSG","6326"](_EPSG_,_6326_)
          ],
          PRIMEM["Greenwich",0,AUTHORITY["EPSG","8901"](_Greenwich_,0,AUTHORITY[_EPSG_,_8901_)],
          UNIT["degree",0.01745329251994328,AUTHORITY["EPSG","9122"](_degree_,0.01745329251994328,AUTHORITY[_EPSG_,_9122_)],
          AUTHORITY["EPSG","4326"](_EPSG_,_4326_)
     ],
     PROJECTION["Transverse_Mercator"](_Transverse_Mercator_),
     PARAMETER["latitude_of_origin",0](_latitude_of_origin_,0),
     PARAMETER["central_meridian",9](_central_meridian_,9),
     PARAMETER["scale_factor",0.9996](_scale_factor_,0.9996),
     PARAMETER["false_easting",500000](_false_easting_,500000),
     PARAMETER["false_northing",0](_false_northing_,0),
     UNIT["metre",1,AUTHORITY["EPSG","9001"](_metre_,1,AUTHORITY[_EPSG_,_9001_)],
     AUTHORITY["EPSG","32632"](_EPSG_,_32632_)
]
}}
This example is for zone 32N. To create for other zones, change the following:
* central_meridian = ZoneNumber * 6 - 183
* false_northing: 0 for North, 10000000 for South.
* Last EPSG number for projection = (32600 + Zone) and add 100 more if zone is south.

#### [Microsoft Virtual Earth](http://maps.live.com) / [Google Maps](http://maps.google.com) Mercator Projection
{{
PROJCS["Popular Visualisation CRS / Mercator", 
   GEOGCS["Popular Visualisation CRS", 
      DATUM["Popular Visualisation Datum", 
         SPHEROID["Popular Visualisation Sphere", 6378137, 0, AUTHORITY["EPSG",7059](_Popular-Visualisation-Sphere_,-6378137,-0,-AUTHORITY[_EPSG_,7059)],
         TOWGS84[0, 0, 0, 0, 0, 0, 0](0,-0,-0,-0,-0,-0,-0), AUTHORITY["EPSG",6055](_EPSG_,6055)
      ],
      PRIMEM["Greenwich", 0, AUTHORITY["EPSG", "8901"](_Greenwich_,-0,-AUTHORITY[_EPSG_,-_8901_)], 
      UNIT["degree", 0.0174532925199433, AUTHORITY["EPSG", "9102"](_degree_,-0.0174532925199433,-AUTHORITY[_EPSG_,-_9102_)], 
      AXIS["E", EAST](_E_,-EAST), 
      AXIS["N", NORTH](_N_,-NORTH), 
      AUTHORITY["EPSG",4055](_EPSG_,4055)
   ], 
   PROJECTION["Mercator"](_Mercator_), 
   PARAMETER["False_Easting", 0](_False_Easting_,-0), 
   PARAMETER["False_Northing", 0](_False_Northing_,-0), 
   PARAMETER["Central_Meridian", 0](_Central_Meridian_,-0), 
   PARAMETER["Latitude_of_origin", 0](_Latitude_of_origin_,-0), 
   UNIT["metre", 1, AUTHORITY["EPSG", "9001"](_metre_,-1,-AUTHORITY[_EPSG_,-_9001_)], 
   AXIS["East", EAST](_East_,-EAST), 
   AXIS["North", NORTH](_North_,-NORTH), 
   AUTHORITY["EPSG",3785](_EPSG_,3785)
]  
}}
*Note that this is the projection they use for display, but geometry input/output is using WGS84 geographic.