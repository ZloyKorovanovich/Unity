using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCastRemover : OrderAbstract
{
    [SerializeField]
    private TreeRemover _remover;
    [SerializeField]
    private SpawnParametrs _spawnParametrs;

    [SerializeField]
    private LayerMask _groundLayer;

    public override void MakeOrder()
    {
        CastRemoveGroup();
    }


    private void CastRemoveGroup()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, _groundLayer))
        {
            List<Transform> newListOfTrees;
            _remover.Remove(hit.point, _spawnParametrs.Radius, _spawnParametrs.TreesLayer, _spawnParametrs.InstancedTrees, out newListOfTrees);
            _spawnParametrs.SetTrees(newListOfTrees);
        }
    }
}
