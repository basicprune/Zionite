using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Collider myCOll;
	private GameObject Player;
	public GameObject EnemyParent;
	public GameObject PlayerOBJ;
	private GameObject[] objects;
	public float speed;

	public EnemyNavMesh enemyNavMeshScript;

	public GameObject RayCastShoot;


	private float playerDistance;
	private float otherDistance;

	public float delay = 3;
	float timer;


	// Start is called before the first frame update
	void Start()
    {
		enemyNavMeshScript = EnemyParent.GetComponent<EnemyNavMesh>();
		
    }
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.gameObject.tag);
		Player = other.gameObject;
		if (other.gameObject.tag == "Player")
		{
			//Debug.Log("LPL");
			
		}
			
		
		
	}
	private void OnTriggerExit(Collider other)
	{
		Player = null;
		if (other.gameObject.tag == "Player")
		{
			//enemyNavMeshScript.canSeePlayer = false;
		}
	}
	public void shootPlayer()
	{

		RaycastHit hit;
		Vector3 EnemyVector = EnemyParent.transform.position;

		Vector3 lookAtPlayer = Player.transform.position - EnemyParent.transform.position;

		if (Physics.Raycast(EnemyParent.transform.position, gameObject.transform.up, out hit, 50, 1 << 6))
		{
			Debug.DrawLine(EnemyVector, hit.collider.gameObject.transform.position);
			if (hit.collider.gameObject.tag == "Player")
			{
				Debug.Log("SHOT!!!");
				Renderer playerMAT = hit.collider.GetComponentInParent<Renderer>();
				 
				playerMAT.material.SetColor("_Color", Color.red);
			}
		}
		
	}

	public void rayCastHitList()
	{


		Vector3 lookAtPlayer = Player.transform.position - EnemyParent.transform.position;
		RaycastHit[] hitList = Physics.RaycastAll(EnemyParent.transform.position, lookAtPlayer, 100f);
		if (hitList.Length > 0)
		{
			
			objects = new GameObject[hitList.Length];
			for (int i = 0; i < hitList.Length; i++)
			{
				Debug.Log(hitList.Length);
				RaycastHit hit = hitList[i];
				Debug.DrawRay(RayCastShoot.transform.position, lookAtPlayer, Color.red);
				Debug.DrawLine(RayCastShoot.transform.position, hitList[i].collider.transform.position);

				if (hitList[i].collider.gameObject.tag == "Player")
				{
					 playerDistance = hitList[i].distance;
				} else if (hitList[i].collider.gameObject.tag != "Wall" && hitList[i].collider.gameObject.tag == "Player")
				{
					otherDistance = Mathf.Infinity;
					playerDistance = 1f;
				}
				if (hitList[i].collider.gameObject.tag == "Wall")
				{
					 otherDistance = hitList[i].distance;
				}
				
				if (hitList[i].collider.gameObject.tag != "player" && hitList[i].collider.gameObject.tag != "Wall")
				{
					playerDistance = Mathf.Infinity;
					otherDistance = Mathf.Infinity;
				}

				if (otherDistance <= playerDistance && hitList[i].collider.gameObject.tag != "Player")
				{
					//Debug.Log("cannot see player" + otherDistance);
					enemyNavMeshScript.canSeePlayer = false;
				} 
				if (playerDistance < otherDistance && hitList[i].collider.gameObject.tag != "Wall" || hitList[i].collider.gameObject.tag == "Player")
				{
					
					enemyNavMeshScript.canSeePlayer = true;
					//Debug.Log("Can See playter" + playerDistance);
				}
			}
		}
	}

	// Update is called once per frame
	void Update()
    {
		

		if (Player != null)
		{
			
			gameObject.transform.up -= gameObject.transform.position - Player.transform.position;
			//shootPlayer();
		} else
		{
			gameObject.transform.up = EnemyParent.transform.forward;
		}
		rayCastHitList();

		timer += Time.deltaTime;

		if (timer > delay)
		{

			shootPlayer();

			timer -= delay;
		}
	}
}
