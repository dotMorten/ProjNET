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
	/// A named projection parameter value.
	/// </summary>
	/// <remarks>
	/// The linear units of parameters' values match the linear units of the containing 
	/// projected coordinate system. The angular units of parameter values match the 
	/// angular units of the geographic coordinate system that the projected coordinate 
	/// system is based on. (Notice that this is different from <see cref="Parameter"/>,
	/// where the units are always meters and degrees.)
	/// </remarks>
	public class ProjectionParameter
	{
		/// <summary>
		/// Initializes an instance of a ProjectionParameter
		/// </summary>
		/// <param name="name">Name of parameter</param>
		/// <param name="value">Parameter value</param>
		public ProjectionParameter(string name, double value)
		{
			_Name = name;
			_Value = value;
		}

		private string _Name;

		/// <summary>
		/// Parameter name.
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		private double _Value;

		/// <summary>
		/// Parameter value.
		/// The linear units of a parameters' values match the linear units of the containing 
		/// projected coordinate system. The angular units of parameter values match the 
		/// angular units of the geographic coordinate system that the projected coordinate 
		/// system is based on.
		/// </summary>
		public double Value
		{
			get { return _Value; }
			set { _Value = value; }
		}


		/// <summary>
		/// Returns the Well-known text for this object
		/// as defined in the simple features specification.
		/// </summary>
		public string WKT
		{
			get
			{
				return String.Format(System.Globalization.CultureInfo.InvariantCulture.NumberFormat, "PARAMETER[\"{0}\", {1}]", Name, Value);
			}
		}

		/// <summary>
		/// Gets an XML representation of this object
		/// </summary>
		public string XML
		{
			get
			{
                return String.Format(System.Globalization.CultureInfo.InvariantCulture.NumberFormat, "<CS_ProjectionParameter Name=\"{0}\" Value=\"{1}\"/>", Name, Value);
			}
		}
	}
}
