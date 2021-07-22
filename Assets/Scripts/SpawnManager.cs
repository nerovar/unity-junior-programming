using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<Target> targets;
    [SerializeField] private float delay, repeat;
    
    // Start is called before the first frame update
    void Start() => InvokeRepeating(nameof(Spawn), delay, repeat);

    public virtual void Spawn()
    {
        float xPos = Random.Range(-GameManager.Instance.XBounds, GameManager.Instance.XBounds);
        float yPos = Random.Range(-GameManager.Instance.YBounds, GameManager.Instance.YBounds);
        int index = Random.Range(0, targets.Count);
        Instantiate(targets[index], new Vector3(xPos, yPos, 0f), Quaternion.identity);
    }
}
