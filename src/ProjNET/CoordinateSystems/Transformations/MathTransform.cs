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
	/// Abstract class for creating multi-dimensional coordinate points transformations.
	/// </summary>
	/// <remarks>
	/// If a client application wishes to query the source and target coordinate 
	/// systems of a transformation, then it should keep hold of the 
	/// <see cref="ICoordinateTransformation"/> interface, and use the contained 
	/// math transform object whenever it wishes to perform a transform.
	/// </remarks>
	public abstract class MathTransform : IMathTransform
	{
		#region IMathTransform Members

		/// <summary>
		/// Gets the dimension of input points.
		/// </summary>
		public virtual int DimSource
		{
			get { throw new NotImplementedException(); }
		}

		/// <summary>
		/// Gets the dimension of output points.
		/// </summary>
		public virtual int DimTarget
		{
			get { throw new NotImplementedException(); }
		}

		/// <summary>
		/// Tests whether this transform does not move any points.
		/// </summary>
		/// <returns></returns>
		public virtual bool Identity()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets a Well-Known text representation of this object.
		/// </summary>
		public abstract string WKT { get; }

		/// <summary>
		/// Gets an XML representation of this object.
		/// </summary>
		public abstract string XML { get; }

		/// <summary>
		/// Gets the derivative of this transform at a point. If the transform does 
		/// not have a well-defined derivative at the point, then this function should 
		/// fail in the usual way for the DCP. The derivative is the matrix of the 
		/// non-translating portion of the approximate affine map at the point. The
		/// matrix will have dimensions corresponding to the source and target 
		/// coordinate systems. If the input dimension is M, and the output dimension 
		/// is N, then the matrix will have size [M][N]. The elements of the matrix 
		/// {elt[n][m] : n=0..(N-1)} form a vector in the output space which is 
		/// parallel to the displacement caused by a small change in the m'th ordinate 
		/// in the input space.
		/// </summary>
		/// <param name="point"></param>
		/// <returns></returns>
		public virtual double[,] Derivative(double[] point)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets transformed convex hull.
		/// </summary>
		/// <remarks>
		/// <para>The supplied ordinates are interpreted as a sequence of points, which generates a convex
		/// hull in the source space. The returned sequence of ordinates represents a convex hull in the 
		/// output space. The number of output points will often be different from the number of input 
		/// points. Each of the input points should be inside the valid domain (this can be checked by 
		/// testing the points' domain flags individually). However, the convex hull of the input points
		/// may go outside the valid domain. The returned convex hull should contain the transformed image
		/// of the intersection of the source convex hull and the source domain.</para>
		/// <para>A convex hull is a shape in a coordinate system, where if two positions A and B are 
		/// inside the shape, then all positions in the straight line between A and B are also inside 
		/// the shape. So in 3D a cube and a sphere are both convex hulls. Other less obvious examples 
		/// of convex hulls are straight lines, and single points. (A single point is a convex hull, 
		/// because the positions A and B must both be the same - i.e. the point itself. So the straight
		/// line between A and B has zero length.)</para>
		/// <para>Some examples of shapes that are NOT convex hulls are donuts, and horseshoes.</para>
		/// </remarks>
		/// <param name="points"></param>
		/// <returns></returns>
		public virtual List<double> GetCodomainConvexHull(List<double> points)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets flags classifying domain points within a convex hull.
		/// </summary>
		/// <remarks>
		/// The supplied ordinates are interpreted as a sequence of points, which 
		/// generates a convex hull in the source space. Conceptually, each of the 
		/// (usually infinite) points inside the convex hull is then tested against
		/// the source domain. The flags of all these tests are then combined. In 
		/// practice, implementations of different transforms will use different 
		/// short-cuts to avoid doing an infinite number of tests.
		/// </remarks>
		/// <param name="points"></param>
		/// <returns></returns>
		public virtual DomainFlags GetDomainFlags(List<double> points)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Creates the inverse transform of this object.
		/// </summary>
		/// <remarks>This method may fail if the transform is not one to one. However, all cartographic projections should succeed.</remarks>
		/// <returns></returns>
		public abstract IMathTransform Inverse();

		/// <summary>
		/// Transforms a coordinate point. The passed parameter point should not be modified.
		/// </summary>
		/// <param name="point"></param>
		/// <returns></returns>
        public abstract double[] Transform(double[] point);

		/// <summary>
		/// Transforms a list of coordinate point ordinal values.
		/// </summary>
		/// <remarks>
		/// This method is provided for efficiently transforming many points. The supplied array 
		/// of ordinal values will contain packed ordinal values. For example, if the source 
		/// dimension is 3, then the ordinals will be packed in this order (x0,y0,z0,x1,y1,z1 ...).
		/// The size of the passed array must be an integer multiple of DimSource. The returned 
		/// ordinal values are packed in a similar way. In some DCPs. the ordinals may be 
		/// transformed in-place, and the returned array may be the same as the passed array.
		/// So any client code should not attempt to reuse the passed ordinal values (although
		/// they can certainly reuse the passed array). If there is any problem then the server
		/// implementation will throw an exception. If this happens then the client should not
		/// make any assumptions about the state of the ordinal values.
		/// </remarks>
		/// <param name="points"></param>
		/// <returns></returns>
        public abstract List<double[]> TransformList(List<double[]> points);

		/// <summary>
		/// Reverses the transformation
		/// </summary>
		public abstract void Invert();


		/// <summary>
		/// To convert degrees to radians, multiply degrees by pi/180. 
		/// </summary>
		protected static double Degrees2Radians(double deg)
		{
			return (D2R * deg);

		}
		/// <summary>
		/// R2D
		/// </summary>
		protected const double R2D = 180 / Math.PI;

		/// <summary>
		/// D2R
		/// </summary>
		protected const double D2R = Math.PI / 180;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rad"></param>
		/// <returns></returns>
		protected static double Radians2Degrees(double rad)
		{
			return (R2D * rad);
		}

		#endregion
	}
}
