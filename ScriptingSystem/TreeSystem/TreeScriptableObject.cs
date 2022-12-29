using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Tree", menuName = "Tree", order = 51)]
public class TreeScriptableObject : ScriptableObject
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private GameObject _prefab;

    public string Name => _name;
    public GameObject Prefab => _prefab;
}
