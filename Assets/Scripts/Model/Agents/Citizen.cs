﻿using System.Linq;
using Model.Agents.States;
using Model.Agents.States.Citizen;
using Model.Environment;
using UnityEngine;

namespace Model.Agents
{
    public class Citizen : Agent
    {
        private CitizenBody m_citizenBody;
        public CitizenBody Body => m_citizenBody;
        
        private AgentEnvironment m_environment;
        public AgentEnvironment AssociatedEnvironment => m_environment;
        
        private Vector3 m_homePosition;
        public Vector3 HomePosition => m_homePosition;

        private float m_positionCloseThresh = 0.5f;
        
        private IState m_currentState;

        public Citizen()
        {
            m_currentState = new Idle(this);
        }

        protected override void Start()
        {
            base.Start();
            
            m_homePosition = gameObject.transform.position;
            m_citizenBody = gameObject.GetComponent<CitizenBody>();
                
            var env = GameObject.FindGameObjectWithTag("AgentEnvironment");
            if (!env) return;
                
            var agentEnvironment = env.GetComponent<AgentEnvironment>();
            if (agentEnvironment)
                m_environment = agentEnvironment;
        }

        void Update()
        {
            m_currentState = m_currentState.Action();
        }
    }
}
