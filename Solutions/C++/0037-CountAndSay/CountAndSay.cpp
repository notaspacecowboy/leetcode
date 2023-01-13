#include <string>
#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    void CountAndSayRecursive(string& lastResult, int n) {
        if (n == 1)
            return;

        string current = "";
        int i = 0;
        while(i < lastResult.size()) {
            char currentChar = lastResult[i];
            int j = i + 1, count = 1;
            while(j < lastResult.size() && lastResult[j] == lastResult[j - 1])
            {
                count++;
                j++;
            }
            current += (count + '0');
            current += currentChar;

            i = j;
        }

        lastResult = current;
        CountAndSayRecursive(lastResult, n - 1);
    }

    string countAndSay(int n) {
        string res = "1";
        CountAndSayRecursive(res, n);

        return res;
    }
};