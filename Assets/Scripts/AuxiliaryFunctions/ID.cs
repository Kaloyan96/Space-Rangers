using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID
{
    public string prefix { get; private set; }
    public int id { get; private set; }
    public string value { get { return prefix.Equals("") ? id.ToString() : prefix + "_" + id; } set { } }
    public IDAuthority IDAuthority { get; private set; }
    public ID(IDAuthority authority, string prefix, int value)
    {
        IDAuthority = authority;
        if (prefix == null)
        {
            this.prefix = "";
        }
        id = value;
    }
}
