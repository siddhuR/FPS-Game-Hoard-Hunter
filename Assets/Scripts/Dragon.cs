using UnityEngine;
using UnityEngine.UI;

public class Dragon : MonoBehaviour
{
    private int HP = 100;
    public Slider healthBar;
    public int scoreValue = 100;
    
    public Animator animator;
    
    void Update(){
    	healthBar.value = HP;
        
    }
    

    

    

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if(HP <= 0)
        {
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            ScoreManager.instance.AddScore(scoreValue);
            
            
        }
        else
        {
            
            animator.SetTrigger("damage");
        }
    }

    

}