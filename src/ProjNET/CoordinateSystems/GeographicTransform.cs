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

namespace ProjNet.CoordinateSystems
{
	/// <summary>
	/// The GeographicTransform class is implemented on geographic transformation objects and
	/// implements datum transformations between geographic coordinate systems.
	/// </summary>
	public class GeographicTransform : Info, IGeographicTransform
	{
		internal GeographicTransform(
			string name, string authority, long code, string alias, string remarks, string abbreviation,
			IGeographicCoordinateSystem sourceGCS, IGeographicCoordinateSystem targetGCS)
			: base(name, authority, code, alias, abbreviation, remarks)
		{
			_SourceGCS = sourceGCS;
			_TargetGCS = targetGCS;
		}

		#region IGeographicTransform Members

		private IGeographicCoordinateSystem _SourceGCS;

		/// <summary>
		/// Gets or sets the source geographic coordinate system for the transformation.
		/// </summary>
		public IGeographicCoordinateSystem SourceGCS
		{
			get { return _SourceGCS; }
			set { _SourceGCS = value; }
		}

		private IGeographicCoordinateSystem _TargetGCS;

		/// <summary>
		/// Gets or sets the target geographic coordinate system for the transformation.
		/// </summary>
		public IGeographicCoordinateSystem TargetGCS
		{
			get { return _TargetGCS; }
			set { _TargetGCS = value; }
		}

		/// <summary>
		/// Returns an accessor interface to the parameters for this geographic transformation.
		/// </summary>
		public IParameterInfo ParameterInfo
		{
			get { throw new NotImplementedException(); }
		}

		/// <summary>
		/// Transforms an array of points from the source geographic coordinate
		/// system to the target geographic coordinate system.
		/// </summary>
		/// <param name="points">On input points in the source geographic coordinate system</param>
		/// <returns>Output points in the target geographic coordinate system</returns>
        public List<double[]> Forward(List<double[]> points)
		{
			throw new NotImplementedException();
			/*
			List<Point> trans = new List<Point>(points.Count);
			foreach (Point p in points)
			{

			}
			return trans;
			*/
		}

		/// <summary>
		/// Transforms an array of points from the target geographic coordinate
		/// system to the source geographic coordinate system.
		/// </summary>
		/// <param name="points">Input points in the target geographic coordinate system,</param>
		/// <returns>Output points in the source geographic coordinate system</returns>
        public List<double[]> Inverse(List<double[]> points)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns the Well-known text for this object
		/// as defined in the simple features specification.
		/// </summary>
		public override string WKT
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Gets an XML representation of this object [NOT IMPLEMENTED].
		/// </summary>
		public override string XML
		{
			get
			{
				throw new NotImplementedException();
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
			if (!(obj is GeographicTransform gt))
				return false;
			return gt.SourceGCS.EqualParams(this.SourceGCS) && gt.TargetGCS.EqualParams(this.TargetGCS);
		}
		#endregion
	}
}
