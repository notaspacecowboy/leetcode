#include <iostream>
#include <string>
#include <map>
using namespace  std;

class Solution {
public:
    int lengthOfLongestSubstring(string s) {
        int longestRun = 0;
        string currentString = "";
        map<char, bool> mDic;
        char temp;

        for (int i = 0; i < s.length(); i++)
        {
            temp = s[i];
        	
            //if this character is not in the current substring,
        	//add it to it and put the value at mdic corresponds to this char as true
            if (!mDic[temp]) {
                mDic[temp] = true;
                currentString += temp;
            }

            //if this char is already in the current substring,
        	//update the longest substring and the current substring
            else {
                if (currentString.length() > longestRun)
                    longestRun = currentString.length();
                currentString += temp;
                int toRemove = 0;
                for (int j = 0; currentString[j] != temp; j++) {
                    mDic[currentString[j]] = false;
                    toRemove++;
                }
                currentString = currentString.substr(toRemove + 1);
            }
        }
        if (currentString.length() > longestRun)
            return currentString.length();
        return longestRun;
    }
};

int main()
{
    Solution s;
    cout << s.lengthOfLongestSubstring("bbbbb");
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
