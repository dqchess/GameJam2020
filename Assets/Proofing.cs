using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proofing : MonoBehaviour
{
    public bool WetCollide = true;
    public bool HotCollide = true;
    public bool AirCollide = true;
    public bool ColdCollide = true;
    public bool Ascend = false;
    public bool Descend = false;
    public bool FloatCollide = true;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    public void ToggleProofing(ProofingType type, bool collide)
    {
        switch (type)
        {
            case ProofingType.Wet:
                playerTransform.Find("Wet").gameObject.SetActive(collide);
                break;
            case ProofingType.Hot:
                playerTransform.Find("Hot").gameObject.SetActive(collide);
                break;
            case ProofingType.Air:
                playerTransform.Find("Air").gameObject.SetActive(collide);
                playerTransform.Find("Float").gameObject.SetActive(collide);
                break;
            case ProofingType.Float:
                playerTransform.Find("Float").gameObject.SetActive(collide);
                break;
            case ProofingType.Ascend:
                playerTransform.Find("Ascend").gameObject.SetActive(!collide);
                break;
            case ProofingType.Descend:
                playerTransform.Find("Descend").gameObject.SetActive(!collide);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (!WetCollide) {
        //    playerTransform.Find("Wet").gameObject.SetActive(false);
        //} else {
        //    playerTransform.Find("Wet").gameObject.SetActive(true);
        //}

        //if (!HotCollide) {
        //    playerTransform.Find("Hot").gameObject.SetActive(false);
        //} else {
        //    playerTransform.Find("Hot").gameObject.SetActive(true);
        //}

        //if (!AirCollide) {
        //    playerTransform.Find("Air").gameObject.SetActive(false);
        //} else {
        //    playerTransform.Find("Air").gameObject.SetActive(true);
        //}

        //if (!ColdCollide) {
        //    playerTransform.Find("Cold").gameObject.SetActive(false);
        //} else {
        //    playerTransform.Find("Cold").gameObject.SetActive(true);
        //}

        //if (Ascend) {
        //    playerTransform.Find("Ascend").gameObject.SetActive(false);
        //} else {
        //    playerTransform.Find("Ascend").gameObject.SetActive(true);
        //}

        //if (!FloatCollide) {
        //    playerTransform.Find("Float").gameObject.SetActive(false);
        //} else {
        //    playerTransform.Find("Float").gameObject.SetActive(true);
        //}

        //if (Descend) {
        //    playerTransform.Find("Descend").gameObject.SetActive(false);
        //} else {
        //    playerTransform.Find("Descend").gameObject.SetActive(true);
        //}
    }
}
