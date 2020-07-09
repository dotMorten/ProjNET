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
	/// The IProjectedCoordinateSystem interface defines the standard information stored with
	/// projected coordinate system objects. A projected coordinate system is defined using a
	/// geographic coordinate system object and a projection object that defines the
	/// coordinate transformation from the geographic coordinate system to the projected
	/// coordinate systems. The instances of a single ProjectedCoordinateSystem COM class can
	/// be used to model different projected coordinate systems (e.g., UTM Zone 10, Albers)
	/// by associating the ProjectedCoordinateSystem instances with Projection instances
	/// belonging to different Projection COM classes (Transverse Mercator and Albers,
	/// respectively).
	/// </summary>
	public interface IProjectedCoordinateSystem : IHorizontalCoordinateSystem
	{
		/// <summary>
		/// Gets or sets the geographic coordinate system associated with the projected
		/// coordinate system.
		/// </summary>
		IGeographicCoordinateSystem GeographicCoordinateSystem { get; set; }
		/// <summary>
		/// Gets or sets the linear (projected) units of the projected coordinate system.
		/// </summary>
		ILinearUnit LinearUnit { get; set; }
		/// <summary>
		/// Gets or sets the projection for the projected coordinate system.
		/// </summary>
		IProjection Projection { get; set; }
	}
}
