using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSupport : MonoBehaviour
{
    [SerializeField] private AudioClip tileMatchSound;
    [SerializeField] private AudioClip tileFallSound;

    private AudioSource audioSource;

    private void OnEnable()
    {
        MatchChecker.OnMatchMade += OnMatch;
        Item_move.OnTileMoved += OnFall;
        ChangeItemCell.OnMoveDone += OnFall;
    }
    private void OnDisable()
    {
        MatchChecker.OnMatchMade -= OnMatch;
        Item_move.OnTileMoved -= OnFall;
        ChangeItemCell.OnMoveDone -= OnFall;
    }
    private void Start() => audioSource = GetComponent<AudioSource>();
    private void OnMatch(int cellID) => audioSource.PlayOneShot(tileMatchSound);
    private void OnFall() => audioSource.PlayOneShot(tileFallSound);
}
