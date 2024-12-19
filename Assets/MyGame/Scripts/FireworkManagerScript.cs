using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject fireworkPrefab;


    // Start is called before the first frame update
    void Start()
    {
        Transform Pos1 = this.transform.Find("LauncherPos1");
        Transform Pos2 = this.transform.Find("LauncherPos2");

        GameObject fireworkLeft = Instantiate(fireworkPrefab, Pos1.position, Quaternion.LookRotation(Vector3.up), transform);
        GameObject fireworkRight = Instantiate(fireworkPrefab, Pos2.position, Quaternion.LookRotation(Vector3.up), transform);

        fireworkLeft.transform.SetParent(Pos1);
        fireworkRight.transform.SetParent(Pos2);

    }


}
