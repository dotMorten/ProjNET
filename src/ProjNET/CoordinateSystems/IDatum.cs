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
	/// A set of quantities from which other quantities are calculated.
	/// </summary>
	/// <remarks>
	/// For the OGC abstract model, it can be defined as a set of real points on the earth 
	/// that have coordinates. EG. A datum can be thought of as a set of parameters 
	/// defining completely the origin and orientation of a coordinate system with respect 
	/// to the earth. A textual description and/or a set of parameters describing the 
	/// relationship of a coordinate system to some predefined physical locations (such 
	/// as center of mass) and physical directions (such as axis of spin). The definition 
	/// of the datum may also include the temporal behavior (such as the rate of change of
	/// the orientation of the coordinate axes).
	/// </remarks>
	public interface IDatum : IInfo
	{
		/// <summary>
		/// Gets or sets the type of the datum as an enumerated code.
		/// </summary>
		DatumType DatumType { get; set; }
	}
}
