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
	/// Describes a coordinate transformation. This interface only describes a 
	/// coordinate transformation, it does not actually perform the transform 
	/// operation on points. To transform points you must use a math transform.
	/// </summary>
	public interface ICoordinateTransformation
	{
		/// <summary>
		/// Human readable description of domain in source coordinate system.
		/// </summary>
		string AreaOfUse { get; }
		/// <summary>
		/// Authority which defined transformation and parameter values.
		/// </summary>
		/// <remarks>
		/// An Authority is an organization that maintains definitions of Authority Codes. For example the European Petroleum Survey Group (EPSG) maintains a database of coordinate systems, and other spatial referencing objects, where each object has a code number ID. For example, the EPSG code for a WGS84 Lat/Lon coordinate system is ‘4326’
		/// </remarks>
		string Authority { get; }
		/// <summary>
		/// Code used by authority to identify transformation. An empty string is used for no code.
		/// </summary>
		/// <remarks>The AuthorityCode is a compact string defined by an Authority to reference a particular spatial reference object. For example, the European Survey Group (EPSG) authority uses 32 bit integers to reference coordinate systems, so all their code strings will consist of a few digits. The EPSG code for WGS84 Lat/Lon is ‘4326’.</remarks>
		long AuthorityCode { get; }
		/// <summary>
		/// Gets math transform.
		/// </summary>
		IMathTransform MathTransform { get; }
		/// <summary>
		/// Name of transformation.
		/// </summary>
		string Name { get; }
		/// <summary>
		/// Gets the provider-supplied remarks.
		/// </summary>
		string Remarks { get; }
		/// <summary>
		/// Source coordinate system.
		/// </summary>
		ICoordinateSystem SourceCS { get; }
		/// <summary>
		/// Target coordinate system.
		/// </summary>
		ICoordinateSystem TargetCS { get; }
		/// <summary>
		/// Semantic type of transform. For example, a datum transformation or a coordinate conversion.
		/// </summary>
		TransformType TransformType { get; }

	}
}
