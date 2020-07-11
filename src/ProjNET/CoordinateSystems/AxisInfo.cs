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
	/// Details of axis. This is used to label axes, and indicate the orientation.
	/// </summary>
	public class AxisInfo
	{
		/// <summary>
		/// Initializes a new instance of an AxisInfo.
		/// </summary>
		/// <param name="name">Name of axis</param>
		/// <param name="orientation">Axis orientation</param>
		public AxisInfo(string name, AxisOrientationEnum orientation)
		{
			_Name = name;
			_Orientation = orientation;
		}

		private string _Name;

		/// <summary>
		/// Human readable name for axis. Possible values are X, Y, Long, Lat or any other short string.
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		private AxisOrientationEnum _Orientation;

		/// <summary>
		/// Gets enumerated value for orientation.
		/// </summary>
		public AxisOrientationEnum Orientation
		{
			get { return _Orientation; }
			set { _Orientation = value; }
		}

		/// <summary>
		/// Returns the Well-known text for this object
		/// as defined in the simple features specification.
		/// </summary>
		public string WKT
		{
			get
			{
				return String.Format("AXIS[\"{0}\", {1}]", Name, Orientation.ToString().ToUpperInvariant());
			}
		}
		/// <summary>
		/// Gets an XML representation of this object
		/// </summary>
		public string XML
		{
			get
			{
				return String.Format(System.Globalization.CultureInfo.InvariantCulture.NumberFormat, "<CS_AxisInfo Name=\"{0}\" Orientation=\"{1}\"/>", Name, Orientation.ToString().ToUpperInvariant());
			}
		}

	}
}
