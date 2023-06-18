using UnityEngine;

namespace Gamekit2D
{
    public class FmodPlayer : MonoBehaviour
    {
        private float distance = 0.05f;
        private float Material;
        private bool wasGrounded = true;
        private LayerMask LM = 1 << 31;

        FMOD.Studio.EventInstance Footsteps;
        FMOD.Studio.EventInstance Landing;

        private PlayerCharacter pc;

        void Start()
        {
            Footsteps = FMODUnity.RuntimeManager.CreateInstance("event:/Ellen/Locomotion/EllenFootstep");         
            pc = GetComponent<PlayerCharacter>();
        }

        void PlayMeleeEvent(string path)
        {
            FMODUnity.RuntimeManager.PlayOneShot(path, transform.position);
        }

        void FixedUpdate()
        {
            MaterialCheck();
            Debug.DrawRay(transform.position, Vector2.down * distance, Color.blue);

            PlayerLanded();
            wasGrounded = IsGrounded();
            IsGrounded();

            Footsteps.setParameterByName("Material", Material);
            Landing.setParameterByName("Material", Material);
        }

        void MaterialCheck()
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(transform.position, Vector2.down, distance, LM);

            if (hit.collider)
            {
                if (hit.collider.tag == "Material: Earth")
                    Material = 1f;
                else if (hit.collider.tag == "Material: Stone")
                    Material = 2f;
                else
                    Material = 1f;
            }
        }

        void PlayFootstep()
        {
            Footsteps.start();
        }

        void OnDestroy()
        {
            Footsteps.release();
        }
void PlayCrouch(string argument)//
{
FMODUnity.RuntimeManager.PlayOneShot(argument);//
}
void PlayCrouchGun(string argument)//
{
FMODUnity.RuntimeManager.PlayOneShot(argument);//
}
void PlayJump()//
{
FMODUnity.RuntimeManager.PlayOneShot("event:/Ellen/Locomotion/EllenJump");//
}

        void PlayerLanded()
        {
            if (IsGrounded() && !wasGrounded && pc.m_MoveVector.y < -5)
            {
                Landing = FMODUnity.RuntimeManager.CreateInstance("event:/Ellen/Locomotion/EllenFootstepLand");
                FMODUnity.RuntimeManager.AttachInstanceToGameObject(Landing, transform, GetComponent<Rigidbody2D>());
                Landing.start();
                Landing.release();
                //Debug.Log(pc.m_MoveVector.y);
            }
        }

        bool IsGrounded()
        {
            return Physics2D.Raycast(transform.position, Vector2.down, distance, LM);
        }
    }
}