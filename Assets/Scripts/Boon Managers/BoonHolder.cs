using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//[CreateAssetMenu(fileName = "Boon Holder", menuName = "ScriptableObjects/ActiveBoons/Boon Holder", order = 2)]
//public class BoonHolder : ScriptableObject
//{
//    public List<BoonFamily> BoonFamilies = new List<BoonFamily>();

//    public delegate void GetBoonName<out Boon>();
//    public delegate Boon GetBoon(string name);

//    public void Main() {
//        //THE LAST PARAMETER IS ALWAYS THE 'OUT' VALUE (RETURN VALUE)
//        Func<Boon> method = () => BoonFamilies[0].ActiveBoons[0]; //JUST OUT (RETURNS A BOON)
//        string result = method().BoonName;

//        Debug.Log($"Result: {result}");

//        Func<string, string> method2 = delegate(string s) //IN AND OUT (RETURNS THE PASSED IN STRING)
//        {
//            return s;
//        };

//        Func<Boon, string> method3 = delegate (Boon b) //IN AND OUT (RETURN A BOON NAME)
//        {
//            return b.UniqueName;
//        };

//        Func<Boon, string, string> method4 = delegate(Boon b, string s) //IN AND OUT (RETURN A BOON NAME)
//        {
//            return b.UniqueName + s;
//        };
        
//        Action<Boon> method5 = delegate(Boon b) //IN (DOES NOT RETURN ANYTHING, JUST EXECUTES THE FUNCTION INSIDE THE {}
//        {
//            Debug.Log(b.BoonName);
//        };

//        Func<Boon, int> method6 = delegate (Boon b) { return b.Tier; };

//        //Func<Boon, string, Boon> method6 = GetBoon(s) //IN AND OUT (RETURN A BOON NAME)
//        //{
//        //};
//    }
//}
