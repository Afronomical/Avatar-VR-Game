using UnityEngine;

public class RockSummon_Ability : Ability
{

    GameObject createdObject;
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] ParticleSystem summonParticle;

    ParticleSystem summonedParticlesInstance;
    Vector3 offset = new Vector3(0, 0, 5);
    Quaternion offsetRot = new Quaternion(0, 0, 0, 0);

    protected void Start()
    {
        //base.Start();
        //OnActivateAbility += Spawn;
        GestureManager.OnGestureStarted += CheckGesture;
    }

    void CheckGesture(GestureDataSO gesture)
    {
        if (!isCooldownComplete) return;

        if (gesture == requiredGestures[gestureIndex])
        {

            gestureIndex++;

            if (gestureIndex >= requiredGestures.Length)
            {
                Spawn();
            }

        }
        /*else if (gestureIndex != 0 && gesture == requiredGestures[0])
        {
            gestureIndex = 0;
        }*/
        else
        {

        }

    }

    void Spawn()
    {
        Transform player = abilityManager.player.transform;
        Quaternion yRotation = Quaternion.Euler(0, player.eulerAngles.y, 0);

        //Vector3 rockPos = player.transform.position + yRotation * offset;
        Vector3 rockPos = player.transform.position + new Vector3(player.transform.forward.x * offset.x, player.transform.forward.y * offset.y, player.transform.forward.z * offset.z);// * offset;

        /*  GameObject player = abilityManager.player;
          Vector3 rockPos = new Vector3(player.transform.forward.x + offset.x, player.transform.forward.y + offset.y, player.transform.forward.z + offset.z);*/

        createdObject = Instantiate(objectToSpawn, rockPos, Quaternion.identity);

        Debug.Log("Rock Summoned");

        StartCooldown();
    }
}
