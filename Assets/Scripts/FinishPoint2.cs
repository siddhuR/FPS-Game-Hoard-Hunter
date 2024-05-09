using UnityEngine;

public class FinishPoint2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScreenControlller2.instance.NextLevel();
        }
    }

}
