using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riciever : MonoBehaviour
{
    [SerializeField] MeshRenderer mesh;
    [SerializeField] List<Material> materials = new List<Material>();
    private Coroutine routine;

    private void OnMouseDown()
    {
        if (routine != null) StopCoroutine(routine);
        mesh.material = materials[0];
        routine = StartCoroutine(nameof(Fade));
    }

    IEnumerator Fade()
    {
        mesh.material = materials[1];
        yield return new WaitForSecondsRealtime(2);
        mesh.material = materials[0];
    }

}
