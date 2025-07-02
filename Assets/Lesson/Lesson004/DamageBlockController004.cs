using UnityEngine;

public class DamageBlockController004 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Transform tf = other.gameObject.transform;
            tf.localScale = new Vector3(1, 0.1f, 1);
            GameDirector004.gameFlg = 1;
        }
    }
}
