using System;

namespace AddBinary
{
    public class Solution
    {
        public string AddBinary(string a, string b)
        {
            string ans = "";
            int carry = 0;

            int i = a.Length - 1;
            int j = b.Length - 1;

            while (i >= 0 && j >= 0)
            {
                int digit = (a[i] - '0') + (b[j] - '0') + carry;
                switch (digit)
                {
                    case 0:
                        ans = '0' + ans;
                        carry = 0;
                        break;

                    case 1:
                        ans = '1' + ans;
                        carry = 0;
                        break;

                    case 2:
                        ans = '0' + ans;
                        carry = 1;
                        break;

                    case 3:
                        ans = '1' + ans;
                        carry = 1;
                        break;
                }
                i--;
                j--;
            }

            while (i >= 0)
            {
                int digit = (a[i] - '0') + carry;
                switch (digit)
                {
                    case 0:
                        ans = '0' + ans;
                        carry = 0;
                        break;

                    case 1:
                        ans = '1' + ans;
                        carry = 0;
                        break;

                    case 2:
                        ans = '0' + ans;
                        carry = 1;
                        break;
                }
                i--;
            }

            while (j >= 0)
            {
                int digit = (b[j] - '0') + carry;
                switch (digit)
                {
                    case 0:
                        ans = '0' + ans;
                        carry = 0;
                        break;

                    case 1:
                        ans = '1' + ans;
                        carry = 0;
                        break;

                    case 2:
                        ans = '0' + ans;
                        carry = 1;
                        break;
                }
                j--;
            }

            if (carry == 1)
                ans = '1' + ans;

            return ans;
        }
    }
}
