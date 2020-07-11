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
using System.Text;

namespace ProjNet.CoordinateSystems
{
	/// <summary>
	/// Creates spatial reference objects using codes.
	/// </summary>
	/// <remarks>
	///  The codes are maintained by an external authority. A commonly used authority is EPSG, which is also used in the GeoTIFF standard and in ProjNet.
	/// </remarks>
	public interface ICoordinateSystemAuthorityFactory
	{
		/// <summary>
		/// Returns the authority name for this factory (e.g., "EPSG" or "POSC").
		/// </summary>
		string Authority { get; }
		/// <summary>
		/// Returns a projected coordinate system object corresponding to the given code.
		/// </summary>
		/// <param name="code">The identification code.</param>
		/// <returns>The projected coordinate system object with the given code.</returns>
		IProjectedCoordinateSystem CreateProjectedCoordinateSystem(long code);
		/// <summary>
		/// Returns a geographic coordinate system object corresponding to the given code.
		/// </summary>
		/// <param name="code">The identification code.</param>
		/// <returns>The geographic coordinate system object with the given code.</returns>
		IGeographicCoordinateSystem CreateGeographicCoordinateSystem(long code);
		/// <summary>
		/// Returns a horizontal datum object corresponding to the given code.
		/// </summary>
		/// <param name="code">The identification code.</param>
		/// <returns>The horizontal datum object with the given code.</returns>
		IHorizontalDatum CreateHorizontalDatum(long code);
		/// <summary>
		/// Returns an ellipsoid object corresponding to the given code.
		/// </summary>
		/// <param name="code">The identification code.</param>
		/// <returns>The ellipsoid object with the given code.</returns>
		IEllipsoid CreateEllipsoid(long code);
		/// <summary>
		/// Returns a prime meridian object corresponding to the given code.
		/// </summary>
		/// <param name="code">The identification code.</param>
		/// <returns>The prime meridian object with the given code.</returns>
		IPrimeMeridian CreatePrimeMeridian(long code);
		/// <summary>
		/// Returns a linear unit object corresponding to the given code.
		/// </summary>
		/// <param name="code">The identification code.</param>
		/// <returns>The linear unit object with the given code.</returns>
		ILinearUnit CreateLinearUnit(long code);
		/// <summary>
		/// Returns an <see cref="IAngularUnit">angular unit</see> object corresponding to the given code.
		/// </summary>
		/// <param name="code">The identification code.</param>
		/// <returns>The angular unit object for the given code.</returns>
		IAngularUnit CreateAngularUnit(long code);
		/// <summary>
		/// Creates a <see cref="IVerticalDatum"/> from a code.
		/// </summary>
		/// <param name="code">Authority code</param>
		/// <returns>Vertical datum for the given code</returns>
		IVerticalDatum CreateVerticalDatum(long code);
		/// <summary>
		/// Create a <see cref="IVerticalCoordinateSystem">vertical coordinate system</see> from a code.
		/// </summary>
		/// <param name="code">Authority code</param>
		/// <returns></returns>
		IVerticalCoordinateSystem CreateVerticalCoordinateSystem(long code);
		/// <summary>
		/// Creates a 3D coordinate system from a code.
		/// </summary>
		/// <param name="code">Authority code</param>
		/// <returns>Compound coordinate system for the given code</returns>
		ICompoundCoordinateSystem CreateCompoundCoordinateSystem(long code);
		/// <summary>
		/// Creates a <see cref="IHorizontalCoordinateSystem">horizontal co-ordinate system</see> from a code.
		/// The horizontal coordinate system could be geographic or projected.
		/// </summary>
		/// <param name="code">Authority code</param>
		/// <returns>Horizontal coordinate system for the given code</returns>
		IHorizontalCoordinateSystem CreateHorizontalCoordinateSystem(long code);
		/// <summary>
		/// Gets a description of the object corresponding to a code.
		/// </summary>
		string DescriptionText { get; }
		/// <summary>
		/// Gets the Geoid code from a WKT name.
		/// </summary>
		/// <remarks>
		///  In the OGC definition of WKT horizontal datums, the geoid is referenced 
		/// by a quoted string, which is used as a key value. This method converts 
		/// the key value string into a code recognized by this authority.
		/// </remarks>
		/// <param name="wkt"></param>
		/// <returns></returns>
		string GeoidFromWktName(string wkt);
		/// <summary>
		/// Gets the WKT name of a Geoid.
		/// </summary>
		/// <remarks>
		///  In the OGC definition of WKT horizontal datums, the geoid is referenced by 
		/// a quoted string, which is used as a key value. This method gets the OGC WKT 
		/// key value from a geoid code.
		/// </remarks>
		/// <param name="geoid"></param>
		/// <returns></returns>
		string WktGeoidName(string geoid);		
	}
}
