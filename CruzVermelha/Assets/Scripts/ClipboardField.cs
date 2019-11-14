
using UnityEngine;
using UnityEngine.UI;

public class ClipboardField : MonoBehaviour
{
    [SerializeField]
    Image positiveImage;

    [SerializeField]
    Image negativeImage;

    //O ? no final do nome da variavel faz com o que o valor possa ser null
    bool? fieldValue = null;

   public void SetToValue(bool? newValue)
    {
        fieldValue = newValue;
        if(fieldValue == false)
        {
            negativeImage.enabled = true;
            positiveImage.enabled = false;
        }
        else if(fieldValue == true)
        {
            negativeImage.enabled = false;
            positiveImage.enabled = true;
        }
        else if(fieldValue == null)
        {
            negativeImage.enabled = false;
            positiveImage.enabled = false;
        }
    }
}
