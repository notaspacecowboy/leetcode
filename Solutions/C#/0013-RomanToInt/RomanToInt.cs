using System;

int RomanToInt(string s)
{
    Dictionary<char, int> lookup = new()
    {
        ['I'] = 1,
        ['V'] = 5,
        ['X'] = 10,
        ['L'] = 50,
        ['C'] = 100,
        ['D'] = 500,
        ['M'] = 1000
    };

    int i = 0, result = 0, current, next;
    while (i < s.Length - 1)
    {
        current = lookup[s[i]];
        next = lookup[s[i + 1]];
        if (current < next)
            result -= current;
        else
            result += current;
        i++;
    }

    result += lookup[s[i]];
    return result;
}