using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5.Models
{
    public class RegexFinder
    {
        public string[] get_matches(string pattern_regex, string input)
        {
            Regex regex = new Regex(pattern_regex);

            return regex.Matches(input).Cast<Match>().Select(m => m.Value).ToArray();
        }
    }
}
