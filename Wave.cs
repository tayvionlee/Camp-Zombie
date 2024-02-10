using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave", fileName = "ScriptableObjects/Waves")]
public class Wave : ScriptableObject
{ 
    [field: SerializeField]
    // array of enemies to spawn
    public GameObject[] enemiesToSpawn { get; private set; }

    [field: SerializeField]
    // time until next wave
    public float timeBeforeThisWave { get; private set; }

    [field: SerializeField]
    // the amount of enemies to spawn
    public float numberToSpawn { get; private set; }
}
