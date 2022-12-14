using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class ObstacleManager : MonoBehaviour
    {
        [SerializeField] private RuntimeAnimatorController newCatAnim;
        [SerializeField] private Obstacle[] obstacles;
        [SerializeField] private CatTowerStep[] steps;

        public void Initialize()
        {
            newCatAnim = Resources.Load<RuntimeAnimatorController>("Otter/Arts/Animations/NewCatAnim");
            obstacles = FindObjectsOfType<Obstacle>();
            steps = FindObjectsOfType<CatTowerStep>();

            foreach (var ob in obstacles)
            {
                ob.changeAnimAction -= SetCatBehaviour;
                ob.changeAnimAction += SetCatBehaviour;
            }

            foreach (var st in steps)
            {
                st.changeAnimAction -= SetCatBehaviour;
                st.changeAnimAction += SetCatBehaviour;
            }
        }

        static int xylophone = (int)SoundManager.Sounds.XylophoneC1;
        private void SetCatBehaviour(Animator anim, ObstacleType type, Vector3 pos)
        {
            anim.runtimeAnimatorController = newCatAnim;
            switch (type)
            {
                case ObstacleType.Juikjuik:
                    break;
                case ObstacleType.Naymnaym:
                    break;
                case ObstacleType.Mayak:
                    anim.gameObject.transform.position = new Vector3(pos.x, 0, pos.z);
                    GameManager.Inst.SoundMng.PlaySFX(SoundManager.Sounds.Purr);
                    break;
                case ObstacleType.CatTower:
                    anim.gameObject.transform.rotation = Quaternion.Euler(0, 90f, 0);
                    GameManager.Inst.SoundMng.PlaySFX((SoundManager.Sounds)xylophone);
                    xylophone++;
                    if (xylophone >= 12)
                        xylophone -= 8;
                    break;
                default: break;
            }
        }
    }
}