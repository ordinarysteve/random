using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent ai;
    public List<Transform> destinations;
    public Animator aiAnimator;
    public float hearDistance, hearRadius, walkSpeed, chaseSpeed, idleTime, minIdleTime, maxIdleTime, sightDistance, catchDistance, chaseTime, minChaseTime, maxChaseTime, jumpscareTime;
    public bool walking, chasing, goNearest;
    public Transform player;
    public Transform playerCamera;
    Transform currentDest;
    Vector3 destination;
    int randNum, randNum2;
    public Vector3 rayCastOffset;
    public int destinationAmount;
    public string deathScene;
   /* public GameObject targetObject;
    public GameObject[] allObjects;
    public GameObject nearestObject;*/

    void Start()
    {
        walking = true;
        randNum = Random.Range(0, destinationAmount);
        currentDest = destinations[randNum];
        //allObjects = GameObject.FindGameObjectsWithTag("Destinations");
    }
    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position + rayCastOffset, direction, out hit, sightDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                walking = false;
//                goNearest = false;
                StopCoroutine("StayIdle");
                StartCoroutine("ChaseRoutine");
                StopCoroutine("ChaseRoutine");
                aiAnimator.ResetTrigger("walk");
                aiAnimator.ResetTrigger("idle");
                aiAnimator.SetTrigger("sprint");
                chasing = true;
            }
        }

        hearDistance = Vector3.Distance(transform.position, player.position);
        if (player.GetComponent<PlayerController>().speed > 9 && hearDistance < hearRadius)
        {
            //GameObject nearestObject = allObjects[0];
            /*nearestObject = allObjects[0];
            float shortestDistance = Vector3.Distance(targetObject.transform.position, nearestObject.transform.position);

            for (int i = 1; i < allObjects.Length; i++)
            {
                float currentDistance = Vector3.Distance(targetObject.transform.position, allObjects[i].transform.position);

                if (currentDistance < shortestDistance)
                {
                    nearestObject = allObjects[i];
                    shortestDistance = currentDistance;
                }

            }

            goNearest = true;

            Debug.Log(nearestObject);*/
        }

        /*if (goNearest == true)
        {
            destination = currentDest.position;
            ai.destination = destination;
            ai.speed = walkSpeed;
            if (ai.remainingDistance <= ai.stoppingDistance)
            {
                    currentDest = nearestObject.transform;
                    walking = true;
                    goNearest = false;
            }
        }*/

        if (chasing == true)
        {
            destination = player.position;
            ai.destination = destination;
            ai.speed = chaseSpeed;
            if (ai.remainingDistance <= catchDistance)
            {
                player.gameObject.SetActive(false);
                aiAnimator.ResetTrigger("sprint");
                aiAnimator.SetTrigger("jumpscare");
                StartCoroutine(deathRoutine());
                chasing = false;
            }
        }

        if (walking == true)
        {
            destination = currentDest.position;
            ai.destination = destination;
            ai.speed = walkSpeed;
            /*if (goNearest == true)
            {
                walking = false;
                currentDest = nearestObject.transform;
                if (ai.remainingDistance < ai.stoppingDistance)
                {
                    walking = true;
                    goNearest = false;
                }
            }*/
            if (ai.remainingDistance <= ai.stoppingDistance)
            {
                randNum2 = Random.Range(0, 2);
                if (randNum2 == 0)
                {
                    randNum = Random.Range(0, destinationAmount);
                    currentDest = destinations[randNum];
                    walking = true;

                    Debug.Log(destinations);
                }
                if (randNum2 == 1)
                {
                    aiAnimator.ResetTrigger("walk");
                    aiAnimator.SetTrigger("idle");
                    StopCoroutine("StayIdle");
                    StartCoroutine("StayIdle");
                    walking = false;
                }
            }
        }
    }

    IEnumerator StayIdle()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        goNearest = false;
        randNum = Random.Range(0, destinationAmount);
        currentDest = destinations[randNum];
        aiAnimator.ResetTrigger("idle");
        aiAnimator.SetTrigger("walk");
    }

    IEnumerator ChaseRoutine()
    {
        chaseTime = Random.Range(minChaseTime, maxChaseTime);
        yield return new WaitForSeconds(chaseTime);
        walking = true;
        chasing = false;
        randNum = Random.Range(0, destinationAmount);
        currentDest = destinations[randNum];
        aiAnimator.ResetTrigger("sprint");
        aiAnimator.SetTrigger("walk");
    }

    IEnumerator deathRoutine()
    {
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(deathScene);
    }
}
