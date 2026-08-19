using UnityEngine;
using UnityEngine.UI;

public class KontrolPaneli2 : MonoBehaviour
{
    [Header("Bool")]
    public bool t1;
    public bool t2;
    public bool t3;
    public bool t4;
    public bool t5;
    public bool t6;
    public bool t7;

    [Header("Colors")]
    public Image color1;
    public Image color2;
    public Image color3;
    public Image color4;
    public Image color5;
    public Image color6;
    public Image color7;

    public void T1() { if(t1)  { color1.color = (Color.red); } if (!t1) { color1.color = (Color.red); } }
    public void T2() { if (t2) { color1.color = (Color.red); } if (!t2) { color2.color = (Color.red); } }
    public void T3() { if (t3) { color1.color = (Color.red); } if (!t3) { color3.color = (Color.red); } }
    public void T4() { if (t4) { color1.color = (Color.red); } if (!t4) { color4.color = (Color.red); } }
    public void T5() { if (t5) { color1.color = (Color.red); } if (!t5) { color5.color = (Color.red); } }
    public void T6() { if (t6) { color1.color = (Color.red); } if (!t6) { color6.color = (Color.red); } }
    public void T7() { if (t7) { color1.color = (Color.red); } if (!t7) { color7.color = (Color.red); } }
}
