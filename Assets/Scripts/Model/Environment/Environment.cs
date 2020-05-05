﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Environment : MonoBehaviour
{
    List<CitizenBody> m_citizenList;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateAgentList()
    {
        m_citizenList.Clear();

        GameObject[] agents = GameObject.FindGameObjectsWithTag("Player");

        foreach(GameObject agent in agents)
        {
            m_citizenList.Add(agent.GetComponent<CitizenBody>());
        }
    }
}
