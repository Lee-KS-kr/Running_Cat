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

        private void Start()
        {
            newCatAnim = Resources.Load<RuntimeAnimatorController>("Otter/Arts/Animations/NewCatAnim");
            obstacles = FindObjectsOfType<Obstacle>();
            steps = FindObjectsOfType<CatTowerStep>();
            Init();
        }

        private void Init()
        {
            foreach(var ob in obstacles)
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
                    GameManager.Inst.SoundMng.PlaySFX(SoundManager.Sounds.Purr);
                    break;
                default: break;
            }
        }
    }
}