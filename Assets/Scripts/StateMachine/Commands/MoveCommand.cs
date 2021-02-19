using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command, IHasDestination
{
    public MoveCommand(Predicate predicate, params object[] parameters) : base(predicate, parameters)
    {
        Parameters["Destination"] = parameters[0];
    }

    public Vector3 Destination { get { return (Parameters["Destination"] is Vector3) ? (Vector3)Parameters["Destination"] : new Vector3(); } set { } }//wrap vector as destination

}
