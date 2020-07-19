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
	/// The ISpatialReferenceInfo interface defines the standard 
	/// information stored with spatial reference objects. This
	/// interface is reused for many of the spatial reference
	/// objects in the system.
	/// </summary>
	public interface IInfo
	{
		/// <summary>
		/// Gets the name of the object.
		/// </summary>
		string? Name { get; }
		/// <summary>
		/// Gets the authority name for this object, e.g., “POSC”,
		/// is this is a standard object with an authority specific
		/// identity code. Returns “CUSTOM” if this is a custom object.
		/// </summary>
		string? Authority { get; }
		/// <summary>
		/// Gets the authority specific identification code of the object
		/// </summary>
		long AuthorityCode { get; }
		/// <summary>
		/// Getsthe alias of the object.
		/// </summary>
		string? Alias { get; }
		/// <summary>
		/// Gets the abbreviation of the object.
		/// </summary>
		string? Abbreviation { get; }
		/// <summary>
		/// Getsthe provider-supplied remarks for the object.
		/// </summary>
		string? Remarks { get; }
		/// <summary>
		/// Returns the Well-known text for this spatial reference object
		/// as defined in the simple features specification.
		/// </summary>
		string WKT { get; }
		/// <summary>
		/// Gets an XML representation of this object.
		/// </summary>
		string XML { get; }

		/// <summary>
		/// Checks whether the values of this instance is equal to the values of another instance.
		/// Only parameters used for coordinate system are used for comparison.
		/// Name, abbreviation, authority, alias and remarks are ignored in the comparison.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>True if equal</returns>
		bool EqualParams(object obj);
	}
}
