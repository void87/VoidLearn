﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

namespace Test20190807 {

    [System.Serializable]
    public class AssetBundleConfig {
        [XmlElement("ABList")]
        public List<ABBase> ABList { get; set; }
    }

    [System.Serializable]
    public class ABBase {
        [XmlAttribute("Path")]
        public string Path { get; set; }
        [XmlAttribute("Crc")]
        public uint Crc { get; set; }
        [XmlAttribute("ABName")]
        public string ABName { get; set; }
        [XmlAttribute("AssetName")]
        public string AssetName { get; set; }
        [XmlElement("ABDependency")]
        public List<string> ABDependency { get; set; }
    }
}