using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDroneAttack : MonoBehaviour
{
    Transform eyes;
    RaycastHit hit;
    AttackDroneMove adMove;
    FireBlast fBlast;
    LightningBlast lBlast;
    BulletFire bFireRight;
    BulletFire bFireLeft;

    // Start is called before the first frame update
    void Start()
    {
        eyes = transform.Find("Eyes");
        adMove = GetComponent<AttackDroneMove>();
        fBlast = transform.Find("PA_ArchfireBody").transform.Find("Top Left Fire Spot").GetComponent<FireBlast>();
        lBlast = transform.Find("PA_ArchfireBody").transform.Find("Top Right Fire Spot").GetComponent<LightningBlast>();
        bFireRight = transform.Find("PA_ArchfireBody").transform.Find("Bottom Right Fire Spot").GetComponent<BulletFire>();
        bFireLeft = transform.Find("PA_ArchfireBody").transform.Find("Bottom Left Fire Spot").GetComponent<BulletFire>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(eyes.position, transform.forward, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(eyes.position, transform.forward, Color.cyan);

            GameObject target = hit.collider.gameObject;

            foreach (GameObject enemy in adMove.enemies)
            {
                if (target.name.Equals(enemy.name))
                {
                    foreach (Transform child in target.GetComponentsInChildren<Transform>())
                    {
                        if (child.CompareTag("Treasure"))
                        {
                            fBlast.Fire();
                            lBlast.Fire();
                            
                        }

                        else
                        {
                            bFireRight.Fire();
                            bFireLeft.Fire();
                        }

                    }
                }
            }
        }

    }
}
