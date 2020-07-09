### Projecting points from one coordinate system to another
Performing a transformation from one coordinate system to another requires you to create two coordinate systems: A '_from_' and a '_to_' coordinate system. See [the FAQ](FAQ) on how to create a coordinate system.

First create a CoordinateTransformationFactory:
```cs
CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();
```
Then create the transformation instance:
```cs
ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(fromCS, toCS);
```
All transformations are done on double arrays, where the first value is primary axis (X/East/Latitude) and the second the secondary (Y/North/Longitude). You can provide an optional third value (Z/Height), which can change if a datum transformation occurs* during the transform.
Example:
```cs
double[]()() fromPoint = new double[]()() { 120, -3 };
double[]() toPoint = trans.MathTransform.Transform(fromPoint);
```
If you want to transform back again, create an inversed transformation:
```cs
IMathTransform inversedTransform = trans.MathTransform.Inverse();
double[]() point = inversedTransform.Transform(toPoint);
```

*Note that no datum transformation is applied if the coordinate systems doesn't have a ToWGS84 parameter defined.