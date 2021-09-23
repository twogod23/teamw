using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class FarmerRelayTrigger : MonoBehaviour
{
  [SerializeField] GameObject relayTo;
  private FarmerFootstepSEPlayer farmerFootstepSEPlayer;

  private void Awake()
  {
    farmerFootstepSEPlayer = relayTo.GetComponent<FarmerFootstepSEPlayer>();
  }

  private void OnTriggerEnter(Collider other)
  {
    farmerFootstepSEPlayer.RelayedTrigger(other);
  }

}
