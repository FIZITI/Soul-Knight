using UnityEngine;

public class Damage : MonoBehaviour
{ 
    private enum EnemyType{
        SwordSkillet, 
        BowSkillet
        //next enemy type
    }

    [SerializeField] private EnemyType _enemyType;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            switch (_enemyType)
            {
                case EnemyType.SwordSkillet:
                    TakeDamage(1);
                    break;

                case EnemyType.BowSkillet:

                    break;
            }
        }       
    }



    internal void TakeDamage(float _Damage)
    {
        Player._hp -= _Damage;
        Debug.Log(Player._hp);
    }


}
