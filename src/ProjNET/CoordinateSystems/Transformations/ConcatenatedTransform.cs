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

namespace ProjNet.CoordinateSystems.Transformations
{
    /// <summary>
    /// 
    /// </summary>
	internal class ConcatenatedTransform : MathTransform
	{
        /// <summary>
        /// 
        /// </summary>
		protected IMathTransform? _inverse;

        /// <summary>
        /// 
        /// </summary>
		public ConcatenatedTransform() : 
            this(new List<ICoordinateTransformation>()) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transformlist"></param>
		public ConcatenatedTransform(List<ICoordinateTransformation> transformlist)
		{
			_CoordinateTransformationList = transformlist;
		}

		private List<ICoordinateTransformation> _CoordinateTransformationList;

        /// <summary>
        /// 
        /// </summary>
		public List<ICoordinateTransformation> CoordinateTransformationList
		{
			get { return _CoordinateTransformationList; }
			set
			{
				_CoordinateTransformationList = value;
				_inverse = null;
			}
		}
		
        /// <summary>
        /// Transforms a point
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override double[] Transform(double[] point)
		{
            foreach (ICoordinateTransformation ct in _CoordinateTransformationList)
				point = ct.MathTransform.Transform(point);            
			return point;			
		}

        /// <summary>
		/// Transforms a list point
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public override List<double[]> TransformList(List<double[]> points)
		{
			List<double[]> pnts = new List<double[]>(points.Count);
			pnts.AddRange(points);
			foreach (ICoordinateTransformation ct in _CoordinateTransformationList)
				pnts = ct.MathTransform.TransformList(pnts);
			return pnts;
		}

		/// <summary>
		/// Returns the inverse of this conversion.
		/// </summary>
		/// <returns>IMathTransform that is the reverse of the current conversion.</returns>
		public override IMathTransform Inverse()
		{
			if (_inverse == null)
			{
				_inverse = this.Clone();
				_inverse.Invert();
			}
			return _inverse;
		}
		
		/// <summary>
		/// Reverses the transformation
		/// </summary>
		public override void Invert()
		{
			_CoordinateTransformationList.Reverse();
			foreach (ICoordinateTransformation ic in _CoordinateTransformationList)
				ic.MathTransform.Invert();
		}

		public ConcatenatedTransform Clone()
		{
			List<ICoordinateTransformation> clonedList = new List<ICoordinateTransformation>(_CoordinateTransformationList.Count);
			foreach (ICoordinateTransformation ct in _CoordinateTransformationList)
				clonedList.Add(ct);
			return new ConcatenatedTransform(clonedList);
		}

        /// <summary>
        /// Gets a Well-Known text representation of this object.
        /// </summary>
        /// <value></value>
        public override string WKT
		{
			get { throw new NotImplementedException(); }
		}

        /// <summary>
        /// Gets an XML representation of this object.
        /// </summary>
        /// <value></value>
		public override string XML
		{
			get { throw new NotImplementedException(); }
		}
	}
}
