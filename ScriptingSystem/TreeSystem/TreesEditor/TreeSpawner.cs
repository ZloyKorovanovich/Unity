using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SpawnGroupValuesInput
{
    private int _count;
    private int _treesMaxCount;

    private float _radius;
    private float _distanceMagnitude;


    public int Count => _count;
    public int TreesMaxCount => _treesMaxCount;

    public float Radius => _radius;
    public float DistanceMagnitude => _distanceMagnitude;



    public SpawnGroupValuesInput(float Radius, float DistanceMagnitude, int Number, int MaxCount)
    {
        _count = Number;
        _treesMaxCount = MaxCount;

        _radius = Radius;
        _distanceMagnitude = DistanceMagnitude;
    }
}

public struct SpawGroupMaterialInput
{
    private Vector3 _position;

    private LayerMask _groundLayer;
    private LayerMask _treeLayer;

    private TreeScriptableObject _active;
    private List<Transform> _treesInstanced;


    public Vector3 Position => _position;

    public LayerMask GroundLayer => _groundLayer;
    public LayerMask TreeLayer => _treeLayer;

    public TreeScriptableObject Active => _active;
    public List<Transform> TreesInstanced => _treesInstanced;



    public SpawGroupMaterialInput(Vector3 Position, LayerMask GroundLayer, LayerMask TreeLayer, TreeScriptableObject Active, List<Transform> TreesInstanced)
    {
        _position = Position;

        _groundLayer = GroundLayer;
        _treeLayer = TreeLayer;

        _active = Active;
        _treesInstanced = TreesInstanced;
    }
}

public class TreeSpawner : MonoBehaviour
{

    public void SpawnGroup(SpawnGroupValuesInput InputValueBase, SpawGroupMaterialInput InputMaterialBase, out List<Transform> Output)
    {
        Output = InputMaterialBase.TreesInstanced;
        for (int i = 0; i < InputValueBase.Count; i++)
        {
            float randomDist = Random.Range(0, InputValueBase.Radius);
            float RandomAngle = Random.Range(0, 360);

            Vector3 planePosition = new Vector3(InputMaterialBase.Position.x + randomDist * Mathf.Cos(RandomAngle), 99999, InputMaterialBase.Position.z + randomDist * Mathf.Sin(RandomAngle));

            RaycastHit hit;
            if (Physics.Raycast(planePosition, -Vector3.up, out hit, Mathf.Infinity, InputMaterialBase.GroundLayer))
            {
                if (GetClosestMagnitude(InputMaterialBase.TreesInstanced, hit.point) > InputValueBase.DistanceMagnitude)
                    Output = (SpawnTree(hit.point, new Vector3(0, Random.Range(0, 360), 0), InputMaterialBase.TreesInstanced, InputValueBase.TreesMaxCount, InputMaterialBase.Active.Prefab));
            }
        }
    }

    private float GetClosestMagnitude(List<Transform> Objects, Vector3 Position)
    {
        float closestMagnitude = Mathf.Infinity;
        for(int i = 0; i < Objects.Count; i++)
        {
            float curMagnitude = Vector3.SqrMagnitude(Objects[i].position - Position);
            if (curMagnitude <= closestMagnitude)
            {
                closestMagnitude = curMagnitude;
            }
        }
        return closestMagnitude;
    }

    private List<Transform> SpawnTree(Vector3 Position, Vector3 Rotation, List<Transform> TreesInstaced, int MaxTreesCount, GameObject Active)
    {
        if (TreesInstaced.Count >= MaxTreesCount)
            return TreesInstaced;
        TreesInstaced.Add(Instantiate(Active, Position, Quaternion.Euler(Rotation)).GetComponent<Transform>());
        return TreesInstaced;
    }
}