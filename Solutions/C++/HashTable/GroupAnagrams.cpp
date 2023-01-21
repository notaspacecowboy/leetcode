#include <iostream>
#include <unordered_map>
#include <vector>
#include <algorithm>
using namespace std;


class Solution {
public:
    vector<vector<string>> groupAnagrams(vector<string>& strs) {
        unordered_map<string, vector<string>> lookup;

        for(auto& str: strs) {
            string sortedStr {str};
            sort(sortedStr.begin(), sortedStr.end());
            auto find = lookup.find(sortedStr);
            if(find == lookup.end())
                lookup[sortedStr] = vector<string> {str};
            else
                lookup[sortedStr].emplace_back(str);
        }

        vector<vector<string>> res;
        for(auto &pair: lookup) {
            res.emplace_back(pair.second);
        }

        return res;
    }
};