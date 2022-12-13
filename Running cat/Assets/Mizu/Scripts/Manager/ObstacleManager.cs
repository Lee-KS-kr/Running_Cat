using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizu
{
    public class ObstacleManager : MonoBehaviour
    {
        [SerializeField] private RuntimeAnimatorController newCatAnim;
        [SerializeField] private Obstacle[] obstacles;

        private void Start()
        {
            newCatAnim = Resources.Load<RuntimeAnimatorController>("Otter/Arts/Animations/NewCatAnim");
            obstacles = FindObjectsOfType<Obstacle>();
            Init();
        }

        private void Init()
        {
            foreach(var ob in obstacles)
            {
                ob.changeAnimAction -= SetCatBehaviour;
                ob.changeAnimAction += SetCatBehaviour;
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
                    break;
                case ObstacleType.CatTower:
                    anim.gameObject.transform.rotation = Quaternion.Euler(0, 90f, 0);
                    break;
                default: break;
            }
        }
    }
}