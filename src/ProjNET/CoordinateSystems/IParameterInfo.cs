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
	/// The IParameterInfo interface provides an interface through which clients of a
	/// Projected Coordinate System or of a Projection can set the parameters of the
	/// projection. It provides a generic interface for discovering the names and default
	/// values of parameters, and for setting and getting parameter values. Subclasses of
	/// this interface may provide projection specific parameter access methods.
	/// </summary>
	public interface IParameterInfo
	{
		/// <summary>
		/// Gets the number of parameters expected.
		/// </summary>
		int NumParameters { get; }
		/// <summary>
		/// Returns the default parameters for this projection.
		/// </summary>
		/// <returns></returns>
		Parameter[] DefaultParameters();
		/// <summary>
		/// Gets or sets the parameters set for this projection.
		/// </summary>
		List<Parameter> Parameters { get; set; }
		/// <summary>
		/// Gets the parameter by its name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		Parameter GetParameterByName(string name);
	}
}
