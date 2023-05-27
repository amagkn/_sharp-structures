namespace SharpStructures;

public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> set = new HashSet<int>();

        foreach (var n in nums)
        {
            if (set.Contains(n))
            {
                return true;
            }

            set.Add(n);
        }

        return false;
    }
    
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        Dictionary<char, int> dict = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            dict[s[i]] = dict.ContainsKey(s[i]) ? dict[s[i]] + 1 : 1;
            dict[t[i]] = dict.ContainsKey(t[i]) ? dict[t[i]] - 1 : -1;
        }

        foreach (var val in dict.Values)
        {
            if (val != 0) return false;
        }
        
        return true;
    }

    public int[] ReplaceElements(int[] arr)
    {
        int max = -1;
        int[] result = new int[arr.Length];

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            var currentValue = arr[i];

            result[i] = max;

            max = Math.Max(max, currentValue);
        }

        return result;
    }

    public bool IsSubsequence(string s, string t)
    {
        if (s.Length == 0) return true; 
        
        int sIndex = 0;

        foreach (var ch in t)
        {
            
            if (ch == s[sIndex])
            {
                sIndex++;

                if (sIndex == s.Length)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public int LengthOfLastWord(string s)
    {
        int wordLength = 0;

        for (var i = s.Length - 1; i >= 0; i--)
        {
            var ch = s[i];
            
            if (ch == ' ')
            {
                if (wordLength > 0) break;
            }
            else
            {
                wordLength++;
            }
        }

        return wordLength;
    }

    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int diff = target - nums[i];

            if (dict.ContainsKey(diff))
            {
                return new[] { dict[diff], i };
            }
            
            dict.TryAdd(nums[i], i);
        }

        return new int[] { };
    }

    public string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length == 0) return "";
        
        string baseWord = strs[0];
        string result = "";

        for (int i = 0; i < baseWord.Length; i++)
        {
            char currentSymbol = baseWord[i];

            for (int k = 1; k < strs.Length; k++)
            {
                string currentWord = strs[k];

                if (currentWord.Length == i) return result;

                char symbolForCompare = currentWord[i];

                if (currentSymbol != symbolForCompare)
                {
                    return result;
                }
            }

            result += currentSymbol;
        }

        return result;
    }

    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, IList<string>> dict = new Dictionary<string, IList<string>>();

        foreach (var word in strs)
        {
            char[] symbols = word.ToCharArray();
            Array.Sort(symbols);
            string sortedString = new string(symbols);

            if (dict.ContainsKey(sortedString))
            {
                dict[sortedString].Add(word);
            }
            else
            {
                dict[sortedString] = new List<string>() { word };
            }
        }

        IList<IList<string>> result = new List<IList<string>>();

        foreach (var pair in dict)
        {
            result.Add(pair.Value);
        }
        
        return result;
    }

    public IList<IList<int>> Generate(int numRows)
    {
        if (numRows < 1) return null;
        
        IList<IList<int>> result = new List<IList<int>>() {new List<int>() {1}};
        
        for (int i = 1; i < numRows; i++)
        {
            IList<int> prevRow = result.Last();
            IList<int> currentRow = new List<int>();
        
            for (int k = 0; k <= prevRow.Count; k++)
            {
                int prev = k == 0 ? 0 : prevRow[k - 1];
                int current = k == prevRow.Count ? 0 : prevRow[k];
                
                currentRow.Add(prev + current);
            }
            
            result.Add(currentRow);
        }
        
        return result;
    }
}