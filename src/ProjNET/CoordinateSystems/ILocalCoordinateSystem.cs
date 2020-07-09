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
	/// A local coordinate system, with uncertain relationship to the world.
	/// </summary>
	/// <remarks>In general, a local coordinate system cannot be related to other coordinate 
	/// systems. However, if two objects supporting this interface have the same dimension, 
	/// axes, units and datum then client code is permitted to assume that the two coordinate
	/// systems are identical. This allows several datasets from a common source (e.g. a CAD
	/// system) to be overlaid. In addition, some implementations of the Coordinate 
	/// Transformation (CT) package may have a mechanism for correlating local datums. (E.g. 
	/// from a database of transformations, which is created and maintained from real-world 
	/// measurements.)
	/// </remarks>
	public interface ILocalCoordinateSystem : ICoordinateSystem
	{
		/// <summary>
		/// Gets or sets the local datum
		/// </summary>
		ILocalDatum LocalDatum { get; set; }
	}
}
