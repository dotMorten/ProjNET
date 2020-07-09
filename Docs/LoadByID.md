### Loading a projection by Spatial Reference ID (SRID)
Proj.NET doesn't have an embedded Spatial Reference ID database like the [EPSG database](http://www.epsg.org/Geodetic.html), so there is no default logic for loading a spatial reference by ID.
However Proj.NET does ship with a comma-separated file with EPSG codes, and you can easily iterate through these to load a specific ID. This is not as efficient as loading the data from an indexed database, but it's simple and easy to deploy.

Below is a simple class for loading a coordinate system by SRID.

{{
using System;
using System.Collections.Generic;
using System.Text;
using ProjNET.CoordinateSystems;
public class SridReader
{
	private static string filename = "SRID.csv"; //Change this to point to the SRID.CSV file.

	public struct WKTstring {
		/// <summary>Well-known ID</summary>
		public int WKID;
		/// <summary>Well-known Text</summary>
		public string WKT;
	}

	/// <summary>Enumerates all SRID's in the SRID.csv file.</summary>
	/// <returns>Enumerator</returns>
	public static IEnumerable<WKTstring> GetSRIDs()
	{
		using (System.IO.StreamReader sr = System.IO.File.OpenText(filename))
		{
			while (!sr.EndOfStream)
			{
				string line = sr.ReadLine();
				int split = line.IndexOf(';');
				if (split > -1)
				{
					WKTstring wkt = new WKTstring();
					wkt.WKID = int.Parse(line.Substring(0, split));
					wkt.WKT = line.Substring(split + 1);
					yield return wkt;
				}
			}
			sr.Close();
		}
	}
	/// <summary>Gets a coordinate system from the SRID.csv file</summary>
	/// <param name="id">EPSG ID</param>
	/// <returns>Coordinate system, or null if SRID was not found.</returns>
	public static ICoordinateSystem GetCSbyID(int id)
	{
		foreach (SridReader.WKTstring wkt in SridReader.GetSRIDs())
		{
			if (wkt.WKID == id) //We found it!
			{
				return ProjNET.Converters.WellKnownText.CoordinateSystemWktReader.Parse(wkt.WKT) as ICoordinateSystem;
			}
		}
		return null;
	}
}
}}

Loading a CS by ID is then as simple as:
{{
ICoordinateSystem cs = SridReader.GetCSbyID(4326);
}}

The demo website also shows how to use this approach.

For better performance I would recommend changing the "GetCSbyID()" method to connect to a database and query for the WKT by SRID. The .CSV file should be fairly easy to import into the database.