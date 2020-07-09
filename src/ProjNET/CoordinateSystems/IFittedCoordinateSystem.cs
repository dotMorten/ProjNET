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
	/// A coordinate system which sits inside another coordinate system. The fitted 
	/// coordinate system can be rotated and shifted, or use any other math transform
	/// to inject itself into the base coordinate system.
	/// </summary>
	public interface IFittedCoordinateSystem : ICoordinateSystem
	{
		/// <summary>
		/// Gets underlying coordinate system.
		/// </summary>
		ICoordinateSystem BaseCoordinateSystem { get; }
		/// <summary>
		/// Gets Well-Known Text of a math transform to the base coordinate system. 
		/// The dimension of this fitted coordinate system is determined by the source 
		/// dimension of the math transform. The transform should be one-to-one within 
		/// this coordinate system's domain, and the base coordinate system dimension 
		/// must be at least as big as the dimension of this coordinate system.
		/// </summary>
		/// <returns></returns>
		string ToBase();
	}
}
