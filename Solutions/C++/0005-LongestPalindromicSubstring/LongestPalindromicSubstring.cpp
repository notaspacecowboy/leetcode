#include <string>
using namespace std;

class Solution {
public:
    string longestPalindrome(string s) {
        int dp[1000][1000];
        int longest = 1, from = 0, to = 0;
        for(int i = s.length() - 1; i >= 0; i--) {
            dp[i][i] = 1;
            for(int j = i + 1; j < s.length(); j++) {
                if(j == i + 1)
                    dp[i][j] = (s[i] == s[j] ? 2 : 1);
                else if(s[i] == s[j] && dp[i + 1][j - 1] == j - i - 1)
                    dp[i][j] = j - i + 1;
                else {
                    dp[i][j] = max(max(dp[i + 1][j], dp[i][j - 1]), dp[i + 1][j - 1]);
                }

                if(dp[i][j] > longest) {
                    longest = dp[i][j];
                    from = i;
                    to = j;
                }
            }
        }
        return s.substr(from, to - from + 1);
    }
};
