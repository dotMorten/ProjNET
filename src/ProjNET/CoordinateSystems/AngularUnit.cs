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
using System.Globalization;
using System.Text;

namespace ProjNet.CoordinateSystems
{
	/// <summary>
	/// Definition of angular units.
	/// </summary>
	public class AngularUnit : Info, IAngularUnit
	{
		/// <summary>
		/// Initializes a new instance of a angular unit
		/// </summary>
		/// <param name="radiansPerUnit">Radians per unit</param>
		public AngularUnit(double radiansPerUnit)
			: this(
			radiansPerUnit,String.Empty,String.Empty,-1,String.Empty,String.Empty,String.Empty)
		{
		}

		/// <summary>
		/// Initializes a new instance of a angular unit
		/// </summary>
		/// <param name="radiansPerUnit">Radians per unit</param>
		/// <param name="name">Name</param>
		/// <param name="authority">Authority name</param>
		/// <param name="authorityCode">Authority-specific identification code.</param>
		/// <param name="alias">Alias</param>
		/// <param name="abbreviation">Abbreviation</param>
		/// <param name="remarks">Provider-supplied remarks</param>
		internal AngularUnit(double radiansPerUnit, string name, string authority, long authorityCode, string alias, string abbreviation, string remarks)
			:
			base(name, authority, authorityCode, alias, abbreviation, remarks)
		{
			_RadiansPerUnit = radiansPerUnit;
		}

		#region Predifined units

		/// <summary>
		/// The angular degrees are PI/180 = 0.017453292519943295769236907684886 radians
		/// </summary>
		public static AngularUnit Degrees
		{
			get { return new AngularUnit(0.017453292519943295769236907684886, "degree", "EPSG", 9102, "deg", String.Empty, "=pi/180 radians"); }
		}

		/// <summary>
		/// SI standard unit
		/// </summary>
		public static AngularUnit Radian
		{
			get { return new AngularUnit(1, "radian", "EPSG", 9101, "rad", String.Empty, "SI standard unit."); }
		}

		/// <summary>
		/// Pi / 200 = 0.015707963267948966192313216916398 radians
		/// </summary>
		public static AngularUnit Grad
		{
			get { return new AngularUnit(0.015707963267948966192313216916398, "grad", "EPSG", 9105, "gr", String.Empty, "=pi/200 radians."); }
		}

		/// <summary>
		/// Pi / 200 = 0.015707963267948966192313216916398 radians
		/// </summary>		
		public static AngularUnit Gon
		{
			get { return new AngularUnit(0.015707963267948966192313216916398, "gon", "EPSG", 9106, "g", String.Empty, "=pi/200 radians."); }
		}
		#endregion

		#region IAngularUnit Members

		private double _RadiansPerUnit;

		/// <summary>
		/// Gets or sets the number of radians per <see cref="AngularUnit"/>.
		/// </summary>
		public double RadiansPerUnit
		{
			get { return _RadiansPerUnit; }
			set { _RadiansPerUnit = value; }
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
				sb.AppendFormat(CultureInfo.InvariantCulture.NumberFormat,"UNIT[\"{0}\", {1}", Name, RadiansPerUnit);
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
                return String.Format(CultureInfo.InvariantCulture.NumberFormat, "<CS_AngularUnit RadiansPerUnit=\"{0}\">{1}</CS_AngularUnit>", RadiansPerUnit, InfoXml);
			}
		}

		#endregion

		/// <summary>
		/// Checks whether the values of this instance is equal to the values of another instance.
		/// Only parameters used for coordinate system are used for comparison.
		/// Name, abbreviation, authority, alias and remarks are ignored in the comparison.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>True if equal</returns>
		public override bool EqualParams(object obj)
		{
			if (!(obj is AngularUnit au))
				return false;
			return au.RadiansPerUnit == this.RadiansPerUnit;
		}
	}
}
