using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeek : MonoBehaviour
{

    public GameObject target;
    public float enemySpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveSeek();
    }

    void MoveSeek()
    {
        Vector3 targetPos = target.transform.position;
        Vector3 agentPos = transform.position;
        Vector3 distance = targetPos - agentPos;
        Vector3 velocity = distance.normalized * enemySpeed;
        transform.position += velocity* Time.deltaTime;
    }
}
