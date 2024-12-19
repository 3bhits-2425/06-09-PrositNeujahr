using UnityEngine;

public class TextManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private float posIncrementSize;
    Vector3 startPos;
    Vector3 endPos;
    GameObject textObject;

    void Start()
    {
        startPos = this.transform.Find("TextStartPos").position;
        endPos = startPos + new Vector3(0, 5, 0);

        textObject = Instantiate(textPrefab, startPos, Quaternion.identity, transform);

    }

    private void Update()
    {
        Vector3 currentPos = textObject.transform.position;
        if (currentPos.y < endPos.y)
        {
            currentPos.y += new Vector3(0, posIncrementSize, 0).y * Time.deltaTime; // deltaTime damit nicht Frame dependent ist
            textObject.transform.position = currentPos;
        }
    }
}
