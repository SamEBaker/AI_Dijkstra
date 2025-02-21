using System.Collections.Generic;
using System.Data;
using UnityEngine;
using System.Collections;



public class Graph
{
    List<Connection> mConnections;

    public List<Connection> GetConnections(Node fromNode)
    {
        List<Connection> connections = new List<Connection>();
        foreach(Connection c in mConnections)
        {
            if(c.getFrom() == fromNode)
            {
                connections.Add(c);
            }
        }
        return connections;
    }

    public void Build()
    {
        mConnections = new List<Connection>();
        Node[] nodes = GameObject.FindObjectsOfType<Node>();
        foreach(Node fromNode in nodes)
        {
            foreach(Node toNode in fromNode.ConnectsTo)
            {
                float cost = (toNode.transform.position - fromNode.transform.position).magnitude;

                Connection connection = new Connection(cost, fromNode, toNode);
                mConnections.Add(connection);
            }
        }
    }
}
