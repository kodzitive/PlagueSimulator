﻿using Model.Environment;
using UnityEngine;

namespace Model.Agents.States.Mayor
{
    public class Idle : MayorState
    {
        public Idle(AgentEnvironment environment, Agents.Mayor mayor) : base(environment, mayor)
        {
        }
        
        public override IState Action()
        {
            if (m_environment.LastGrowthRate > 0)
            {
                if (Random.Range(0, 1) > .5)
                    return new TimeOutside(m_environment, m_mayor);
                
                return new SocialDistancing(m_environment, m_mayor);
            }

            return this;
        }
    }
}