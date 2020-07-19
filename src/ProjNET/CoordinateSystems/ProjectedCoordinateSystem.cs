// Copyright 2005 - 2020 - Morten Nielsen (www.xaml.dev)
//
// This file is part of ProjNet.
//
// MIT License  
//  
// Permission is hereby granted, free of charge, to any person obtaining a copy of this  
// software and associated documentation files (the "Software"), to deal in the Software  
// without restriction, including without limitation the rights to use, copy, modify, merge,  
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons  
// to whom the Software is furnished to do so, subject to the following conditions:  
//  
// The above copyright notice and this permission notice shall be included in all copies or  
// substantial portions of the Software.  
//  
// THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,  
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR  
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE  
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR  
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER  
// DEALINGS IN THE SOFTWARE.  

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ProjNet.CoordinateSystems
{
	/// <summary>
	/// A 2D cartographic coordinate system.
	/// </summary>
	public class ProjectedCoordinateSystem : HorizontalCoordinateSystem,  IProjectedCoordinateSystem
	{
		/// <summary>
		/// Initializes a new instance of a projected coordinate system
		/// </summary>
		/// <param name="geographicCoordinateSystem">Geographic coordinate system</param>
		/// <param name="linearUnit">Linear unit</param>
		/// <param name="projection">Projection</param>
		/// <param name="axisInfo">Axis info</param>
		/// <param name="name">Name</param>
		/// <param name="authority">Authority name</param>
		/// <param name="code">Authority-specific identification code.</param>
		/// <param name="alias">Alias</param>
		/// <param name="abbreviation">Abbreviation</param>
		/// <param name="remarks">Provider-supplied remarks</param>
		internal ProjectedCoordinateSystem(IGeographicCoordinateSystem geographicCoordinateSystem,
			ILinearUnit linearUnit, IProjection projection, List<AxisInfo> axisInfo,
			string name, string authority, long code, string alias,
			string remarks, string abbreviation)
			: base(geographicCoordinateSystem.HorizontalDatum, axisInfo, name, authority, code, alias, abbreviation, remarks)
		{
			_GeographicCoordinateSystem = geographicCoordinateSystem;
			_LinearUnit = linearUnit;
			_Projection = projection;
		}

		#region Predefined projected coordinate systems

		/// <summary>
		/// Universal Transverse Mercator - WGS84
		/// </summary>
		/// <param name="Zone">UTM zone</param>
		/// <param name="ZoneIsNorth">true of Northern hemisphere, false if southern</param>
		/// <returns>UTM/WGS84 coordsys</returns>
		public static ProjectedCoordinateSystem WGS84_UTM(int Zone, bool ZoneIsNorth)
		{
			List<ProjectionParameter> pInfo = new List<ProjectionParameter>();
			pInfo.Add(new ProjectionParameter("latitude_of_origin", 0));
			pInfo.Add(new ProjectionParameter("central_meridian", Zone * 6 - 183));
			pInfo.Add(new ProjectionParameter("scale_factor", 0.9996));
			pInfo.Add(new ProjectionParameter("false_easting", 500000));
			pInfo.Add(new ProjectionParameter("false_northing", ZoneIsNorth ? 0 : 10000000));
			//IProjection projection = cFac.CreateProjection("UTM" + Zone.ToString() + (ZoneIsNorth ? "N" : "S"), "Transverse_Mercator", parameters);
			Projection proj = new Projection("Transverse_Mercator", pInfo, "UTM" + Zone.ToString(System.Globalization.CultureInfo.InvariantCulture) + (ZoneIsNorth ? "N" : "S"),
				"EPSG", 32600 + Zone + (ZoneIsNorth ? 0 : 100), String.Empty, String.Empty, String.Empty);
			System.Collections.Generic.List<AxisInfo> axes = new List<AxisInfo>();
			axes.Add(new AxisInfo("East", AxisOrientationEnum.East));
			axes.Add(new AxisInfo("North", AxisOrientationEnum.North));
			return new ProjectedCoordinateSystem(ProjNet.CoordinateSystems.GeographicCoordinateSystem.WGS84, ProjNet.CoordinateSystems.LinearUnit.Metre, proj, axes,
				"WGS 84 / UTM zone " + Zone.ToString(System.Globalization.CultureInfo.InvariantCulture) + (ZoneIsNorth ? "N" : "S"), "EPSG", 32600 + Zone + (ZoneIsNorth ? 0 : 100),
				String.Empty, "Large and medium scale topographic mapping and engineering survey.", string.Empty);
		}

		#endregion

		#region IProjectedCoordinateSystem Members

		private IGeographicCoordinateSystem _GeographicCoordinateSystem;

		/// <summary>
		/// Gets or sets the GeographicCoordinateSystem.
		/// </summary>
		public IGeographicCoordinateSystem GeographicCoordinateSystem
		{
			get { return _GeographicCoordinateSystem; }
			set { _GeographicCoordinateSystem = value; }
		}

		private ILinearUnit _LinearUnit;

		/// <summary>
		/// Gets or sets the <see cref="LinearUnit">LinearUnits</see>. The linear unit must be the same as the <see cref="CoordinateSystem"/> units.
		/// </summary>
		public ILinearUnit LinearUnit
		{
			get { return _LinearUnit; }
			set { _LinearUnit = value; }
		}

		/// <summary>
		/// Gets units for dimension within coordinate system. Each dimension in 
		/// the coordinate system has corresponding units.
		/// </summary>
		/// <param name="dimension">Dimension</param>
		/// <returns>Unit</returns>
		public override IUnit GetUnits(int dimension)
		{
			return _LinearUnit;
		}

		private IProjection _Projection;

		/// <summary>
		/// Gets or sets the projection
		/// </summary>
		public IProjection Projection
		{
			get { return _Projection; }
			set { _Projection = value; }
		}

		/// <summary>
		/// Returns the Well-known text for this object
		/// as defined in the simple features specification.
		/// </summary>
		public override string WKT
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.AppendFormat("PROJCS[\"{0}\", {1}, {2}",Name, GeographicCoordinateSystem.WKT, Projection.WKT);
				for(int i=0;i<Projection.NumParameters;i++)
					sb.AppendFormat(CultureInfo.InvariantCulture.NumberFormat, ", {0}", Projection.GetParameter(i).WKT);
				sb.AppendFormat(", {0}", LinearUnit.WKT);
				//Skip axis info if they contain default values
				if (AxisInfo.Count != 2 ||
					AxisInfo[0].Name != "X" || AxisInfo[0].Orientation != AxisOrientationEnum.East ||
					AxisInfo[1].Name != "Y" || AxisInfo[1].Orientation != AxisOrientationEnum.North)
					for (int i = 0; i < AxisInfo.Count; i++)
						sb.AppendFormat(", {0}", GetAxis(i).WKT);
				if (!String.IsNullOrEmpty(Authority) && AuthorityCode > 0)
					sb.AppendFormat(", AUTHORITY[\"{0}\", \"{1}\"]", Authority, AuthorityCode);				
				sb.Append("]");
				return sb.ToString();
			}
		}

		/// <summary>
		/// Gets an XML representation of this object.
		/// </summary>
		public override string XML
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.AppendFormat(CultureInfo.InvariantCulture.NumberFormat,
					"<CS_CoordinateSystem Dimension=\"{0}\"><CS_ProjectedCoordinateSystem>{1}",
					this.Dimension, InfoXml);
				foreach (AxisInfo ai in this.AxisInfo)
					sb.Append(ai.XML);

				sb.AppendFormat("{0}{1}{2}</CS_ProjectedCoordinateSystem></CS_CoordinateSystem>",
					GeographicCoordinateSystem.XML, LinearUnit.XML, Projection.XML);
				return sb.ToString();
			}
		}

		/// <summary>
		/// Checks whether the values of this instance is equal to the values of another instance.
		/// Only parameters used for coordinate system are used for comparison.
		/// Name, abbreviation, authority, alias and remarks are ignored in the comparison.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>True if equal</returns>
		public override bool EqualParams(object obj)
		{
			if (!(obj is ProjectedCoordinateSystem pcs))
				return false;
			if(pcs.Dimension != this.Dimension)
				return false;
			for (int i = 0; i < pcs.Dimension; i++)
			{
				if(pcs.GetAxis(i).Orientation != this.GetAxis(i).Orientation)
					return false;
				if (!pcs.GetUnits(i).EqualParams(this.GetUnits(i)))
					return false;
			}

			return	pcs.GeographicCoordinateSystem.EqualParams(this.GeographicCoordinateSystem) && 
					pcs.HorizontalDatum.EqualParams(this.HorizontalDatum) &&
					pcs.LinearUnit.EqualParams(this.LinearUnit) &&
					pcs.Projection.EqualParams(this.Projection);
		}

		#endregion
	}
}
