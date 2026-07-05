using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDrawer : MonoBehaviour {

    List<DRAWMESH> Que;

    void Awake()
    {
        Que = new List<DRAWMESH>();
    }

	// Update is called once per frame
	void Update ()
    {
        Que.Clear();
	}

    void OnRenderObject()
    {
		if(Que.Count>0)
        {
            foreach(DRAWMESH dm in Que)
            {
                Graphics.DrawMesh(dm.mesh, Vector3.zero, Quaternion.identity, dm.material, 9, Camera.current);
            }
        }
    }

    class DRAWMESH
    {
        public Mesh mesh;
        public Material material;
    }

    public void AddQue(Mesh m,Material t)
    {
        if (Que == null)
        {
            Que = new List<DRAWMESH>();
        }
        DRAWMESH dm = new DRAWMESH();
        dm.mesh = m;
        dm.material = t;
        Que.Add(dm);
    }
}
