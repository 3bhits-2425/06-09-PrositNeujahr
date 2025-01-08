using UnityEngine;

public class RobotAnimationController : MonoBehaviour
{
    public Animator animator; // Referenz zum Animator
    public float walkDuration = 5f; // Dauer des Gehens in Sekunden
    public float idleDuration = 2f; // Dauer des Stillstehens in Sekunden
    public float turnDuration = 3f; // Dauer der Rechtsdrehung in Sekunden

    private float timer = 0f; // Timer zum Verfolgen der aktuellen Zeit
    private int state = 0; // Animationszustand

    void Start()
    {
        // Stelle sicher, dass der Animator vorhanden ist
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Starte die Walk-Animation
        animator.SetTrigger("Walk");
    }

    void Update()
    {
        timer += Time.deltaTime;

        switch (state)
        {
            case 0:
                // Wenn die Geh-Animation abgeschlossen ist, wechsle zu Idle
                if (timer >= walkDuration)
                {
                    animator.SetTrigger("Idle");
                    timer = 0f;
                    state = 1;
                }
                break;

            case 1:
                // Wenn die Idle-Animation abgeschlossen ist, wechsle zu Turn
                if (timer >= idleDuration)
                {
                    animator.SetTrigger("RightTurn");
                    timer = 0f;
                    state = 2;
                }
                break;

            case 2:
                // Wenn die Dreh-Animation abgeschlossen ist, wechsle zu Dance
                if (timer >= turnDuration)
                {
                    animator.SetTrigger("Dance");
                    timer = 0f;
                    state = 3; // Hier endet der Animationszyklus, oder du kannst eine weitere Animation hinzufügen
                }
                break;

            case 3:
                // Optional: Eine Endbedingung für den Animationszyklus
                break;
        }
    }
}
