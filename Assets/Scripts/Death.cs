using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] List<Explode> explodeList = new List<Explode>();

    public void Kill()
    {
        foreach(Explode explode in explodeList)
        {
            explode.transform.parent = null;
            explode.Scatter();
        }
        print("LA COROUTINE");
        Spawner.instance.StartSpawn(1.5f);
        Destroy(gameObject);
    }
}
