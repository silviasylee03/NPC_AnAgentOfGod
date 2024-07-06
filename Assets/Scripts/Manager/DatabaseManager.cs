using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance; // DB ��ü�� �ν��Ͻ�ȭ, ������ ���ϰ� static
    
    [SerializeField] string csv_fileName;
    
    Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>();   // int�� ��縦 ã�´�.
    
    public static bool isFinish = false;    // �Ľ��� �����͸� ��� �����ߴ���

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;    // �ڱ� �ڽ��� �־��ش�.
            DialogueParser parser = GetComponent<DialogueParser>();
            Dialogue[] dialogues = parser.Parse(csv_fileName);  // dialogues�� ��� �����Ͱ� ���� �ȴ�.

            for (int i = 0; i < dialogues.Length; i++)
            {
                dialogueDic.Add(i + 1, dialogues[i]);    // Ű�� 1���� ����
            }

            isFinish = true;
        }
    }
}