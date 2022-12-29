using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRemover : MonoBehaviour
{
    public void Remove(Vector3 Position, float Radius, LayerMask TreeLayer, List<Transform> Trees, out List<Transform> TreesLeft)
    {
        Collider[] trees = Physics.OverlapSphere(Position, Radius, TreeLayer);
        for(int i = 0; i < trees.Length; i++)
        {
            var tree = trees[i].GetComponentInParent<TreePrefab>().gameObject;
            Trees.Remove(tree.transform);
            Destroy(tree);
        }
        TreesLeft = Trees;
    }
}
