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
	/// Semantic type of transform used in coordinate transformation.
	/// </summary>
	public enum TransformType : int
	{
		/// <summary>
		/// Unknown or unspecified type of transform.
		/// </summary>
		Other = 0,
		/// <summary>
		/// Transform depends only on defined parameters. For example, a cartographic projection.
		/// </summary>
		Conversion = 1,
		/// <summary>
		/// Transform depends only on empirically derived parameters. For example a datum transformation.
		/// </summary>
		Transformation = 2,
		/// <summary>
		/// Transform depends on both defined and empirical parameters.
		/// </summary>
		ConversionAndTransformation = 3
	}
}
