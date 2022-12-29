using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : OrderAbstract
{
    [SerializeField]
    private TreeSpawner _spawner;
    [SerializeField]
    private SpawnParametrs _spawnParametrs;

    [SerializeField]
    private LayerMask _groundLayer;

    public override void MakeOrder()
    {
        CastRay();
    }

    private void CastRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, _groundLayer))
        {
            SpawnGroupValuesInput values = new SpawnGroupValuesInput(_spawnParametrs.Radius, _spawnParametrs.DistanceSpawn * _spawnParametrs.DistanceSpawn, _spawnParametrs.TreesDensity, _spawnParametrs.MaxTreesCount);
            SpawGroupMaterialInput material = new SpawGroupMaterialInput(hit.point, _groundLayer, _spawnParametrs.TreesLayer, _spawnParametrs.Active, _spawnParametrs.InstancedTrees);
            List<Transform> newListOfTrees;
            _spawner.SpawnGroup(values, material, out newListOfTrees);
            _spawnParametrs.SetTrees(newListOfTrees);
        }
    }
}
