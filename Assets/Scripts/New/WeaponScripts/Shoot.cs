using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
	public GameObject gunEnd;
	public int Damage;
	public GameObject bulletMark;

	public InputAction raycastTestInput;
	public AudioClip targetHitSound;
	public void Start()
	{
		raycastTestInput.Enable();
	}
	public void raycastShoot()
	{
		RaycastHit hit;
		
		if (Physics.Raycast(gunEnd.transform.position, gunEnd.transform.forward, out hit, 150f))
		{
			Debug.Log(hit.collider.gameObject.name);
			Debug.Log(hit.collider.tag);
			if (hit.collider.tag == "Enemy")
			{
				Health healthScript = hit.collider.gameObject.GetComponent<Health>();
				healthScript.health = healthScript.health - Damage;
			}
			else if (hit.collider.gameObject.tag == "Target")
			{
				GameObject tempBulletMark;
				tempBulletMark = Instantiate(bulletMark, hit.point, transform.rotation * Quaternion.Euler(0, 0, 0)) as GameObject; 
				tempBulletMark.transform.Rotate(0,-90,0);
				tempBulletMark.transform.parent = hit.collider.gameObject.transform;
				AudioSource targetSource = hit.collider.gameObject.GetComponent<AudioSource>();
				targetSource.PlayOneShot(targetHitSound);

				//Destroy(tempBulletMark, 30.0f);
			}
		}
	}
	public void Update()
	{
		if (raycastTestInput.WasPressedThisFrame() == true)
		{
			raycastShoot();
		}
	}
}
