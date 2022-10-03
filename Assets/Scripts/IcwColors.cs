using UnityEngine;


namespace IcwBaloons
{
    public class IcwColors
    {
        static public Color[] colors = { Color.red, Color.green, Color.blue, Color.yellow, Color.cyan, Color.magenta };
        static public Color GetRandomColor() => colors[Random.Range(0, colors.Length)];

    }
}
