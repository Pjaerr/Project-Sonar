using UnityEngine;

public class WallController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "SpawnTrigger")
        {
            GameManager.instance.gameObject.GetComponent<LevelGeneration>().LevelPlacement();
        }
    }
}
