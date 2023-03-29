﻿using System.Xml.Serialization;

namespace ProductShop.DTOs.Import
{
    [XmlType("Category")]
    public class P03_CategoryDto
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;
    }
}