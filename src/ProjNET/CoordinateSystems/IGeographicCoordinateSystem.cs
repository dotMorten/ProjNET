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
	/// The IGeographicCoordinateSystem interface is a subclass of IGeodeticSpatialReference and
	/// defines the standard information stored with geographic coordinate system objects.
	/// </summary>
	public interface IGeographicCoordinateSystem : IHorizontalCoordinateSystem
	{
		/// <summary>
		/// Gets or sets the angular units of the geographic coordinate system.
		/// </summary>
		IAngularUnit AngularUnit { get; set; }
		/// <summary>
		/// Gets or sets the prime meridian of the geographic coordinate system.
		/// </summary>
		IPrimeMeridian PrimeMeridian { get; set; }
		/// <summary>
		/// Gets the number of available conversions to WGS84 coordinates.
		/// </summary>
		int NumConversionToWGS84 { get; }
		/// <summary>
		/// Gets details on a conversion to WGS84.
		/// </summary>
		Wgs84ConversionInfo GetWgs84ConversionInfo(int index);
	}    
}
