using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDrawer : MonoBehaviour {

    List<DRAWMESH> Que;

    void Awake()
    {
        Que = new List<DRAWMESH>();
    }

    void OnEnable()
    {
        Camera.onPostRender += DrawQueuedMeshes;
    }

    void OnDisable()
    {
        Camera.onPostRender -= DrawQueuedMeshes;
    }

	// Update is called once per frame
	void Update ()
    {
        Que.Clear();
	}

    void DrawQueuedMeshes(Camera camera)
    {
        if (Que == null || Que.Count <= 0)
        {
            return;
        }

        if ((camera.cullingMask & (1 << gameObject.layer)) == 0)
        {
            return;
        }

        foreach(DRAWMESH dm in Que)
        {
            if (dm.mesh == null || dm.material == null)
            {
                continue;
            }

            dm.material.SetPass(0);
            Graphics.DrawMeshNow(dm.mesh, Vector3.zero, Quaternion.identity);
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
