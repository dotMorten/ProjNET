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


// SOURCECODE IS MODIFIED FROM ANOTHER WORK AND IS ORIGINALLY BASED ON GeoTools.NET:
/*
 *  Copyright (C) 2002 Urban Science Applications, Inc. 
 *
 *  This library is free software; you can redistribute it and/or
 *  modify it under the terms of the GNU Lesser General Public
 *  License as published by the Free Software Foundation; either
 *  version 2.1 of the License, or (at your option) any later version.
 *
 *  This library is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 *  Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with this library; if not, write to the Free Software
 *  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 *
 */

using System;
using System.Globalization;
using System.IO;
using ProjNet.Converters.WellKnownText.IO;

namespace ProjNet.Converters.WellKnownText
{
	/// <summary>
	/// Reads a stream of Well Known Text (wkt) string and returns a stream of tokens.
	/// </summary>
	internal class WktStreamTokenizer : StreamTokenizer
	{

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WktStreamTokenizer class.
		/// </summary>
		/// <remarks>The WktStreamTokenizer class ais in reading WKT streams.</remarks>
		/// <param name="reader">A TextReader that contains </param>
		public WktStreamTokenizer(TextReader reader) : base(reader, true)
		{
			if (reader==null)
			{
				throw new ArgumentNullException("reader");
			}
		}
		#endregion

		#region Methods

		/// <summary>
		/// Reads a token and checks it is what is expected.
		/// </summary>
		/// <param name="expectedToken">The expected token.</param>
		internal void ReadToken(string expectedToken)
		{
			this.NextToken();
			if (this.GetStringValue()!=expectedToken)
			{
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture.NumberFormat, "Expecting ('{3}') but got a '{0}' at line {1} column {2}.", this.GetStringValue(), this.LineNumber, this.Column, expectedToken));
			}
		}
		
		/// <summary>
		/// Reads a string inside double quotes.
		/// </summary>
		/// <remarks>
		/// White space inside quotes is preserved.
		/// </remarks>
		/// <returns>The string inside the double quotes.</returns>
		public string ReadDoubleQuotedWord()
		{
			string word="";
			ReadToken("\"");	
			NextToken(false);
			while (GetStringValue()!="\"")
			{
				word = word+ this.GetStringValue();
				NextToken(false);
			} 
			return word;
		}

		/// <summary>
		/// Reads the authority and authority code.
		/// </summary>
		/// <param name="authority">String to place the authority in.</param>
		/// <param name="authorityCode">String to place the authority code in.</param>
		public void ReadAuthority(ref string authority,ref long authorityCode)
		{
			//AUTHORITY["EPGS","9102"]]
			if(GetStringValue() != "AUTHORITY")
				ReadToken("AUTHORITY");
			ReadToken("[");
			authority = this.ReadDoubleQuotedWord();
			ReadToken(",");
#if(!Silverlight)
			long.TryParse(this.ReadDoubleQuotedWord(), 
				NumberStyles.Any,
				CultureInfo.InvariantCulture.NumberFormat,
				out authorityCode);
#else
			try { authorityCode = long.Parse(this.ReadDoubleQuotedWord(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture.NumberFormat); }
			catch { }
#endif
			ReadToken("]");
		}
		#endregion

	}
}
