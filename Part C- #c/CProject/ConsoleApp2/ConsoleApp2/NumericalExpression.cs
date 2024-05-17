using System;

namespace NewCProject
{
    class NumericalExpression
    {
        private long Value;

        private readonly string[] Ones = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private readonly string[] TenToTwenty = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private readonly string[] Tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };



        public NumericalExpression(long value)
        {
            this.Value = value;
        }

        public long GetValue()
        {
            return this.Value;
        }

        public static int SumLetters(int number)
        {
            int sum = 0;
            for (int i = 0; i <= number; i++)
            {
                sum += new NumericalExpression(i).ToString().Replace(" ", "").Length;
            }

            return sum;
        }

        // העיקרון שבא לידי ביטוי הוא פולימורפיזם, מסוג העמסה overloading.
        // זה משום שאנחנו מגדירים פונקציות בעלות אותו שם המבצעות פעולה זהה והמתכנת מחליט באיזו מהן להשתמש בהתאם לטיפוס הפרמטרים- במקרה זה- מספר או מופע של המחלקה NumericalExpression.
        public static int SumLetters(NumericalExpression numerical_expression_object)
        {
            int sum = 0;
            for (int i = 0; i <= numerical_expression_object.GetValue(); i++)
            {
                sum += new NumericalExpression(i).ToString().Replace(" ", "").Length;
            }

            return sum;
        }

        public string ToString()
        {
            long number = this.Value;

            if (number == 0)
            {
                return "Zero";
            }

            else if (number < Math.Pow(10, 3))
            {
                return ThreeDigits(number);
            }

            else if (number < Math.Pow(10, 6))
            {
                string onesNumber = ThreeDigits(number % (int)Math.Pow(10, 3));
                string thousands = ThreeDigits(number / (int)Math.Pow(10, 3));

                if (onesNumber.Equals(""))
                {
                    return thousands + " Thousand";
                }
                else if(number % (int)Math.Pow(10, 3) < 100)
                {
                    return thousands + " Thousand and " + onesNumber;
                }
                else
                {
                    return thousands + " Thousand " + onesNumber;
                }
            }

            else if (number < Math.Pow(10, 9))
            {
                string onesNumber = ThreeDigits(number % (int)Math.Pow(10, 3));
                string thousands = ThreeDigits(number / (int)Math.Pow(10, 3));
                string millions = ThreeDigits(number / (int)Math.Pow(10, 6));

                if (onesNumber.Equals("") && thousands.Equals(""))
                {
                    return millions + " Million";
                }
                else if (onesNumber.Equals(""))
                {
                    return millions + " Million " + thousands + " Thousand ";
                }
                else if (thousands.Equals(""))
                {
                    if(number % (int)Math.Pow(10, 3) < 100)
                    {
                        return millions + " Million And " + onesNumber;
                    }
                    else
                    {
                        return millions + " Million " + onesNumber;
                    }
                }
                else
                {
                    if (number % (int)Math.Pow(10, 3) < 100)
                    {
                        return millions + " Million" + thousands + " Thousand And " + onesNumber;
                    }
                    else
                    {
                        return millions + " Million" + thousands + " Thousand " + onesNumber;
                    }
                    
                }
            }

            else if (number < Math.Pow(10, 12))
            {
                string onesNumber = ThreeDigits(number % (int)Math.Pow(10, 3));
                string thousands = ThreeDigits(number / (int)Math.Pow(10, 3));
                string millions = ThreeDigits(number / (int)Math.Pow(10, 6));
                string billions = ThreeDigits(number / (int)Math.Pow(10, 9));

                if (onesNumber.Equals("") && thousands.Equals("") && millions.Equals(""))
                {
                    return billions + " Billion";
                }
                else if (onesNumber.Equals("") && thousands.Equals(""))
                {
                    return billions + " Billion" + millions + " Million";
                }
                else if (onesNumber.Equals("") && millions.Equals(""))
                {
                    return billions + " Billion " + thousands + " Thousand";
                }
                else if (thousands.Equals("") && millions.Equals(""))
                {
                    if (number % (int)Math.Pow(10, 3) < 100)
                    {
                        return billions + " Billion And " + onesNumber;
                    }
                    else
                    {
                        return billions + " Billion " + onesNumber;
                    }
                }
                else
                {
                    if (number % (int)Math.Pow(10, 3) < 100)
                    {
                        return billions + " Billion " + millions + " Million " + thousands + " Thousand And " + onesNumber;
                    }
                    else
                    {
                        return billions + " Billion " + millions + " Million " + thousands + " Thousand " + onesNumber;
                    }
                }
            }

            else
            {
                throw new ArgumentOutOfRangeException("Number is too large to convert to words.");
            }
        }

        private string OneOrTwoDigits(long number)
        {
            if(number == 0)
            {
                return "";
            }
            else if (number < 10)
            {
                return Ones[number];
            }
            else
            {
                if (number < 20)
                {
                    return TenToTwenty[number % 10];
                }
                else if (number % 10 == 0)
                {
                    return Tens[number / 10];
                }
                else
                {
                    return Tens[number / 10] + " " + Ones[number % 10];
                }
            }
        }

        private string ThreeDigits(long number)
        {
            string twoLastDigits = OneOrTwoDigits(number % 100);
            if (number / 100 == 0)
            {
                return twoLastDigits;
            }
            else
            {
                return Ones[number / 100] + " Hundred " + twoLastDigits;
            }
        }
    }

}
