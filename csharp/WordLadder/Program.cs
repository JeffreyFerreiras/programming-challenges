using System.Diagnostics;
using System.Reflection;

namespace WordLadder;

internal class Program
{
    private static void Main(string[] args)
    {
        var scenarios = new[]
        {
            new Scenario("Example 1", "hit", "cog", ["hot", "dot", "dog", "lot", "log", "cog"], 5),
            new Scenario("Example 2", "hit", "cog", ["hot", "dot", "dog", "lot", "log"], 0),
            new Scenario("Single-letter words", "a", "c", ["a", "b", "c"], 2),
            new Scenario("One dictionary entry", "hot", "dot", ["dot"], 2),
            new Scenario("End word unreachable", "hit", "cog", ["hot", "cog"], 0),
            new Scenario("Start word in dictionary", "hit", "cog", ["hit", "hot", "dot", "dog", "cog"], 5),
            new Scenario("Different sequence lengths", "red", "tax", ["ted", "tex", "red", "tax", "tad", "den", "rex", "pee"], 4),
            new Scenario("Maximum word length", "aaaaaaaaaa", "aaaaaaaaab", ["aaaaaaaaab"], 2),
        };

        foreach (var scenario in scenarios)
            RunScenario(scenario);
    }

    private static void RunScenario(Scenario scenario)
    {
        Console.WriteLine($"\n=== {scenario.Name} ===");

        var methods = typeof(Solution)
            .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
            .Where(method => !method.IsSpecialName)
            .Where(method => method.ReturnType == typeof(int))
            .Where(method => method.GetParameters().Select(parameter => parameter.ParameterType)
                .SequenceEqual(new[] { typeof(string), typeof(string), typeof(IList<string>) }))
            .OrderBy(method => method.Name);

        foreach (var method in methods)
        {
            var solution = new Solution();
            var words = scenario.WordList.ToList();
            var stopwatch = Stopwatch.StartNew();
            object? result = null;
            Exception? exception = null;

            try
            {
                result = method.Invoke(solution, new object?[] { scenario.BeginWord, scenario.EndWord, words });
            }
            catch (Exception error)
            {
                exception = error.GetBaseException();
            }
            finally
            {
                stopwatch.Stop();
            }

            Console.Write($"{method.Name} | {stopwatch.Elapsed.TotalMilliseconds:0.0000} ms | ");

            if (exception is NotImplementedException)
            {
                Console.WriteLine($"PENDING: implement this method | Expected {scenario.Expected}");
                continue;
            }

            if (exception != null)
            {
                Console.WriteLine($"ERROR: {exception.Message}");
                Environment.ExitCode = 1;
                continue;
            }

            bool passed = result is int actual && actual == scenario.Expected;
            Console.WriteLine($"{result} | Expected {scenario.Expected} | {(passed ? "PASS" : "FAIL")}");
            if (!passed)
                Environment.ExitCode = 1;
        }
    }

    private sealed record Scenario(string Name, string BeginWord, string EndWord, string[] WordList, int Expected);
}
