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
	public abstract class Datum : Info, IDatum
	{
		/// <summary>
		/// Initializes a new instance of a Datum object
		/// </summary>
		/// <param name="type">Datum type</param>
		/// <param name="name">Name</param>
		/// <param name="authority">Authority name</param>
		/// <param name="code">Authority-specific identification code.</param>
		/// <param name="alias">Alias</param>
		/// <param name="abbreviation">Abbreviation</param>
		/// <param name="remarks">Provider-supplied remarks</param>
		internal Datum(DatumType type,
			string name, string authority, long code, string alias,
			string remarks, string abbreviation)
			: base(name, authority, code, alias, abbreviation, remarks)
		{
			_DatumType = type;
		}
		#region IDatum Members

		private DatumType _DatumType;

		/// <summary>
		/// Gets or sets the type of the datum as an enumerated code.
		/// </summary>
		public DatumType DatumType
		{
			get { return _DatumType; }
			set { _DatumType = value; }
		}

		#endregion

		/// <summary>
		/// Checks whether the values of this instance is equal to the values of another instance.
		/// Only parameters used for coordinate system are used for comparison.
		/// Name, abbreviation, authority, alias and remarks are ignored in the comparison.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>True if equal</returns>
		public override bool EqualParams(object obj)
		{
			if (!(obj is Datum d))
				return false;
			return d.DatumType == this.DatumType;
		}
	}
}
