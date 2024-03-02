using Microsoft.Extensions.Primitives;
using System.Text;

namespace TimingService;

// All the code in this file is included in all platforms.
public class Routine
{

    public string Name { get; set; }
    public string? Description { get; set; }

    public int IntroTime { get; set; }

    public List<Round> Rounds { get; set; } = new();
    
    public string RoutineFileName { get; set; }

    /// <summary>
    /// TODO: implement this
    /// </summary>
    public string Summary { get;  }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("Name = ");
        stringBuilder.Append( Name);
        stringBuilder.Append(", Description = ");
        stringBuilder.Append(Description);
        stringBuilder.Append(" , IntroTime = ");
        stringBuilder.AppendLine(IntroTime.ToString() );

        for (int i = 0; i < Rounds.Count; ++i)
        {
            stringBuilder.Append("Round - ");
            stringBuilder.Append(i.ToString());
            stringBuilder.AppendLine(Rounds[i].ToString());
        }

        return stringBuilder.ToString();
    }
}

public class Round
{
    public int ExerciseTime { get; set; }
    public int RestTime { get; set; }

    public Round()
    {
            
    }

    public Round(int eTime, int rTime)
    {
        ExerciseTime = eTime;
        RestTime = rTime;
    }

    public Round(int eHour, int eMinute, int eSecond, int rHour, int rMinute, int rSecond)
    {
        ExerciseTime = (eHour * 3600) + (eMinute * 60) + (eSecond);
        RestTime = (rHour * 3600) + (rMinute * 60) + rSecond;
    }

    public override string ToString()
    {
        return $"Round - Exercise {ExerciseTime} Rest - {RestTime}";
    }
}

