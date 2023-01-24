#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    void findIpAddress(vector<string> &res, string &s, string &current, int count, int index) {
        if(count == 4 && index != s.length())
            return;

        if(count == 4) {
            res.emplace_back(string {current});
            return;
        }

        if(index >= s.length())
            return;

        if(s[index] == '0') {
            if(count != 0)
                current.push_back('.');
            current.push_back(s[index]);
            findIpAddress(res, s, current, count + 1, index + 1);
            current.pop_back();
            if(count != 0)
                current.pop_back();
        }
        else {
            int val = 0;
            for(int i = index; i < s.length() && i < index + 3; i++) {
                val *= 10;
                val += (s[i] - '0');
                if(val > 255)
                    break;

                if(count != 0)
                    current.push_back('.');
                for (int j = index; j <= i; j++)
                    current.push_back(s[j]);
                findIpAddress(res, s, current, count + 1, index + i - index + 1);
                for (int j = index; j <= i; j++)
                    current.pop_back();
                if(count != 0)
                    current.pop_back();
            }
        }
    }

    vector<string> restoreIpAddresses(string s) {
        vector<string> res;
        string current;
        findIpAddress(res, s, current, 0, 0);
        return res;
    }
};