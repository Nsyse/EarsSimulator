using UnityEngine;

static internal class RangeMapper
{
    /// <summary>
    /// Maps a linear 0-1 float to a quadratic function instead
    /// Visualise curve : https://www.wolframalpha.com/input/?i=y+%3D+x*x+and+x+between+0+and+1
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static float MapToQuad(float x)
    {
        if (!IsInUnitRange(x))
        {
            Debug.LogError(
                "Invalid entry.");
            return x;
        }

        float y = x * x;

        if (!IsInUnitRange(y))
        {
            Debug.LogError(
                "Invalid return.");
            return x;
        }

        return y;
    }
    
    /// <summary>
    /// Maps a linear 0-1 float to a quadratic reflection function instead
    /// Visualise curve :
    /// https://www.wolframalpha.com/input/?i=y+%3D+1+-+(1+-+x)+*+(1+-+x)+and+x+between+0+and+1
    /// </summary>
    /// <param name="x">linear 0-1 value</param>
    /// <returns></returns>
    public static float MapToQuadReflection(float x)
    {
        //TODO : clean up and avoid repetition across multiple mapping functions
        if (!IsInUnitRange(x))
        {
            Debug.LogError(
                "Invalid entry.");
            return x;
        }
        
        float y = 1 - (1 - x) * (1 - x);

        if (!IsInUnitRange(y))
        {
            Debug.LogError(
                "Invalid return.");
            return x;
        }

        Debug.Log("entry : "+x + " Output : "+y);
        
        return y;
    }
    
    private static bool IsInUnitRange(float x)
    {
        if (x < 0 || x > 1)
        {
            Debug.LogError(
                "Error : Invalid value. mapTo functions must receive and return 0-1 value! Value : " +
                x);
            return false;
        }

        return true;
    }
}