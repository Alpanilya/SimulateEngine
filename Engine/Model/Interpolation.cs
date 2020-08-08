using System.Collections.Generic;


namespace Engine.Model
{
    internal class Interpolation
    {
        public static double LinearInterpolation(IList<double> X, IList<double> Fx, int Number, double V)
        {
            var fx = Fx[Number] + (Fx[Number + 1] - Fx[Number]) * (V - X[Number]) / (X[Number + 1] - X[Number]);
			return fx;
        }
    }
}
