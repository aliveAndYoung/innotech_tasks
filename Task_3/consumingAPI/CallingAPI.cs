using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using StudentConsoleApp;

namespace StudentApp
{
    public class StudentService
    {
        private static readonly HttpClient client = new HttpClient();
        private const string FilePath = "myList.json";

        public async Task InitializeDataAsync(string url)
        {
            try
            {
                Console.WriteLine("Fetching data from API...");
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Double check it looks like JSON
                if (
                    jsonResponse.TrimStart().StartsWith("{")
                    || jsonResponse.TrimStart().StartsWith("[")
                )
                {
                    await File.WriteAllTextAsync(FilePath, jsonResponse);
                    Console.WriteLine(" Data saved to myList.json");
                }
                else
                {
                    Console.WriteLine(" API returned non-JSON data. Response:");
                    Console.WriteLine(
                        jsonResponse.Substring(0, Math.Min(200, jsonResponse.Length))
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching API data: {ex.Message}");
            }
        }

        // Load students from file
        public List<Student> LoadStudents()
        {
            if (!File.Exists(FilePath))
                return new List<Student>();

            string json = File.ReadAllText(FilePath);

            return JsonSerializer.Deserialize<List<Student>>(
                    json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                ) ?? new List<Student>();
        }

        // Save students back to file
        public void SaveStudents(List<Student> students)
        {
            string json = JsonSerializer.Serialize(
                students,
                new JsonSerializerOptions { WriteIndented = true }
            );
            File.WriteAllText(FilePath, json);
        }
    }
}
