using System.Text.RegularExpressions;

string filePath = args[0];

if (!File.Exists(filePath))
{
    Console.WriteLine("The file does not exist.");
    return 1;
}

try
{
    // Read the file content
    string fileContent = File.ReadAllText(filePath);

    // Define the regex pattern to match "}"+ breaks, tabs or spaces, and "break;"
    string pattern = @"}\s*break;";

    // Replace the matched pattern with "} break;"
    string updatedContent = Regex.Replace(fileContent, pattern, "} break;");

    // Write the updated content back to the file
    File.WriteAllText(filePath, updatedContent);
    
    Console.WriteLine("Brace break joining is done!");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
return 0;