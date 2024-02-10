using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    [SerializeField] private List<Unit> units;
    [SerializeField] private Material _testMaterial1, _testMaterial2;

    private void Awake()
    {
        Instance = this;
    }

    public void Attack()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
