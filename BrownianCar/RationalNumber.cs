using System;

namespace BrownianCar
{
    class RationalNumber
    {
        private long num;
        private long denom;

        internal RationalNumber(long num, long denom)
        {
            this.num = num;
            this.denom = denom;
            Normalize();
        }

        public static RationalNumber Add(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber(r1.num * r2.denom + r2.num * r1.denom, r1.denom * r2.denom);
        }

        public static RationalNumber Multiply(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber(r1.num * r2.num, r1.denom * r2.denom);
        }

        private void Normalize()
        {
            if (num == 0 || denom == 0)
                return;
            var gcd = GCD(num, denom);
            num = num / gcd;
            denom = denom / gcd;
        }        

        private static long GCD(long i, long j)
        {
            if (j == 0)
                return i;
            return GCD(j, i % j);
        }

        public override string ToString()
        {
            return (num + "/" + denom);
        }
    }
}
