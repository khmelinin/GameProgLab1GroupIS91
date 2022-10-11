using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1
{
    string hello = "Hello World";

    public Test1()
    {

    }

    public Test1(string s)
    {
        hello = s;
    }

    public void Hello()
    {
        Debug.Log(hello);
    }
}
