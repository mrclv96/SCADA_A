﻿using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Web.Models.OnePieceFlow.KitComponentes
{
    public class SelectViewModel
    {
        public int idKit { get; set; }
        public string NOMBRE { set; get; }
        public string CUSTOMPN { set; get; }
        public string TYPE { set; get; }
        public int? POSITION { get; set; }
        public bool COLOR { get; set; }
    }
}
