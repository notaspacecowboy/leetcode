#include <string>
#include <vector>

using namespace std;

class Solution {
public:
    string intToRoman(int num) {
        vector<int> numbers {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
        vector<string> romans {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};

        string res;
        for(auto i = 0; i < numbers.size(); i++) {
            while (num >= numbers[i]) {
                num -= numbers[i];
                res += romans[i];
            }

            if(num == 0)
                break;
        }

        return res;
    }
};