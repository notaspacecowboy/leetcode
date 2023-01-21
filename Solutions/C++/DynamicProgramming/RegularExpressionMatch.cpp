class Solution {
public:
    int dp[22][32];

    bool isMatch(string s, string p)
    {
        for (int i = 0; i < 22; i++)
        {
            for (int j = 0; j < 32; j++)
                dp[i][j] = -1;
        }
        return dynamicMatch(0, 0, s, p);
    }


    bool dynamicMatch(int i, int j, string s, string p)
    {
        if (dp[i][j] != -1)
            return dp[i][j];

        if (j >= p.length())
            return i >= s.length();

        bool currentMatch = i < s.length() && (s[i] == p[j] || p[j] == '.');

        if (j + 1 < p.length() && p[j + 1] == '*') {
            dp[i][j] = (dynamicMatch(i, j + 2, s, p) || (currentMatch && dynamicMatch(i + 1, j, s, p))) ? 1 : 0;
            return dp[i][j];
        }
        else {
            dp[i][j] = (currentMatch && dynamicMatch(i + 1, j + 1, s, p)) ? 1 : 0;
            return dp[i][j];
        }
    }
};