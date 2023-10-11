#include <string>
using namespace std;

class Solution {
public:
    string reverseWords(string s) {
        string res = "";
        int right = s.length() - 1;
        while(right >= 0)
        {
	        //remove trailing white space
            while(right >= 0 && s[right] == ' ')
                right--;

            if (right < 0)
                break;

            int left = right;
            while (left >= 0 && s[left] != ' ')
                left--;

            if (res.length() > 0)
                res += " ";
            res += s.substr(left + 1, right - left);
            right = left;
        }

        return res;
    }
};