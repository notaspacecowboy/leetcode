#include <string>
#include <iostream>
#include <vector>
#include <stack>
using namespace std;

class Solution {
public:
    string simplifyPath(string path) {
        stack<string> paths;

        int i = 0;
        while (i < path.length()) {
            while(i < path.length() && path[i] == '/')
                i++;

            string currentPath;
            while(i < path.length() && path[i] != '/') {
                currentPath += path[i++];
            }

            if(currentPath.length() == 0 || currentPath == ".")
                continue;
            else if(currentPath == "..") {
                if(!paths.empty())
                    paths.pop();
            }
            else
                paths.push(currentPath);
        }

        if(paths.size() == 0)
            return "/";

        string res;

        while(!paths.empty()) {
            res = "/" + paths.top() + res;
            paths.pop();
        }

        return res;
    }
};