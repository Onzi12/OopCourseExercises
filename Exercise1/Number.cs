using System;
using System.Text;

namespace Exercise1
{
    public class Number
    {
        private int[] digits;
        private int n;

        public Number(string value, int n)
        {
            Initializer(value, n);
        }

        private void Initializer(string value, int n)
        {
            N = n;
            digits = StringToBinaryDigitsArray(value, N);
        }

        private void Initializer(int[] value, int n)
        {
            N = n;
            digits = value;
        }

        public Number()
        {
            N = 32; // random picked number
        }

        public int this[int index]
        {
            get { return digits[index]; }
        }

        public static implicit operator Number(string input)
        {
            return new Number(input, input.Length * 2);
        }

        public static Number operator +(Number x, Number y)
        {
            var result = new Number();
            var resultDigits = new int[x.N];
            int carry = 0;
            for ( int i = x.N - 1 ; i >= 0 ; --i )
            {
                resultDigits[i] = BinaryAddDigit(x[i], y[i], ref carry);
            }

            result.Initializer(resultDigits, resultDigits.Length);

            return result;
        }

        public static Number operator *(Number x, Number y)
        {
            if ( x.ToString().Length > y.ToString().Length )
            {
                return y * x;
            }
            var result = new Number("0", x.N * 2);
            var mul = new StringBuilder();
            var yIndex = y.N - 1;
            var yNumberOfBits = y.ToString().Length;
            for ( int i = 0 ; i < yNumberOfBits ; ++i )
            {
                var temp = new Number(x.ToString() + mul, result.N);
                if ( y[yIndex--] == 1 )
                {
                    result += temp;
                }

                mul.Append('0');
            }

            return result;
        }

        private static int BinaryAddDigit(int x, int y, ref int carry)
        {
            int result;
            if ( x == 0 && y == 0 ) // both zero
            {
                result = carry;
                carry = 0;
            }
            else if ( x != y ) // one is 1 && one is 0
            {
                result = carry == 1 ? 0 : 1;

            }
            else // both 1
            {
                if ( carry == 1 )
                {
                    result = 1;
                }
                else
                {
                    carry = 1;
                    result = 0;
                }

            }

            return result;
        }

        public string HexString
        {
            get
            {
                var result = new StringBuilder();
                for ( int i = N - 1 ; i >= 0 ; i -= 4 )
                {
                    int sum = 0;
                    int d = 1;
                    for ( int j = 0 ; j < 4 ; j++ )
                    {
                        if ( i - j < 0 )
                        {
                            break;
                        }

                        if ( digits[i - j] == 1 )
                        {
                            sum += d;
                        }

                        d *= 2;
                    }
                    result.Insert(0, IntToHex(sum));


                }
                int startPosition = 0;
                for ( int i = 0 ; i < result.Length ; i++ )
                {
                    if ( result[i] != '0' )
                    {
                        break;
                    }
                    ++startPosition;
                }

                return result.ToString().Substring(startPosition);
            }

            set
            {
                var asInt = int.Parse(value, System.Globalization.NumberStyles.HexNumber);
                string asBinary = Convert.ToString(asInt, 2);
                Initializer(asBinary, asBinary.Length);

            }
        }
        private static int[] StringToBinaryDigitsArray(string number, int n)
        {
            if ( number.Length > n )
                return null;

            var result = new int[n];
            var strIndex = number.Length - 1;
            var resIndex = n - 1;
            for ( var i = 0 ; i < number.Length ; ++i )
            {
                result[resIndex--] = number[strIndex--] == '1' ? 1 : 0;
            }
            return result;
        }

        private int HexToInt(char hex)
        {
            int result = -1;
            if ( hex >= '0' && hex <= '9' )
            {
                result = short.Parse(hex.ToString());
            }
            else if ( hex >= 'A' && hex <= 'F' )
            {
                short value = 10;
                var letter = 'A';

                while ( letter <= 'F' )
                {
                    if ( hex == letter )
                    {
                        result = value;
                        break;
                    }
                    ++value;
                    ++letter;
                }
            }

            return result;
        }

        private char IntToHex(int x)
        {
            if ( x < 0 || x > 15 )
            {
                throw new ArgumentException("input is not an Hex digit");
            }

            char result = '0';
            for ( int i = 0 ; i < 16 ; i++ )
            {
                if ( i == x )
                {
                    break;
                }

                if ( result == '9' )
                {
                    result = 'A';
                }
                else
                {
                    ++result;
                }
            }

            return result;
        }

        public int N
        {
            get { return n; }
            private set
            {
                if ( value == n )
                    return;

                n = PowerOfTwoCeiling(value);
                digits = new int[n];

            }
        }

        private static int PowerOfTwoCeiling(int x)
        {
            int power = 1;
            while ( x > power )
            {
                power *= 2;
            }
            return power;
        }


        public override string ToString()
        {
            return DigitsToString(digits);
        }

        public static string DigitsToString(int[] digits)
        {
            int startIndex;
            for ( startIndex = 0 ; startIndex < digits.Length ; startIndex++ )
            {
                if ( digits[startIndex] != 0 )
                {
                    break;
                }
            }

            var result = new StringBuilder();
            for ( int i = startIndex ; i < digits.Length ; i++ )
            {
                result.Append(digits[i]);
            }

            return result.ToString();
        }
    }
}