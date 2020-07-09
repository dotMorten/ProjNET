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
	/// Orientation of axis. Some coordinate systems use non-standard orientations. 
	/// For example, the first axis in South African grids usually points West, 
	/// instead of East. This information is obviously relevant for algorithms
	/// converting South African grid coordinates into Lat/Long.
	/// </summary>
	public enum AxisOrientationEnum : short
	{
		/// <summary>
		/// Unknown or unspecified axis orientation. This can be used for local or fitted coordinate systems.
		/// </summary>
		Other = 0,
		/// <summary>
		/// Increasing ordinates values go North. This is usually used for Grid Y coordinates and Latitude.
		/// </summary>
		North = 1,
		/// <summary>
		/// Increasing ordinates values go South. This is rarely used.
		/// </summary>
		South = 2,
		/// <summary>
		/// Increasing ordinates values go East. This is rarely used.
		/// </summary>
		East = 3,
		/// <summary>
		/// Increasing ordinates values go West. This is usually used for Grid X coordinates and Longitude.
		/// </summary>
		West = 4,
		/// <summary>
		/// Increasing ordinates values go up. This is used for vertical coordinate systems.
		/// </summary>
		Up = 5,
		/// <summary>
		/// Increasing ordinates values go down. This is used for vertical coordinate systems.
		/// </summary>
		Down = 6
	}
}
