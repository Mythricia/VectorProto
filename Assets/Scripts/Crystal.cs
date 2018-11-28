using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public enum GrowthState
    {
        Dormant,
        Growing,
        Harvestable
    }

    GrowthState State;
    public GrowthState state
    {
        get { return State; }
        protected set { State = value; }
    }

    public float lastHarvestTime;

    Vector3 startPosition;
    Vector3 endPosition;

    float growthTime = 15f;
    float growthProgress = 0;

    Collider thisCollider;

    // Use this for initialization
    void Start()
    {
        state = GrowthState.Harvestable;
        growthProgress = growthTime;

        endPosition = transform.position;
        startPosition = endPosition - (transform.forward * 1f);

        lastHarvestTime = Time.time;

        thisCollider = GetComponentInChildren<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GrowthState.Growing)
        {
            if (growthProgress >= growthTime)
            {
                transform.position = endPosition;
                growthProgress = growthTime;
                state = GrowthState.Harvestable;
                thisCollider.enabled = true;
            }
            else
            {
                Vector3 newPos = Vector3.Lerp(startPosition, endPosition, growthProgress / growthTime);
                transform.position = newPos;
                growthProgress += Time.deltaTime;
            }
        }
    }

    ///<summary>
    ///Triggers the Crystal regrowth
    ///</summary>
    public void Respawn()
    {
        state = GrowthState.Growing;
        growthProgress = 0f;
        transform.position = startPosition;
    }


    ///<summary>
    ///Harvests and hides the Crystal, but does not trigger regrowth
    ///</summary>
    public bool Harvest()
    {
        if (state == GrowthState.Harvestable)
        {
            thisCollider.enabled = false;
            state = GrowthState.Dormant;
            growthProgress = 0;
            transform.position = startPosition;

            lastHarvestTime = Time.time;

            return true;
        }
        else
        {
            print("Crystal.Harvest:: Crystal not harvestable at this time!");
            return false;
        }
    }


    public void SetGrowthTime(float newGrowthTime)
    {
        growthTime = Mathf.Max(0, newGrowthTime);
    }

    public void SetGrowthProgress(float newGrowthProgress)
    {
        growthProgress = Mathf.Clamp(newGrowthProgress, 0, growthTime);
    }

    public void SetState(GrowthState newState)
    {
        state = newState;

        switch (state)
        {
            case GrowthState.Dormant:
                break;

            case GrowthState.Growing:
                break;

            case GrowthState.Harvestable:
                growthProgress = growthTime;
                transform.position = endPosition;
                break;

            default:
                break;
        }
    }
}