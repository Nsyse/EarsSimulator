using UnityEngine;

static internal class Utils
{
    public static void DestroyAllChildren(GameObject root)
    {
        foreach (Transform child in root.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

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
}