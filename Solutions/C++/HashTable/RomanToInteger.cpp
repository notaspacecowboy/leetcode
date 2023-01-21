#include <string>
#include <unordered_map>

using namespace std;

class Solution {
public:
    int romanToInt(string s) {
        unordered_map<char, int> lookup {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
        };

        int res = 0;
        for(int i = 0; i < s.size() - 1; i++) {
            char current = s[i], next = s[i + 1];
            if(lookup[current] < lookup[next])
                res -= lookup[current];
            else
                res += lookup[current];
        }

        res += lookup[s[s.size() - 1]];

        return res;
    }
};