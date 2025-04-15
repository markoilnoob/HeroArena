using System;
using UnityEngine;

namespace HeroArena
{
    public static class HeroArenaUtils
    {
        public static T GetRandomEnumValue<T>(int excludeLowest = 0, int excludeHighest = 0)
        {
            // Get all enum values as an array.
            T[] values = (T[])Enum.GetValues(typeof(T));
            int totalValues = values.Length;

            // Ensure that the exclusion parameters are within a valid range.
            if (excludeLowest < 0 || excludeHighest < 0 || (excludeLowest + excludeHighest) >= totalValues)
            {
                Debug.LogError("Invalid exclusion parameters. The sum of exclusions must be less than the total number of enum values, and none can be negative.");
                return values[0];  // Return the first value as a fallback.
            }

            // Determine the valid range.
            int startIndex = excludeLowest;
            int endIndexExclusive = totalValues - excludeHighest; // Random.Range is exclusive on the max value.

            // Pick a random index within the allowed range.
            int randomIndex = UnityEngine.Random.Range(startIndex, endIndexExclusive);
            return values[randomIndex];
        }
    }

}