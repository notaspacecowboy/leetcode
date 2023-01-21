#include <vector>
#include <string>
using namespace std;

class Solution {
public:
    void generateParenthesisRecursively(vector<string>& res, string currentStr, int leftParenToAdd, int leftParenToPair) {
        if(leftParenToAdd == 0) {
            while(leftParenToPair > 0) {
                currentStr += ")";
                leftParenToPair--;
            }
            res.emplace_back(currentStr);

            return;
        }

        if(leftParenToPair > 0)
            generateParenthesisRecursively(res, currentStr + ")", leftParenToAdd, leftParenToPair - 1);
        generateParenthesisRecursively(res, currentStr + "(", leftParenToAdd - 1, leftParenToPair + 1);
    }

    vector<string> generateParenthesis(int n) {
        vector<string> res;
        generateParenthesisRecursively(res, "(", n - 1, 1);

        return res;
    }
};