using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMainManager : MonoBehaviour
{
    [SerializeField]
    private CameraRayCast _cameraRayCast;

    [SerializeField]
    private List<string> _keys;
    [SerializeField]
    private List<OrderAbstract> _slaves;

    private Dictionary<string, OrderAbstract> _ordersDictionary = new Dictionary<string, OrderAbstract>();


    private void OnEnable()
    {
        for(int i = 0; i < _keys.Count; i++)
        {
            _ordersDictionary.Add(_keys[i], _slaves[i]);
        }
    }


    public void SetOrder(string Order)
    {
        OrderAbstract slave;
        _ordersDictionary.TryGetValue(Order, out slave);
        slave.MakeOrder();
    }
}
