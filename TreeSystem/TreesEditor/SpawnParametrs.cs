using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParametrs : MonoBehaviour
{
    [SerializeField]
    private int _treesDensity;
    [SerializeField]
    private int _maxTreesCount;
    [SerializeField]
    private float _distanceSpawn;
    [SerializeField]
    private float _radius;

    [SerializeField]
    private LayerMask _treesLayers;

    [SerializeField]
    private List<TreeScriptableObject> _treeTypes = new List<TreeScriptableObject>();

    private TreeScriptableObject _active;
    private List<Transform> _instancedTrees = new List<Transform>();


    public int TreesDensity => _treesDensity;
    public int MaxTreesCount => _maxTreesCount;
    public float DistanceSpawn => _distanceSpawn;
    public float Radius => _radius;

    public LayerMask TreesLayer => _treesLayers;

    public TreeScriptableObject Active => _active;
    public List<Transform> InstancedTrees => _instancedTrees;


    private void OnEnable()
    {
        _active = _treeTypes[0];
    }

    public void SetTrees(List<Transform> Instanced)
    {
        _instancedTrees = Instanced;
    }


    public void ChangeActive(int index)
    {
        int count = _treeTypes.Count;
        if (index >= count)
            index = count;
        _active = _treeTypes[index];
    }

    public void ClearTrees()
    {
        for(int i = 0; i < _treeTypes.Count; i++)
        {
            Destroy(_treeTypes[i]);
        }
        _treeTypes.Clear();
    }
}
