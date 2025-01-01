using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.CommonTypes.Algorithms
{
    public static class BronKerboschAlgorithm
    {
        public static void RunBronKerboschAlgorithm(List<string> currentClique, List<string> candidates, List<string> excludedNodes,
                              Dictionary<string, HashSet<string>> graph,
                              ref List<string> largestClique)
        {
            if (candidates.Count == 0 && excludedNodes.Count == 0)
            {
                // Found a maximal clique
                if (currentClique.Count > largestClique.Count)
                    largestClique = new List<string>(currentClique);
                return;
            }

            foreach (var candidate in new List<string>(candidates))
            {
                // Recursive call with candidate added to the clique
                RunBronKerboschAlgorithm(
                    currentClique.Concat(new[] { candidate }).ToList(),
                    candidates.Intersect(graph[candidate]).ToList(),
                    excludedNodes.Intersect(graph[candidate]).ToList(),
                    graph,
                    ref largestClique);

                // Move v from p to x
                candidates.Remove(candidate);
                excludedNodes.Add(candidate);
            }
        }
    }
}
