using System;
using System.Linq;

namespace Y_tunnuksen_validointi
{
    class Program
    {
        static void Main(string[] args)
        {
            // y is the y-tunnus which will be validated
            string y = "RU6059250925";
            bool valid = false;
            valid = ValidoiYtunnus(y);
            // if valid, console will print true, if not console will print false
            if (valid)
                Console.WriteLine("true");
            else
                Console.WriteLine("false");

            static bool ValidoiYtunnus(string y)
            {
                //check the format
                if (y.Substring(7, 1) == "-" && y.Length == 9)
                {
                    // count the check number and see if it corresponds to the last number of the business id
                    int tarkistusnumero = -1;
                    int tulojenSumma = Int32.Parse(y[0].ToString()) * 7 + Int32.Parse(y[1].ToString()) * 9 + Int32.Parse(y[2].ToString()) * 10 + Int32.Parse(y[3].ToString()) * 5 + Int32.Parse(y[4].ToString()) * 8 + Int32.Parse(y[5].ToString()) * 4 + Int32.Parse(y[6].ToString()) * 2;
                    int jako = tulojenSumma % 11;
                    if (jako == 0)
                        tarkistusnumero = 0;
                    else if (jako > 1 && jako < 11)
                        tarkistusnumero = 11 - jako;
                    else
                        return false;
                    if (tarkistusnumero.ToString() == y.Last().ToString())
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }

        }
    }
    
}
