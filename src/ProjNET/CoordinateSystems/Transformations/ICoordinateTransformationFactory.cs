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
	/// Creates coordinate transformations.
	/// </summary>
	public interface ICoordinateTransformationFactory
	{
		/// <summary>
		/// Creates a transformation between two coordinate systems.
		/// </summary>
		/// <remarks>
		/// This method will examine the coordinate systems in order to construct
		/// a transformation between them. This method may fail if no path between 
		/// the coordinate systems is found, using the normal failing behavior of 
		/// the DCP (e.g. throwing an exception).</remarks>
		/// <param name="sourceCS">Source coordinate system</param>
		/// <param name="targetCS">Target coordinate system</param>
		/// <returns></returns>
		ICoordinateTransformation CreateFromCoordinateSystems(ICoordinateSystem sourceCS, ICoordinateSystem targetCS);
	}
}
