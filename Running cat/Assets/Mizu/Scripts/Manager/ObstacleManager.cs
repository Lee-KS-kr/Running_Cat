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
        [SerializeField] private FinalBox[] boxes;

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

        public void AddNewObstacle(FinalBox[] finalBoxes)
        {
            boxes = finalBoxes;
            foreach(var box in boxes)
            {
                box.changeAnimAction -= SetCatBehaviour;
                box.changeAnimAction += SetCatBehaviour;
            }
        }

        static int xylophone = (int)SoundManager.Sounds.XylophoneC1;
        private void SetCatBehaviour(Animator anim, ObstacleType type, Vector3 pos)
        {
            anim.runtimeAnimatorController = newCatAnim;
            switch (type)
            {
                case ObstacleType.Juikjuik:
                    GameManager.Inst.SoundMng.PlaySFX(SoundManager.Sounds.Hiss);
                    break;
                case ObstacleType.Naymnaym:
                    GameManager.Inst.SoundMng.PlaySFX(SoundManager.Sounds.Drink);
                    break;
                case ObstacleType.Mayak:
                    anim.gameObject.transform.position = new Vector3(pos.x, pos.y + 0.75f, pos.z);
                    anim.gameObject.transform.rotation = Quaternion.Euler(0, 180f, 0f);
                    GameManager.Inst.SoundMng.PlaySFX(SoundManager.Sounds.Purr);
                    break;
                case ObstacleType.CatTower:
                    anim.gameObject.transform.rotation = Quaternion.Euler(0, 90f, 0);
                    GameManager.Inst.SoundMng.PlaySFX((SoundManager.Sounds)xylophone);
                    xylophone++;
                    if (xylophone >= 13)
                        xylophone = 13;
                    break;
                case ObstacleType.FinalBox:
                    GameManager.Inst.SoundMng.PlaySFX(SoundManager.Sounds.Purr);
                    break;
                default: break;
            }
        }
    }
}