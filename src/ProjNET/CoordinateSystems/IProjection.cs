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
	/// The IProjection interface defines the standard information stored with projection
	/// objects. A projection object implements a coordinate transformation from a geographic
	/// coordinate system to a projected coordinate system, given the ellipsoid for the
	/// geographic coordinate system. It is expected that each coordinate transformation of
	/// interest, e.g., Transverse Mercator, Lambert, will be implemented as a COM class of
	/// coType Projection, supporting the IProjection interface.
	/// </summary>
	public interface IProjection : IInfo
	{
		/// <summary>
		/// Gets number of parameters of the projection.
		/// </summary>
		int NumParameters { get; }
		/// <summary>
		/// Gets the projection classification name (e.g. 'Transverse_Mercator').
		/// </summary>
		string ClassName { get; }
		/// <summary>
		/// Gets an indexed parameter of the projection.
		/// </summary>
		/// <param name="n">Index of parameter</param>
		/// <returns>n'th parameter</returns>
		ProjectionParameter GetParameter(int n);

		/// <summary>
		/// Gets an named parameter of the projection.
		/// </summary>
		/// <remarks>The parameter name is case insensitive</remarks>
		/// <param name="name">Name of parameter</param>
		/// <returns>parameter or null if not found</returns>
		ProjectionParameter? GetParameter(string name);
	}
}
