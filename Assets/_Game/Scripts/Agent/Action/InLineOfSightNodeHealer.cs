using System.Collections;
using System.Collections.Generic;
using Game.Agent.Tree;
using UnityEngine;

namespace Game.Enemy.Action
{
    public class InLineOfSightNodeHealer : ActionNode
    {
        public float range;

        protected override void OnStart() { }
        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            Ray ray = new(Blackboard.transform.position, Blackboard.target.position - Blackboard.gameObject.transform.position);
            RaycastHit hitinfo;
            if (Physics.Raycast(ray, out hitinfo, range))
            {
                Component t = hitinfo.rigidbody ? hitinfo.rigidbody : hitinfo.collider;
                //Debug.Log($"{t.gameObject}");
                return t.CompareTag(Blackboard.target.tag) ? State.Success : State.Failure;
            }
            else
            {                
                return State.Failure;
            }
        }
    }
}