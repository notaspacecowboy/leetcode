#include <vector>
#include <string>
#include <unordered_map>
using namespace std;

class Solution {
public:
    vector<string> letterCombinations(string digits) {
        unordered_map<char, string> lookup {
                {'2', "abc"},
                {'3', "def"},
                {'4', "ghi"},
                {'5', "jkl"},
                {'6', "mno"},
                {'7', "pqrs"},
                {'8', "tuv"},
                {'9', "wxyz"},
        };

        int total = 1;
        for(int i = 0; i < digits.length(); i++) {
            total *= lookup[digits[i]].size();
        }

        vector<string> res;
        for(int i = 0; i < total; i++) {
            res.emplace_back("");
        }

        int currentLength = 1;
        for(int i = 0; i < digits.length(); i++) {
            string digit = lookup[digits[i]];
            for(int j = 0; j < total; j++) {
                char currentDigit = (j / currentLength % digit.length());
                res[j] += currentLength;
            }

            currentLength *= digit.length();
        }


        return res;
    }
};