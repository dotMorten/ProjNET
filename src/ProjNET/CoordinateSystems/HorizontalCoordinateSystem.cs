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

namespace ProjNet.CoordinateSystems
{
	/// <summary>
	/// A 2D coordinate system suitable for positions on the Earth's surface.
	/// </summary>
	public abstract class HorizontalCoordinateSystem : CoordinateSystem, IHorizontalCoordinateSystem
	{
		/// <summary>
		/// Creates an instance of HorizontalCoordinateSystem
		/// </summary>
		/// <param name="datum">Horizontal datum</param>
		/// <param name="axisInfo">Axis information</param>
		/// <param name="name">Name</param>
		/// <param name="authority">Authority name</param>
		/// <param name="code">Authority-specific identification code.</param>
		/// <param name="alias">Alias</param>
		/// <param name="abbreviation">Abbreviation</param>
		/// <param name="remarks">Provider-supplied remarks</param>
		internal HorizontalCoordinateSystem(IHorizontalDatum datum, List<AxisInfo> axisInfo, 
			string name, string authority, long code, string alias,
			string remarks, string abbreviation)
			: base(name, authority, code, alias, abbreviation, remarks, axisInfo)
		{
			_HorizontalDatum = datum;
			if (axisInfo.Count != 2)
				throw new ArgumentException("Axis info should contain two axes for horizontal coordinate systems");
		}

		#region IHorizontalCoordinateSystem Members

		private IHorizontalDatum _HorizontalDatum;

		/// <summary>
		/// Gets or sets the HorizontalDatum.
		/// </summary>
		public IHorizontalDatum HorizontalDatum
		{
			get { return _HorizontalDatum; }
			set { _HorizontalDatum = value; }
		}
		
		#endregion
	}
}
