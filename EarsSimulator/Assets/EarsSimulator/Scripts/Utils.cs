using UnityEngine;

static internal class Utils
{
 
    public static string GetGOPath(Transform transform)
    {
        /*
         * From :
         * https://answers.unity.com/questions/8500/how-can-i-get-the-full-path-to-a-gameobject.html
         */
        string path = transform.name;
        while (transform.parent != null)
        {
            transform = transform.parent;
            path = transform.name + "/" + path;
        }
        return path;
    }
    
    public static float ChooseRandomOffset(float minOffset, float maxOffset)
    {
        float offset = Random.Range((float) minOffset, maxOffset);
        if (CoinFlip())
        {
            offset *= -1;
        }

        return offset;
    }

    public static bool CoinFlip()
    {
        return Random.value > 0.5f;
    }

    /// <summary>
    /// Resizes a given gameObject to x and abs(y)
    /// </summary>
    /// <param name="targetGO">target GameObject</param>
    /// <param name="size">new scale</param>
    public static void SetGOScale(GameObject targetGO, float size)
    {
        targetGO.transform.localScale = new Vector3(size, Mathf.Abs(size), 1);
    }

    /// <summary>
    /// takes a 0-1 float and returns a value mapped to a Log that returns 0-1 instead
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
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
}