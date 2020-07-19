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
	/// A 3D coordinate system, with its origin at the center of the Earth.
	/// </summary>
	public class GeocentricCoordinateSystem : CoordinateSystem, IGeocentricCoordinateSystem
	{
		internal GeocentricCoordinateSystem(IHorizontalDatum datum, ILinearUnit linearUnit, IPrimeMeridian primeMeridian, List<AxisInfo> axisinfo,
			string name, string authority, long code, string alias, 
			string remarks, string abbreviation)
			: base(name, authority, code, alias, abbreviation, remarks, axisinfo)
		{
			_HorizontalDatum = datum;
			_LinearUnit = linearUnit;
			_Primemeridan = primeMeridian;
			if (axisinfo.Count != 3)
				throw new ArgumentException("Axis info should contain three axes for geocentric coordinate systems");
		}

		#region Predefined geographic coordinate systems

		/// <summary>
		/// Creates a geocentric coordinate system based on the WGS84 ellipsoid, suitable for GPS measurements
		/// </summary>
		public static IGeocentricCoordinateSystem WGS84
		{
			get
			{
				return new CoordinateSystemFactory().CreateGeocentricCoordinateSystem("WGS84 Geocentric",
					CoordinateSystems.HorizontalDatum.WGS84, CoordinateSystems.LinearUnit.Metre, 
					CoordinateSystems.PrimeMeridian.Greenwich);
			}
		}

		#endregion

		#region IGeocentricCoordinateSystem Members

		private IHorizontalDatum _HorizontalDatum;

		/// <summary>
		/// Returns the HorizontalDatum. The horizontal datum is used to determine where
		/// the centre of the Earth is considered to be. All coordinate points will be 
		/// measured from the centre of the Earth, and not the surface.
		/// </summary>
		public IHorizontalDatum HorizontalDatum
		{
			get { return _HorizontalDatum; }
			set { _HorizontalDatum = value; }
		}

		private ILinearUnit _LinearUnit;

		/// <summary>
		/// Gets the units used along all the axes.
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

		private IPrimeMeridian _Primemeridan;

		/// <summary>
		/// Returns the PrimeMeridian.
		/// </summary>
		public IPrimeMeridian PrimeMeridian
		{
			get { return _Primemeridan; }
			set { _Primemeridan = value; }
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
				sb.AppendFormat("GEOCCS[\"{0}\", {1}, {2}, {3}", Name, HorizontalDatum.WKT, PrimeMeridian.WKT, LinearUnit.WKT);
				//Skip axis info if they contain default values				
				if (AxisInfo.Count != 3 ||
					AxisInfo[0].Name != "X" || AxisInfo[0].Orientation != AxisOrientationEnum.Other ||
					AxisInfo[1].Name != "Y" || AxisInfo[1].Orientation != AxisOrientationEnum.East ||
					AxisInfo[2].Name != "Z" || AxisInfo[2].Orientation != AxisOrientationEnum.North)
					for (int i = 0; i < AxisInfo.Count; i++)
						sb.AppendFormat(", {0}", GetAxis(i).WKT);
				if (!String.IsNullOrEmpty(Authority) && AuthorityCode>0)
					sb.AppendFormat(", AUTHORITY[\"{0}\", \"{1}\"]", Authority, AuthorityCode);
				sb.Append("]");
				return sb.ToString();
			}
		}

		/// <summary>
		/// Gets an XML representation of this object
		/// </summary>
		public override string XML
		{
			get
			{
				StringBuilder sb = new StringBuilder();
                sb.AppendFormat(CultureInfo.InvariantCulture.NumberFormat,
					"<CS_CoordinateSystem Dimension=\"{0}\"><CS_GeocentricCoordinateSystem>{1}",
					this.Dimension, InfoXml);				
				foreach (AxisInfo ai in this.AxisInfo)
					sb.Append(ai.XML);
				sb.AppendFormat("{0}{1}{2}</CS_GeocentricCoordinateSystem></CS_CoordinateSystem>",
					HorizontalDatum.XML, LinearUnit.XML, PrimeMeridian.XML);
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
			if (!(obj is GeocentricCoordinateSystem gcc))
				return false;
			return gcc.HorizontalDatum.EqualParams(this.HorizontalDatum) &&
				gcc.LinearUnit.EqualParams(this.LinearUnit) &&
				gcc.PrimeMeridian.EqualParams(this.PrimeMeridian);
		}

		#endregion
	}
}
