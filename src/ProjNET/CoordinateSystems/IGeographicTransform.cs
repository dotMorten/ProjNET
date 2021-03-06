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
	/// The IGeographicTransform interface is implemented on geographic transformation
	/// objects and implements datum transformations between geographic coordinate systems.
	/// </summary>
	public interface IGeographicTransform : IInfo
	{
		/// <summary>
		/// Gets or sets source geographic coordinate system for the transformation.
		/// </summary>
		IGeographicCoordinateSystem SourceGCS { get; set; }

		/// <summary>
		/// Gets or sets the target geographic coordinate system for the transformation.
		/// </summary>
		IGeographicCoordinateSystem TargetGCS { get; set; }

		/// <summary>
		/// Returns an accessor interface to the parameters for this geographic transformation.
		/// </summary>
		IParameterInfo ParameterInfo { get; }

		/// <summary>
		/// Transforms an array of points from the source geographic coordinate system
		/// to the target geographic coordinate system.
		/// </summary>
		/// <param name="points">Points in the source geographic coordinate system</param>
		/// <returns>Points in the target geographic coordinate system</returns>
        List<double[]> Forward(List<double[]> points);

		/// <summary>
		/// Transforms an array of points from the target geographic coordinate system
		/// to the source geographic coordinate system.
		/// </summary>
		/// <param name="points">Points in the target geographic coordinate system</param>
		/// <returns>Points in the source geographic coordinate system</returns>
        List<double[]> Inverse(List<double[]> points);

	}
}
