using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;


public class Player
{
   public List<Stats> playerStats = new List<Stats>();
    
}

public class Stats
{
    [XmlElement(DataType = "string", ElementName = "Name")]
    public string name;
    [XmlElement(DataType = "float", ElementName = "Health")]
    public float health;
    [XmlElement(DataType = "float", ElementName = "Magic")]
    public float magic;
    [XmlElement(DataType = "int", ElementName = "Money")]
    public int currency;
}




