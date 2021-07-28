using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    [SerializeField] note notePrefab;
    private void Start()
    {
        SpawnNote();
    }
    public void SpawnNote()
    {
        Instantiate(notePrefab, new Vector3(-5, 30, 0), Quaternion.identity);
    }
}