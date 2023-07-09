using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "MyGame/Stats", order = 1)]
public class Stats : ScriptableObject
{
    public float memory = 50.0f;
    public float focus = 50.0f;
    public float antiSpam = 0.5f;
    public float timeSpeed = 4.0f;
    public float loadTime = 2.0f;
}