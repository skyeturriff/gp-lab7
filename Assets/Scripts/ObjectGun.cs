using UnityEngine;
using System.Collections;

public class ObjectGun : MonoBehaviour {

  public GameObject objectToShoot;
  public float impulseAmount;
  public Vector3 spawnOffset;

	// Use this for initialization
	void Start () {
    if(objectToShoot == null || objectToShoot.GetComponent<Rigidbody>() == null) {
      Debug.Log("You're a terrible person for not having a valid object here. You should feel bad.");
    }
	}
	
	// Update is called once per frame
	void Update () {
    if(Input.GetMouseButtonDown(0) == true) {
      Rigidbody rigidbody = objectToShoot.GetComponent<Rigidbody>();
      if(rigidbody != null) {
        GameObject newGO = GameObject.Instantiate(objectToShoot);

        Vector3 positionToSpawnAt = transform.position + (transform.forward) + spawnOffset;
        newGO.transform.position = positionToSpawnAt;

        rigidbody = newGO.GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * impulseAmount, ForceMode.Impulse);
      }
    }
  }
}
