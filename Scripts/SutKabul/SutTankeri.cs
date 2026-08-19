using UnityEngine;

namespace FabrikaOtomasyonu.Cihazlar
{
    public class SutTankeri : FabrikaCihazi
    {
        [Header("Animator")]
        [SerializeField]
        private Animator animator;

        private readonly int kapakAc = Animator.StringToHash("KapakAc");
        private readonly int kapakKapat = Animator.StringToHash("KapakKapat");

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                KapagiAc();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                KapagiKapat();
            }
        }

        public void KapagiAc()
        {
            if (animator == null)
                return;

            animator.SetTrigger(kapakAc);
        }

        public void KapagiKapat()
        {
            if (animator == null)
                return;

            animator.SetTrigger(kapakKapat);
        }
    }
}