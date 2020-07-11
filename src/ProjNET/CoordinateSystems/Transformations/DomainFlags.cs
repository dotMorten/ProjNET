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

namespace ProjNet.CoordinateSystems.Transformations
{
	/// <summary>
	/// Flags indicating parts of domain covered by a convex hull. 
	/// </summary>
	/// <remarks>
	/// These flags can be combined. For example, the value 3 
	/// corresponds to a combination of <see cref="Inside"/> and <see cref="Outside"/>,
	/// which means that some parts of the convex hull are inside the 
	/// domain, and some parts of the convex hull are outside the domain.
	/// </remarks>
	public enum DomainFlags : int
	{
		/// <summary>
		/// At least one point in a convex hull is inside the transform's domain.
		/// </summary>
		Inside = 1,
		/// <summary>
		/// At least one point in a convex hull is outside the transform's domain.
		/// </summary>
		Outside = 2,
		/// <summary>
		/// At least one point in a convex hull is not transformed continuously.
		/// </summary>
		/// <remarks>
		/// As an example, consider a "Longitude_Rotation" transform which adjusts 
		/// longitude coordinates to take account of a change in Prime Meridian. If
		/// the rotation is 5 degrees east, then the point (Lat=175,Lon=0) is not 
		/// transformed continuously, since it is on the meridian line which will 
		/// be split at +180/-180 degrees.
		/// </remarks>
		Discontinuous = 4
	}
}
