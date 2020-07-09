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
	/// A vertical datum of geoid model derived heights, also called GPS-derived heights.
	/// These heights are approximations of orthometric heights (H), constructed from the
	/// ellipsoidal heights (h) by the use of the given geoid undulation model (N) through
	/// the equation: H=h-N.
	/// </summary>
	public enum DatumType : int
	{
		/// <summary>
		/// Lowest possible value for horizontal datum types
		/// </summary>
		HD_Min = 1000,
		/// <summary>
		/// Unspecified horizontal datum type. Horizontal datums with this type should never
		/// supply a conversion to WGS84 using Bursa Wolf parameters.
		/// </summary>
		HD_Other = 1000,
		/// <summary>
		/// These datums, such as ED50, NAD27 and NAD83, have been designed to support
		/// horizontal positions on the ellipsoid as opposed to positions in 3-D space. These datums were designed mainly to support a horizontal component of a position in a domain of limited extent, such as a country, a region or a continent.
		/// </summary>
		HD_Classic = 1001,
		/// <summary>
		/// A geocentric datum is a "satellite age" modern geodetic datum mainly of global
		/// extent, such as WGS84 (used in GPS), PZ90 (used in GLONASS) and ITRF. These
		/// datums were designed to support both a horizontal component of position and 
		/// a vertical component of position (through ellipsoidal heights). The regional
		/// realizations of ITRF, such as ETRF, are also included in this category.
		/// </summary>
		HD_Geocentric = 1002,
		/// <summary>
		/// Highest possible value for horizontal datum types.
		/// </summary>
		HD_Max = 1999,
		/// <summary>
		/// Lowest possible value for vertical datum types.
		/// </summary>
		VD_Min = 2000,
		/// <summary>
		/// Unspecified vertical datum type.
		/// </summary>
		VD_Other = 2000,
		/// <summary>
		/// A vertical datum for orthometric heights that are measured along the plumb line.
		/// </summary>
		VD_Orthometric = 2001,
		/// <summary>
		/// A vertical datum for ellipsoidal heights that are measured along the normal to
		/// the ellipsoid used in the definition of horizontal datum.
		/// </summary>
		VD_Ellipsoidal = 2002,
		/// <summary>
		/// The vertical datum of altitudes or heights in the atmosphere. These are
		/// approximations of orthometric heights obtained with the help of a barometer or
		/// a barometric altimeter. These values are usually expressed in one of the
		/// following units: meters, feet, millibars (used to measure pressure levels), or
		/// theta value (units used to measure geopotential height).
		/// </summary>
		VD_AltitudeBarometric = 2003,
		/// <summary>
		/// A normal height system.
		/// </summary>
		VD_Normal = 2004,
		/// <summary>
		/// A vertical datum of geoid model derived heights, also called GPS-derived heights.
		/// These heights are approximations of orthometric heights (H), constructed from the
		/// ellipsoidal heights (h) by the use of the given geoid undulation model (N) 
		/// through the equation: H=h-N.
		/// </summary>
		VD_GeoidModelDerived = 2005,
		/// <summary>
		/// This attribute is used to support the set of datums generated for hydrographic
		/// engineering projects where depth measurements below sea level are needed. It is
		/// often called a hydrographic or a marine datum. Depths are measured in the 
		/// direction perpendicular (approximately) to the actual equipotential surfaces of
		/// the earth's gravity field, using such procedures as echo-sounding.
		/// </summary>
		VD_Depth = 2006,
		/// <summary>
		/// Highest possible value for vertical datum types.
		/// </summary>
		VD_Max = 2999,
		/// <summary>
		/// Lowest possible value for local datum types.
		/// </summary>
		LD_Min = 10000,
		/// <summary>
		/// Highest possible value for local datum types.
		/// </summary>
		LD_Max = 32767
	}
}
