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
using System.Globalization;
using System.Text;

namespace ProjNet.CoordinateSystems
{
	/// <summary>
	/// The Projection class defines the standard information stored with a projection
	/// objects. A projection object implements a coordinate transformation from a geographic
	/// coordinate system to a projected coordinate system, given the ellipsoid for the
	/// geographic coordinate system. It is expected that each coordinate transformation of
	/// interest, e.g., Transverse Mercator, Lambert, will be implemented as a class of
	/// type Projection, supporting the IProjection interface.
	/// </summary>
	public class Projection : Info, IProjection
	{
		internal Projection(string className, List<ProjectionParameter> parameters,
			string name, string authority, long code, string alias, 
			string remarks, string abbreviation)
			: base(name, authority, code, alias, abbreviation, remarks)
		{
			_Parameters = parameters;
			_ClassName = className;
		}

		#region Predefined projections
		#endregion

		#region IProjection Members

		/// <summary>
		/// Gets the number of parameters of the projection.
		/// </summary>
		public int NumParameters
		{
			get { return _Parameters.Count; }
		}

		private List<ProjectionParameter> _Parameters;

		/// <summary>
		/// Gets or sets the parameters of the projection
		/// </summary>
		internal List<ProjectionParameter> Parameters
		{
			get { return _Parameters; }
			set { _Parameters = value; }
		}

		/// <summary>
		/// Gets an indexed parameter of the projection.
		/// </summary>
		/// <param name="n">Index of parameter</param>
		/// <returns>n'th parameter</returns>
		public ProjectionParameter GetParameter(int n)
		{
			return _Parameters[n];
		}

		/// <summary>
		/// Gets a named parameter of the projection.
		/// </summary>
		/// <remarks>The parameter name is case insensitive</remarks>
		/// <param name="name">Name of parameter</param>
		/// <returns>parameter or null if not found</returns>
		public ProjectionParameter? GetParameter(string name)
		{
			foreach (ProjectionParameter par in _Parameters)
				if (par.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
					return par;
			return null;
		}
				
		private string _ClassName;

		/// <summary>
		/// Gets the projection classification name (e.g. "Transverse_Mercator").
		/// </summary>
		public string ClassName
		{
			get { return _ClassName; }
		}

		/// <summary>
		/// Returns the Well-known text for this object
		/// as defined in the simple features specification.
		/// </summary>
		public override string WKT
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.AppendFormat("PROJECTION[\"{0}\"", Name);
				if (!String.IsNullOrEmpty(Authority) && AuthorityCode > 0)
					sb.AppendFormat(", AUTHORITY[\"{0}\", \"{1}\"]", Authority, AuthorityCode);
				sb.Append("]");
				return sb.ToString();
			}
		}

		/// <summary>
		/// Gets an XML representation of this object
		/// </summary>
		public override string XML
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.AppendFormat(CultureInfo.InvariantCulture.NumberFormat, "<CS_Projection Classname=\"{0}\">{1}", ClassName, InfoXml);
				foreach (ProjectionParameter param in Parameters)
					sb.Append(param.XML);
				sb.Append("</CS_Projection>");
				return sb.ToString();
			}
		}

		/// <summary>
		/// Checks whether the values of this instance is equal to the values of another instance.
		/// Only parameters used for coordinate system are used for comparison.
		/// Name, abbreviation, authority, alias and remarks are ignored in the comparison.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>True if equal</returns>
		public override bool EqualParams(object obj)
		{
			if (!(obj is Projection proj))
				return false;
			if (proj.NumParameters != this.NumParameters)
				return false;
			for (int i = 0; i < _Parameters.Count; i++)
			{
				ProjectionParameter? param = GetParameter(proj.GetParameter(i).Name);
				if (param == null)
					return false;
				if (param.Value != proj.GetParameter(i).Value)
					return false;
			}
			return true;
		}

		#endregion
	}
}
