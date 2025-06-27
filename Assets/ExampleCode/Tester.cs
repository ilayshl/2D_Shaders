using UnityEngine;

namespace ExampleCode
{
    public class Tester : MonoBehaviour
    {
        int num = 0;
        private void Start()
        {
            if(num == 0)
            {
                num = Random.Range(0,100);
                Debug.Log(num);
            }

            for(int i = 0; i < 15; i++)
            {
                num += i;
            }
        }
    }
}
