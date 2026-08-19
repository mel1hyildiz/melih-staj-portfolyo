using System.Collections.Generic;
using UnityEngine;

public class KonveyorYol : MonoBehaviour
{
    [Header("Hareket Edecek Çubuklar")]
    [SerializeField] private Transform[] cubuklar;


    [Header("Waypointler")]
    [SerializeField] private Transform[] waypoints;


    [Header("Ayarlar")]
    [SerializeField] private float hiz = 1f;


    [Header("Konveyör Animasyonu")]
    [SerializeField] private Animator konveyorAnimator;
    [SerializeField] private string baslatTrigger = "Baslat";
    [SerializeField] private string durdurTrigger = "Durdur";


    private class RodData
    {
        public Transform transform;

        public Transform boxPoint;
        public Transform tasidigiKutu;


        public int currentWaypoint;
        public int targetWaypoint;

        public Queue<int> targets = new Queue<int>();

        public bool moving;
    }


    private readonly List<RodData> rods = new List<RodData>();


    private readonly int[] baslangicWaypointleri =
    {
        0,
        1,
        2,
        3,
        5,
        6,
        7,
        8,
        9,
        10
    };



    private void Start()
    {
        rods.Clear();


        for (int i = 0; i < cubuklar.Length; i++)
        {
            RodData rod = new RodData();


            rod.transform = cubuklar[i];


            rod.boxPoint = cubuklar[i].Find("BoxPoint");


            rod.currentWaypoint = baslangicWaypointleri[i];

            rod.targetWaypoint = rod.currentWaypoint;


            rod.transform.position =
                waypoints[rod.currentWaypoint].position;


            rods.Add(rod);
        }
    }



    private void Update()
    {
        foreach (RodData rod in rods)
        {

            if (rod.tasidigiKutu != null && rod.boxPoint != null)
            {
                rod.tasidigiKutu.position =
                    rod.boxPoint.position;

                rod.tasidigiKutu.rotation =
                    rod.boxPoint.rotation;
            }



            if (!rod.moving)
                continue;



            rod.transform.position =
                Vector3.MoveTowards(
                    rod.transform.position,
                    waypoints[rod.targetWaypoint].position,
                    hiz * Time.deltaTime);



            if (Vector3.Distance(
                rod.transform.position,
                waypoints[rod.targetWaypoint].position) < 0.001f)
            {

                rod.transform.position =
                    waypoints[rod.targetWaypoint].position;


                rod.currentWaypoint =
                    rod.targetWaypoint;



                if (rod.targets.Count > 0)
                {
                    rod.targetWaypoint =
                        rod.targets.Dequeue();
                }
                else
                {
                    rod.moving = false;


                    if (TumCubuklarDurdu())
                    {
                        if (konveyorAnimator != null)
                        {
                            konveyorAnimator.ResetTrigger(baslatTrigger);
                            konveyorAnimator.SetTrigger(durdurTrigger);
                        }
                    }
                }
            }
        }
    }




    public void KutuAta(Transform cubuk, Transform kutu)
    {
        foreach (RodData rod in rods)
        {
            if (rod.transform == cubuk)
            {
                rod.tasidigiKutu = kutu;
                return;
            }
        }
    }




    public void KutuBirak(Transform kutu)
    {
        foreach (RodData rod in rods)
        {
            if (rod.tasidigiKutu == kutu)
            {
                Debug.Log("Kutu konveyörden ayrýldý: " + kutu.name);


                rod.tasidigiKutu = null;

                if (kutu.parent == rod.boxPoint)
                    kutu.SetParent(null);

                BoxState state = kutu.GetComponent<BoxState>();

                if (state != null)
                    state.konveyoreBaglanabilir = false;
                    state.konveyordenAyrildi = true;

                return;
            }
        }

        Debug.LogWarning("Kutu hiçbir çubukta bulunamadý!");
    }




    public bool KutusuVarMi(Transform cubuk)
    {
        foreach (RodData rod in rods)
        {
            if (rod.transform == cubuk)
            {
                return rod.tasidigiKutu != null;
            }
        }

        return false;
    }





    public void IleriGit()
    {

        if (konveyorAnimator != null)
        {
            konveyorAnimator.ResetTrigger(durdurTrigger);
            konveyorAnimator.SetTrigger(baslatTrigger);
        }



        foreach (RodData rod in rods)
        {

            if (rod.moving)
                continue;



            rod.targets.Clear();



            switch (rod.currentWaypoint)
            {

                case 3:

                    rod.targets.Enqueue(4);
                    rod.targets.Enqueue(5);

                    break;


                case 10:

                    rod.targets.Enqueue(11);
                    rod.targets.Enqueue(0);

                    break;


                default:

                    rod.targets.Enqueue(
                        rod.currentWaypoint + 1);

                    break;
            }



            rod.targetWaypoint =
                rod.targets.Dequeue();


            rod.moving = true;
        }
    }




    private bool TumCubuklarDurdu()
    {
        foreach (RodData rod in rods)
        {
            if (rod.moving)
                return false;
        }


        return true;
    }
}