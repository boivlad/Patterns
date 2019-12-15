using System;

namespace TemplateIntegral
{
    public abstract class Function
    {
        public double valueAt(double x)
        {
            return function(x);
        }

        protected abstract double function(double x);
    }
}