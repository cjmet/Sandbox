



using System.Text.RegularExpressions;

List<string> testStrings =
[
    "01 - (Acoustic) - Big  Bad Billy",
    " 01 - (Acoustic)   - Big    Bad  Billy",
    " (Acoustic) The #01 -   Big Bad Billy", 
    " ... (Acoustic) -   01 - Big Bad Billy",
    " ... 01 #10  .   The Acoustic - 01 - Big Bad Billy",
];

string test;
foreach (string? item in testStrings)
{
    test = item;
    // Clean up anything that isn't alphanumeric or a space
    test = Regex.Replace(test, @"[^\w ]", "", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    // Remove double spaces
    test = Regex.Replace(test, @"\s+", " ", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    // Remove leading spaces and numbers
    test = Regex.Replace(test, @"^[^a-z]*", "", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    // Remove leading "The" and space
    test = Regex.Replace(test, @"^The\s*", "", RegexOptions.Compiled | RegexOptions.IgnoreCase);
}


    