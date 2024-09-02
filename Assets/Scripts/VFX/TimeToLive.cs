using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour
{
    [SerializeField] float ageLimit = 1f;
    private float age;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (age > ageLimit)
        {
            Destroy(gameObject);
            return;
        }

        age += Time.deltaTime;
    }
}
