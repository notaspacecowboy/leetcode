#include <string>
using namespace std;

class Solution {
public:
    string convert(string s, int numRows)
    {
        if(numRows == 1 || s.length() == 1)
            return s;

        string res = "";
        for(int i = 0; i < numRows; i++) {

            int pos = i;
            bool flip = (i == numRows - 1 ? true : false);
            while(pos < s.length()) {
                res += s[pos];
                if(flip)
                    pos += (i + 1) * 2 - 2;
                else
                    pos += (numRows - i) * 2 - 2;

                if(i != 0 && i != numRows - 1)
                    flip = !flip;
            }
        }

        return res;
    }
};