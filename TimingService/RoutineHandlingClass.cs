using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TimingService
{
    public class RoutineHandlingClass : IRoutineHandlingService
    {
        public async Task<Routine> LoadRoutineAsync(string routineName)
        {
            var parentPath = FileSystem.AppDataDirectory;
            var filePath = Path.Combine(parentPath, routineName);

            var routineAsJSON = await File.ReadAllTextAsync(filePath);

            return JsonSerializer.Deserialize<Routine>(routineAsJSON);
        }

        public async Task<List<Routine>> ReadRoutineInfoAsync()
        {
            List<Routine> routines = new List<Routine>();
            var parentPath = FileSystem.AppDataDirectory;

            IEnumerable<string> fileNames = Directory.EnumerateDirectories(parentPath);
            string filePath = string.Empty;
            string routineAsJSON = string.Empty;

            foreach(var file in fileNames) 
            {
                filePath = Path.Combine(parentPath, file);
                routineAsJSON = await File.ReadAllTextAsync(filePath);
                routines.Add(JsonSerializer.Deserialize<Routine>(routineAsJSON));
            }

            return routines;
        }

        public async Task WriteRoutineInfoAsync(Routine routine)
        {
            var parentPath = FileSystem.AppDataDirectory;

            if( string.IsNullOrEmpty(routine.RoutineFileName) )  routine.RoutineFileName = Guid.NewGuid().ToString();

            var filePath = Path.Combine(parentPath, routine.RoutineFileName);
            string routineAsJSON = JsonSerializer.Serialize(routine);
            await File.WriteAllTextAsync(filePath, routineAsJSON);
        }
    }
}
